namespace StepsInSpace.Core.Abstractions.Resources;

public interface IBitmapExtractor
{
    byte[] ExtractPixelData(byte[] imageData);
}