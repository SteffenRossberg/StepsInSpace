using System;
using System.IO;
using SkiaSharp;
using StepsInSpace.Core.Resources;
using Xunit;

namespace UnitTests.StepsInSpace.Core.Resources;

public class BitmapExtractorFacts
{
    private readonly Func<BitmapExtractor> _createBitmapExtractor;
        
    public BitmapExtractorFacts()
    {
        _createBitmapExtractor = () => new BitmapExtractor();
    }
    
    [Fact]
    public void ExtractsBitmapData()
    {
        // Given
        var sut = _createBitmapExtractor();
        var data = File.ReadAllBytes("./assets/logo.png");
        byte[] expected;
        using (var stream = new MemoryStream(data))
        {
            expected = SKBitmap.FromImage(SKImage.FromEncodedData(stream)).Bytes;
        }
        
        // When
        var actual = sut.ExtractPixelData(File.ReadAllBytes("./assets/logo.png"));

        // Then
        Assert.Equal(expected, actual);
    }
}