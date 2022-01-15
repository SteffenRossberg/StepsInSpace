using System.Collections.Generic;
using System.IO;
using System.Text;
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
        _encoding = new UTF8Encoding(false, true);
    }
    
    public byte[] GetTextureData(string file)
    {
        var raw = _fileSystemProvider.ReadFile(file);
        var extracted = _bitmapExtractor.ExtractPixelData(raw);
        return extracted;
    }

    public string GetTextData(string file)
    {
        var raw = _fileSystemProvider.ReadFile(file);
        var text = _encoding.GetString(raw);
        return text;
    }

    public string[] GetTextLines(string file)
    {
        var content = GetTextData(file);
        var lines = new List<string>();
        using (var reader = new StringReader(content))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }
        }
        return lines.ToArray();
    }

    private readonly IFileSystemProvider _fileSystemProvider;
    private readonly IBitmapExtractor _bitmapExtractor;
    private readonly UTF8Encoding _encoding;
}