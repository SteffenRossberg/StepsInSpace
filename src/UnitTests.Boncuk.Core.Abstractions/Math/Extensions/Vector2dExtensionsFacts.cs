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
        var right = new Vector2d(x2, y2);
        
        // When
        var actual = sut.Add(right);

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
        var right = new Vector2d(x2, y2);
        
        // When
        var actual = sut.Subtract(right);

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
        var right = new Vector2d(x2, y2);
        
        // When
        var actual = sut.Multiply(right);

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
        var right = new Vector2d(x2, y2);
        
        // When
        var actual = sut.Divide(right);

        // Then
        Assert.Equal(expectedX, actual.X);
        Assert.Equal(expectedY, actual.Y);
    }
    
    [Theory]
    [InlineData(1F, 2F, 3F, 4F, 1F * 3F + 2F * 4F)]
    [InlineData(2F, 2F, 3F, 5F, 2F * 3F + 2F * 5F)]
    [InlineData(-1F, -2F, -3F, -4F, -1F * -3F + -2F * -4F)]
    [InlineData(2F, 2F, -3F, -5F, 2F * -3F + 2F * -5F)]
    public void Dots_vectors(float x1, float y1, float x2, float y2, float expected)
    {
        // Given
        var sut = new Vector2d(x1, y1);
        var right = new Vector2d(x2, y2);
        
        // When
        var actual = sut.Dot(right);

        // Then
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void Normalizes_vector()
    {
        // Given
        var sut = new Vector2d(5F, 7F);
        
        // When
        var actual = sut.Normalize();

        // Then
        Assert.Equal(sut.X / (float)System.Math.Pow(sut.X * sut.X + sut.Y * sut.Y, 0.5F), actual.X);
        Assert.Equal(sut.Y / (float)System.Math.Pow(sut.X * sut.X + sut.Y * sut.Y, 0.5F), actual.Y);
    }

}