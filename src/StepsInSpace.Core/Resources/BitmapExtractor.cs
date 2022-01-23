using System.IO;
using SkiaSharp;
using StepsInSpace.Core.Abstractions.Resources;

namespace StepsInSpace.Core.Resources;

public class BitmapExtractor : IBitmapExtractor
{
    public (int Width, int Height, byte[] PixelData) ExtractPixelData(byte[] imageData)
    {
        using var data = new MemoryStream(imageData);
        var image = SKImage.FromEncodedData(data);
        var bitmap = SKBitmap.FromImage(image);
        return (bitmap.Width, bitmap.Height, PixelData: bitmap.Bytes);
    }
}