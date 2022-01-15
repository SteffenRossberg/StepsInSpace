using System.Collections.Concurrent;
using StepsInSpace.Core.Abstractions.Resources;

namespace StepsInSpace.Core.Resources;

public class ResourceManager : IResourceManager
{
    public ResourceManager(
        IFileSystemProvider fileSystemProvider,
        IBitmapExtractor bitmapExtractor)
    {
        _fileSystemProvider = fileSystemProvider;
        _bitmapExtractor = bitmapExtractor;
    }
    
    public byte[] GetTextureData(string file)
    {
        var raw = _fileSystemProvider.ReadFile(file);
        var extracted = _bitmapExtractor.ExtractPixelData(raw);
        return extracted;
    }
    
    private readonly IFileSystemProvider _fileSystemProvider;
    private readonly IBitmapExtractor _bitmapExtractor;
}