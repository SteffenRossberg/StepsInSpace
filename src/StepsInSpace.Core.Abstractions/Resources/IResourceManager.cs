namespace StepsInSpace.Core.Abstractions.Resources;

public interface IResourceManager
{
    byte[] GetTextureData(string file);

    string GetTextData(string file);
}