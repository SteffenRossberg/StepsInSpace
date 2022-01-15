namespace StepsInSpace.Core.Abstractions.Resources;

public interface IFileSystemProvider
{
    byte[] ReadFile(string file);
}