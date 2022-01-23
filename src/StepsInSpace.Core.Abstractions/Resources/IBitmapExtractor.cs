namespace StepsInSpace.Core.Abstractions.Resources;

public interface IBitmapExtractor
{
    (int Width, int Height, byte[] PixelData) ExtractPixelData(byte[] imageData);
}