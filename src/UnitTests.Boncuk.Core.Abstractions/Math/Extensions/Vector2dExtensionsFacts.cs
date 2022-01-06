using Boncuk.Core.Abstractions.Math;
using Boncuk.Core.Abstractions.Math.Extensions;
using Xunit;

namespace UnitTests.Boncuk.Core.Abstractions.Math.Extensions;

public class Vector2dExtensionsFacts
{
    [Theory]
    [InlineData(1F, 2F, 3F, 4F, 1F + 3F, 2F + 4F)]
    [InlineData(2F, 3F, 4F, 5F, 2F + 4F, 3F + 5F)]
    [InlineData(-1F, -2F, -3F, -4F, -1F + -3F, -2F + -4F)]
    [InlineData(-2F, -3F, -4F, -5F, -2F + -4F, -3F + -5F)]
    public void Adds_vectors(float x1, float y1, float x2, float y2, float expectedX, float expectedY)
    {
        // Given
        var sut = new Vector2d(x1, y1);
        var source2 = new Vector2d(x2, y2);
        
        // When
        var actual = sut.Add(source2);

        // Then
        Assert.Equal(expectedX, actual.X);
        Assert.Equal(expectedY, actual.Y);
    }
    
    [Theory]
    [InlineData(1F, 2F, 3F, 4F, 1F - 3F, 2F - 4F)]
    [InlineData(2F, 2F, 3F, 5F, 2F - 3F, 2F - 5F)]
    [InlineData(-1F, -2F, -3F, -4F, -1F - -3F, -2F - -4F)]
    [InlineData(-2F, -2F, -3F, -5F, -2F - -3F, -2F - -5F)]
    public void Subtracts_vectors(float x1, float y1, float x2, float y2, float expectedX, float expectedY)
    {
        // Given
        var sut = new Vector2d(x1, y1);
        var source2 = new Vector2d(x2, y2);
        
        // When
        var actual = sut.Subtract(source2);

        // Then
        Assert.Equal(expectedX, actual.X);
        Assert.Equal(expectedY, actual.Y);
    }
    
    [Theory]
    [InlineData(1F, 2F, 3F, 4F, 1F * 3F, 2F * 4F)]
    [InlineData(2F, 2F, 3F, 5F, 2F * 3F, 2F * 5F)]
    [InlineData(-1F, -2F, -3F, -4F, -1F * -3F, -2F * -4F)]
    [InlineData(2F, 2F, -3F, -5F, 2F * -3F, 2F * -5F)]
    public void Multiplies_vectors(float x1, float y1, float x2, float y2, float expectedX, float expectedY)
    {
        // Given
        var sut = new Vector2d(x1, y1);
        var source2 = new Vector2d(x2, y2);
        
        // When
        var actual = sut.Multiply(source2);

        // Then
        Assert.Equal(expectedX, actual.X);
        Assert.Equal(expectedY, actual.Y);
    }
    
    [Theory]
    [InlineData(1F, 2F, 3F, 4F, 1F / 3F, 2F / 4F)]
    [InlineData(2F, 2F, 3F, 5F, 2F / 3F, 2F / 5F)]
    [InlineData(-1F, -2F, -3F, -4F, -1F / -3F, -2F / -4F)]
    [InlineData(2F, 2F, -3F, -5F, 2F / -3F, 2F / -5F)]
    public void Divides_vectors(float x1, float y1, float x2, float y2, float expectedX, float expectedY)
    {
        // Given
        var sut = new Vector2d(x1, y1);
        var source2 = new Vector2d(x2, y2);
        
        // When
        var actual = sut.Divide(source2);

        // Then
        Assert.Equal(expectedX, actual.X);
        Assert.Equal(expectedY, actual.Y);
    }
}