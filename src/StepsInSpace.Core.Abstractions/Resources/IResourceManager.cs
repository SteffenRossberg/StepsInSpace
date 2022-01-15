namespace StepsInSpace.Core.Abstractions.Resources;

public interface IResourceManager
{
    byte[] GetTextureData(string id);

    string GetTextData(string file);
}