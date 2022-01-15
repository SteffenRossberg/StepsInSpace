using System;
using System.Linq;
using System.Text;
using Moq;
using StepsInSpace.Core.Abstractions.Resources;
using StepsInSpace.Core.Resources;
using Xunit;

namespace UnitTests.StepsInSpace.Core.Resources;

public class ResourceManagerFacts
{
    private readonly Mock<IFileSystemProvider> _fileSystemProviderMock;
    private readonly Mock<IBitmapExtractor> _bitmapExtractorMock;
    private readonly Func<ResourceManager> _createResourceManager;
    
    public ResourceManagerFacts()
    {
        _fileSystemProviderMock = new Mock<IFileSystemProvider>();
        _bitmapExtractorMock = new Mock<IBitmapExtractor>();

        _createResourceManager = () => new ResourceManager(
            _fileSystemProviderMock.Object,
            _bitmapExtractorMock.Object);
    }

    [Fact]
    public void Gets_pixel_data()
    {
        // Given
        var file = "assets/logo.png";
        var logoData = new byte[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
        var expectedData = new byte[] {9, 8, 7, 6, 5, 4, 3, 2, 1, 0};
        _fileSystemProviderMock
            .Setup(provider => provider.ReadFile(file))
            .Returns(() => logoData);
        _bitmapExtractorMock
            .Setup(extractor =>
                extractor.ExtractPixelData(
                    It.Is<byte[]>(data =>
                        logoData
                            .Zip(data, (expected, actual) => Equals(expected, actual))
                            .All(isMatch => isMatch))))
            .Returns(() => expectedData);
        var sut = _createResourceManager();
        
        // When
        var actualData = sut.GetTextureData(file);
        
        // Then
        Assert.Equal(expectedData, actualData);
    }
    
    [Fact]
    public void Gets_text_data()
    {
        // Given
        var file = "assets/shader.glsl";
        var expectedText = "int main() {return 0;}";
        var textData = new UTF8Encoding(false, true).GetBytes(expectedText);
        _fileSystemProviderMock
            .Setup(provider => provider.ReadFile(file))
            .Returns(() => textData);
        var sut = _createResourceManager();
        
        // When
        var actualText = sut.GetTextData(file);
        
        // Then
        Assert.Equal(expectedText, actualText);
    }

}