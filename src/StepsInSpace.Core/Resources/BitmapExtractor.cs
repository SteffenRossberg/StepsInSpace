using System;
using System.IO;
using SkiaSharp;
using StepsInSpace.Core.Abstractions.Resources;

namespace StepsInSpace.Core.Resources;

public class BitmapExtractor : IBitmapExtractor
{
    public byte[] ExtractPixelData(byte[] imageData)
    {
        using var data = new MemoryStream(imageData);
        var image = SKImage.FromEncodedData(data);
        var bitmap = SKBitmap.FromImage(image);
        return bitmap.Bytes;
    }
}