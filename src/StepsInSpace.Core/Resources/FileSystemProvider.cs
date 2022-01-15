using System;
using System.IO;
using StepsInSpace.Core.Abstractions.Resources;

namespace StepsInSpace.Core.Resources;

public class FileSystemProvider : IFileSystemProvider
{
    public byte[] ReadFile(string file)
    {
        try
        {
            return File.ReadAllBytes(file);
        }
        catch (FileNotFoundException)
        {
            return Array.Empty<byte>();
        }
        catch (DirectoryNotFoundException)
        {
            return Array.Empty<byte>();
        }
    }
}