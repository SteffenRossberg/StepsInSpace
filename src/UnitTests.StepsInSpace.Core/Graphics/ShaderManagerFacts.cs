using System;
using Moq;
using OpenTK.Graphics.OpenGL;
using StepsInSpace.Core.Abstractions.Graphics;
using StepsInSpace.Core.Abstractions.Resources;
using StepsInSpace.Core.Graphics;
using Xunit;

namespace UnitTests.StepsInSpace.Core.Graphics;

public class ShaderManagerFacts
{
    private readonly Mock<IGlContext> _glContextMock;
    private readonly Mock<IResourceManager> _resourceManagerMock;
    private readonly Func<ShaderManager> _createShaderManager;
    
    public ShaderManagerFacts()
    {
        _glContextMock = new Mock<IGlContext>();
        _resourceManagerMock = new Mock<IResourceManager>();
        
        _createShaderManager = 
            () => new ShaderManager(
                _glContextMock.Object,
                _resourceManagerMock.Object);
    }
    
    [Theory]
    [InlineData("assets/shaders/BaseFragmentShader.glsl", "int main() { return; }", ShaderType.FragmentShader, 1)]
    [InlineData("assets/shaders/BaseVertexShader.glsl", "int main() { return; }", ShaderType.VertexShader, 2)]
    public void Returns_compiled_shader(
        string shaderFile, 
        string shaderCode, 
        ShaderType shaderType, 
        int expectedShaderId)
    {
        // Given
        var sut = _createShaderManager();
        var shaderLines = new[] {shaderCode};
        _resourceManagerMock
            .Setup(manager => manager.GetTextLines(shaderFile))
            .Returns(shaderLines);
        _glContextMock
            .Setup(context => context.CreateShader(shaderType))
            .Returns(expectedShaderId);
        _glContextMock
            .Setup(context => context.CompileShader(expectedShaderId))
            .Callback(
                () => _glContextMock.Verify(
                    context => context.ShaderSource(expectedShaderId, string.Join("\n", shaderCode))));
        _glContextMock
            .Setup(context => context.GetShader(expectedShaderId, ShaderParameter.CompileStatus))
            .Returns(1);
        
        // When
        var actualShaderId = sut.GetCompiledShader(shaderFile, shaderType);
        
        // Then
        _glContextMock.Verify(context => context.CompileShader(expectedShaderId), Times.Once);
        Assert.Equal(expectedShaderId, actualShaderId);
    }
    
    [Theory]
    [InlineData("assets/shaders/BaseFragmentShader.glsl", "int main() { return; }", ShaderType.FragmentShader, 0, 1)]
    [InlineData("assets/shaders/BaseVertexShader.glsl", "int main() { return; }", ShaderType.VertexShader, 0, 2)]
    [InlineData("assets/shaders/BaseFragmentShader.glsl", "int main() { return; }", ShaderType.FragmentShader, -1, 1)]
    [InlineData("assets/shaders/BaseVertexShader.glsl", "int main() { return; }", ShaderType.VertexShader, -1, 2)]
    [InlineData("assets/shaders/BaseFragmentShader.glsl", "int main() { return; }", ShaderType.FragmentShader, 2, 1)]
    [InlineData("assets/shaders/BaseVertexShader.glsl", "int main() { return; }", ShaderType.VertexShader, 2, 2)]
    public void Throws_invalid_operation_exception_if_shader_not_compiled_successfully(
        string shaderFile, 
        string shaderCode, 
        ShaderType shaderType, 
        int shaderStatus,
        int expectedShaderId)
    {
        // Given
        var sut = _createShaderManager();
        var shaderLines = new[] {shaderCode};
        _resourceManagerMock
            .Setup(manager => manager.GetTextLines(shaderFile))
            .Returns(shaderLines);
        _glContextMock
            .Setup(context => context.CreateShader(shaderType))
            .Returns(expectedShaderId);
        _glContextMock
            .Setup(context => context.CompileShader(expectedShaderId))
            .Callback(
                () => _glContextMock.Verify(
                    context => context.ShaderSource(expectedShaderId, string.Join("\n", shaderCode))));
        _glContextMock
            .Setup(context => context.GetShader(expectedShaderId, ShaderParameter.CompileStatus))
            .Returns(() => shaderStatus);        
        _glContextMock
            .Setup(context => context.GetShaderInfoLog(expectedShaderId))
            .Returns("compile error");
        
        // When
        Assert.Throws<InvalidOperationException>(() => sut.GetCompiledShader(shaderFile, shaderType));
    }
    
        
    [Theory]
    [InlineData("assets/shaders/BaseFragmentShader.glsl", "int main() { return; }", ShaderType.FragmentShader, 1)]
    [InlineData("assets/shaders/BaseVertexShader.glsl", "int main() { return; }", ShaderType.VertexShader, 2)]
    public void Returns_cached_compiled_shader(
        string shaderFile, 
        string shaderCode, 
        ShaderType shaderType, 
        int expectedShaderId)
    {
        // Given
        var sut = _createShaderManager();
        var shaderLines = new[] {shaderCode};
        _resourceManagerMock
            .Setup(manager => manager.GetTextLines(shaderFile))
            .Returns(shaderLines);
        _glContextMock
            .Setup(context => context.CreateShader(shaderType))
            .Returns(expectedShaderId);
        _glContextMock
            .Setup(context => context.GetShader(expectedShaderId, ShaderParameter.CompileStatus))
            .Returns(1);
        sut.GetCompiledShader(shaderFile, shaderType);
        
        // When
        var actualShaderId = sut.GetCompiledShader(shaderFile, shaderType);
        
        // Then
        _resourceManagerMock.Verify(manager => manager.GetTextLines(shaderFile), Times.Once);
        _glContextMock.Verify(context => context.CreateShader(shaderType), Times.Once);
        _glContextMock.Verify(context =>
                context.ShaderSource(
                    expectedShaderId,
                    string.Join("\n", shaderCode)),
            Times.Once);
        _glContextMock.Verify(context => context.CompileShader(expectedShaderId), Times.Once);
        _glContextMock.Verify(context =>
                context.GetShader(
                    expectedShaderId,
                    ShaderParameter.CompileStatus),
            Times.Once);
        Assert.Equal(expectedShaderId, actualShaderId);
    }

}