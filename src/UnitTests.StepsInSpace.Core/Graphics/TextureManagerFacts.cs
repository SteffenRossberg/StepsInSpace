using System;
using Moq;
using OpenTK.Graphics.OpenGL;
using StepsInSpace.Core.Abstractions.Graphics;
using StepsInSpace.Core.Abstractions.Resources;
using StepsInSpace.Core.Graphics;
using Xunit;

namespace UnitTests.StepsInSpace.Core.Graphics;

public class TextureManagerFacts
{
    private readonly Mock<IGlContext> _glContextMock;
    private readonly Mock<IResourceManager> _resourceManagerMock;
    private readonly Func<TextureManager> _createTextureManager;

    public TextureManagerFacts()
    {
        _glContextMock = new Mock<IGlContext>();
        _resourceManagerMock = new Mock<IResourceManager>();
        
        _createTextureManager = () => 
            new TextureManager(
                _glContextMock.Object,
                _resourceManagerMock.Object);
    }

    [Fact]
    public void Loads_texture_into_gl_context()
    {
        // Given
        var sut = _createTextureManager();
        const string expectedFile = "street.even.png";
        const int expectedTextureId = int.MaxValue;
        var expectedData = (Width: 10, Height: 1, PixelData: new byte[] {1, 2, 3, 4, 5});
        _resourceManagerMock
            .Setup(manager => manager.GetTextureData(expectedFile))
            .Returns(expectedData);
        _glContextMock
            .Setup(context => context.GenTextures(1))
            .Returns(expectedTextureId);
        sut.GetTexture(expectedFile);
        
        // When
        var actualTextureId = sut.GetTexture(expectedFile);

        // Then
        Assert.Equal(expectedTextureId, actualTextureId);
        _glContextMock.Verify(context => 
            context.BindTexture(
                TextureTarget.Texture2D, 
                expectedTextureId),
            Times.Once);
        _glContextMock.Verify(context => 
            context.TexParameter(
                TextureTarget.Texture2D, 
                TextureParameterName.TextureWrapS, 
                (int)TextureWrapMode.ClampToEdge),
            Times.Once);
        _glContextMock.Verify(context => 
            context.TexParameter(
                TextureTarget.Texture2D, 
                TextureParameterName.TextureWrapT, 
                (int)TextureWrapMode.ClampToEdge),
            Times.Once);
        _glContextMock.Verify(context => 
            context.TexParameter(
                TextureTarget.Texture2D, 
                TextureParameterName.TextureMinFilter, 
                (int)TextureMinFilter.Linear),
            Times.Once);
        _glContextMock.Verify(context => 
            context.TexParameter(
                TextureTarget.Texture2D, 
                TextureParameterName.TextureMagFilter, 
                (int)TextureMagFilter.Linear),
            Times.Once);
        _glContextMock.Verify(context => 
            context.TexParameter(
                TextureTarget.Texture2D, 
                TextureParameterName.TextureBaseLevel, 
                0),
            Times.Once);
        _glContextMock.Verify(context => 
            context.TexParameter(
                TextureTarget.Texture2D, 
                TextureParameterName.TextureMaxLevel, 
                0),
            Times.Once);
        _glContextMock.Verify(context => 
            context.TexImage2D(
                TextureTarget.Texture2D, 
                0, 
                PixelInternalFormat.Rgba, 
                expectedData.Width, 
                expectedData.Height, 
                0, 
                PixelFormat.Rgba, 
                PixelType.UnsignedByte, 
                expectedData.PixelData),
            Times.Once);
    }
}