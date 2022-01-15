using System;
using System.IO;
using StepsInSpace.Core.Resources;
using Xunit;

namespace UnitTests.StepsInSpace.Core.Resources;

public class FileSystemProviderFacts
{
    private readonly Func<FileSystemProvider> _createFileSystemProvider;
    
    public FileSystemProviderFacts()
    {
        _createFileSystemProvider = () => new FileSystemProvider();
    }
    
    [Fact]
    public void Reads_all_bytes_from_file()
    {
        // Given
        var sut = _createFileSystemProvider();
        var expected = File.ReadAllBytes("./assets/logo.png");

        // When
        var actual = sut.ReadFile("assets/logo.png");
        
        // Then
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData("./assets/file-does-not-exists.xyz")]
    [InlineData("./directory-does-not-exists/file.xyz")]
    public void Reads_0_bytes_if_does_not_exists(string file)
    {
        // Given
        var sut = _createFileSystemProvider();

        // When
        var actual = sut.ReadFile(file);
        
        // Then
        Assert.Empty(actual);
    }
}