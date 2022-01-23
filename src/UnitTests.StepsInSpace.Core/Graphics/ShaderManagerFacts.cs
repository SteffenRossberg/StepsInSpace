using System;
using Microsoft.Extensions.Logging;
using Moq;
using OpenTK.Graphics.OpenGL;
using StepsInSpace.Core.Abstractions.Graphics;
using StepsInSpace.Core.Abstractions.Logging;
using StepsInSpace.Core.Abstractions.Resources;
using StepsInSpace.Core.Graphics;
using Xunit;

namespace UnitTests.StepsInSpace.Core.Graphics;

public class ShaderManagerFacts
{
    private readonly Mock<ILogger<ShaderManager>> _loggerMock;
    private readonly Mock<IGlContext> _glContextMock;
    private readonly Mock<IResourceManager> _resourceManagerMock;
    private readonly Func<ShaderManager> _createShaderManager;
    
    public ShaderManagerFacts()
    {
        _glContextMock = new Mock<IGlContext>();
        _resourceManagerMock = new Mock<IResourceManager>();
        _loggerMock = new Mock<ILogger<ShaderManager>>();
        
        _createShaderManager = 
            () => new ShaderManager(
                _loggerMock.Object,
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

    [Fact]
    public void Gets_program_from_shaders()
    {
        // Given
        var sut = _createShaderManager();
        
        var vertexShader = "vertex.glsl";
        var vertexShaderLines = new[] {"int main() { return; }"};
        _resourceManagerMock
            .Setup(manager => manager.GetTextLines(vertexShader))
            .Returns(vertexShaderLines);
        _glContextMock
            .Setup(context => context.CreateShader(ShaderType.VertexShader))
            .Returns(2);
        _glContextMock
            .Setup(context => context.GetShader(2, ShaderParameter.CompileStatus))
            .Returns(1);
        
        var fragmentShader = "fragment.glsl";
        var fragmentShaderLines = new[] {"int main() { return; }"};
        _resourceManagerMock
            .Setup(manager => manager.GetTextLines(fragmentShader))
            .Returns(fragmentShaderLines);
        _glContextMock
            .Setup(context => context.CreateShader(ShaderType.FragmentShader))
            .Returns(3);
        _glContextMock
            .Setup(context => context.GetShader(3, ShaderParameter.CompileStatus))
            .Returns(1);
        
        var expectedProgramId = 3;
        _glContextMock
            .Setup(context => context.CreateProgram())
            .Returns(expectedProgramId);
        _glContextMock
            .Setup(context => context.GetProgramInfoLog(expectedProgramId))
            .Returns("success");

        var expectedVertexShaderId = sut.GetCompiledShader(vertexShader, ShaderType.VertexShader);
        var expectedFragmentShaderId = sut.GetCompiledShader(fragmentShader, ShaderType.FragmentShader);
        
        sut.GetProgram(expectedVertexShaderId, expectedFragmentShaderId);
        
        // When
        var actualProgramId = sut.GetProgram(expectedVertexShaderId, expectedFragmentShaderId);
        
        // Then
        Assert.Equal(expectedProgramId, actualProgramId);
        _glContextMock.Verify(context => context.AttachShader(expectedProgramId, expectedVertexShaderId), Times.Once);
        _glContextMock.Verify(context => context.AttachShader(expectedProgramId, expectedFragmentShaderId), Times.Once);
        _glContextMock.Verify(context => context.LinkProgram(expectedProgramId), Times.Once);
        _glContextMock.Verify(context => context.GetProgramInfoLog(expectedProgramId), Times.Once);
        _loggerMock.Verify(
            logger =>
                logger.Log(
                    LogLevel.Information,
                    Information.ProgramInfoLog,
                    It.IsAny<It.IsAnyType>(),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
    }
    
    [Fact]
    public void Logs_error_if_shader_id_does_not_exists()
    {
        // Given
        var sut = _createShaderManager();
        const int notExistingShaderId = int.MaxValue;
        const int programId = 5;
        _glContextMock
            .Setup(context => context.CreateProgram())
            .Returns(programId);
        
        // When
        Assert.Throws<InvalidOperationException>(() => sut.GetProgram(notExistingShaderId));
        
        // Then
        _glContextMock.Verify(context => context.AttachShader(programId, notExistingShaderId), Times.Never);
        _glContextMock.Verify(context => context.LinkProgram(programId), Times.Never);
        _glContextMock.Verify(context => context.GetProgramInfoLog(programId), Times.Never);
        _loggerMock.Verify(
            logger =>
                logger.Log(
                    LogLevel.Error,
                    Error.ShaderIdIsNotRegistered,
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<InvalidOperationException>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
    }
}