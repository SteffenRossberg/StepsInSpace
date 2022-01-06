using Boncuk.Core.Abstractions.Math;
using Boncuk.Core.Abstractions.Math.Extensions;
using Xunit;

namespace UnitTests.Boncuk.Core.Abstractions.Math.Extensions;

public class Vector3dExtensionsFacts
{
    [Theory]
    [InlineData(1F, 2F, 3F, 3F, 4F, 5F, 1F + 3F, 2F + 4F, 3F + 5F)]
    [InlineData(2F, 3F, 4F, 4F, 5F, 6F, 2F + 4F, 3F + 5F, 4F + 6F)]
    [InlineData(-1F, -2F, -3F, -3F, -4F, -5F, -1F + -3F, -2F + -4F, -3F + -5F)]
    [InlineData(-2F, -3F, -4F, -4F, -5F, -6F, -2F + -4F, -3F + -5F, -4F + -6F)]
    public void Adds_vectors(float x1, float y1, float z1, float x2, float y2, float z2, float expectedX, float expectedY, float expectedZ)
    {
        // Given
        var sut = new Vector3d(x1, y1, z1);
        var source2 = new Vector3d(x2, y2, z2);
        
        // When
        var actual = sut.Add(source2);

        // Then
        Assert.Equal(expectedX, actual.X);
        Assert.Equal(expectedY, actual.Y);
        Assert.Equal(expectedZ, actual.Z);
    }
    
    [Theory]
    [InlineData(1F, 2F, 3F, 3F, 4F, 5F, 1F - 3F, 2F - 4F, 3F - 5F)]
    [InlineData(2F, 2F, 3F, 3F, 5F, 6F, 2F - 3F, 2F - 5F, 3F - 6F)]
    [InlineData(-1F, -2F, -3F, -3F, -4F, -5F, -1F - -3F, -2F - -4F, -3F - -5F)]
    [InlineData(-2F, -2F, -3F, -3F, -5F, -6F, -2F - -3F, -2F - -5F, -3F - -6F)]
    public void Subtracts_vectors(float x1, float y1, float z1, float x2, float y2, float z2, float expectedX, float expectedY, float expectedZ)
    {
        // Given
        var sut = new Vector3d(x1, y1, z1);
        var source2 = new Vector3d(x2, y2, z2);
        
        // When
        var actual = sut.Subtract(source2);

        // Then
        Assert.Equal(expectedX, actual.X);
        Assert.Equal(expectedY, actual.Y);
        Assert.Equal(expectedZ, actual.Z);
    }
    
    [Theory]
    [InlineData(1F, 2F, 3F, 3F, 4F, 5F, 1F * 3F, 2F * 4F, 3F * 5F)]
    [InlineData(2F, 2F, 3F, 3F, 5F, 6F, 2F * 3F, 2F * 5F, 3F * 6F)]
    [InlineData(-1F, -2F, -3F, -3F, -4F, -5F, -1F * -3F, -2F * -4F, -3F * -5F)]
    [InlineData(2F, 2F, 2F, -3F, -5F, -7F, 2F * -3F, 2F * -5F, 2F * -7F)]
    public void Multiplies_vectors(float x1, float y1, float z1, float x2, float y2, float z2, float expectedX, float expectedY, float expectedZ)
    {
        // Given
        var sut = new Vector3d(x1, y1, z1);
        var source2 = new Vector3d(x2, y2, z2);
        
        // When
        var actual = sut.Multiply(source2);

        // Then
        Assert.Equal(expectedX, actual.X);
        Assert.Equal(expectedY, actual.Y);
        Assert.Equal(expectedZ, actual.Z);
    }
    
    [Theory]
    [InlineData(1F, 2F, 3F, 3F, 4F, 5F, 1F / 3F, 2F / 4F, 3F / 5F)]
    [InlineData(2F, 2F, 3F, 3F, 5F, 6F, 2F / 3F, 2F / 5F, 3F / 6F)]
    [InlineData(-1F, -2F, -3F, -3F, -4F, -5F, -1F / -3F, -2F / -4F, -3F / -5F)]
    [InlineData(2F, 2F, 2F, -3F, -5F, -7F, 2F / -3F, 2F / -5F, 2F / -7F)]
    public void Divides_vectors(float x1, float y1, float z1, float x2, float y2, float z2, float expectedX, float expectedY, float expectedZ)
    {
        // Given
        var sut = new Vector3d(x1, y1, z1);
        var source2 = new Vector3d(x2, y2, z2);
        
        // When
        var actual = sut.Divide(source2);

        // Then
        Assert.Equal(expectedX, actual.X);
        Assert.Equal(expectedY, actual.Y);
        Assert.Equal(expectedZ, actual.Z);
    }
}