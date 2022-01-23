namespace StepsInSpace.Core.Abstractions.Resources;

public interface IResourceManager
{
    (int Width, int Height, byte[] PixelData) GetTextureData(string file);

    string GetTextData(string file);

    string[] GetTextLines(string file);
}