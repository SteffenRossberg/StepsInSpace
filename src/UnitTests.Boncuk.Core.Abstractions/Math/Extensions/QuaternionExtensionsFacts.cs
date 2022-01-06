using Boncuk.Core.Abstractions.Math;
using Boncuk.Core.Abstractions.Math.Extensions;
using Xunit;

namespace UnitTests.Boncuk.Core.Abstractions.Math.Extensions;

public class QuaternionExtensionsFacts
{
    [Theory]
    [InlineData(1F, 2F, 3F, 4F, 3F, 4F, 5F, 6F, 1F + 3F, 2F + 4F, 3F + 5F, 4F + 6F)]
    [InlineData(2F, 3F, 4F, 5F, 4F, 5F, 6F, 7F, 2F + 4F, 3F + 5F, 4F + 6F, 5F + 7F)]
    [InlineData(-1F, -2F, -3F, -4F, -3F, -4F, -5F, -6F, -1F + -3F, -2F + -4F, -3F + -5F, -4F + -6F)]
    [InlineData(-2F, -3F, -4F, -5F, -4F, -5F, -6F, -7F, -2F + -4F, -3F + -5F, -4F + -6F, -5F + -7F)]
    public void Adds_quaternions(float x1, float y1, float z1, float w1, float x2, float y2, float z2, float w2, float expectedX, float expectedY, float expectedZ, float expectedW)
    {
        // Given
        var sut = new Quaternion(x1, y1, z1, w1);
        var right = new Quaternion(x2, y2, z2, w2);
        
        // When
        var actual = sut.Add(right);

        // Then
        Assert.Equal(expectedX, actual.X);
        Assert.Equal(expectedY, actual.Y);
        Assert.Equal(expectedZ, actual.Z);
        Assert.Equal(expectedW, actual.W);
    }
    
    [Theory]
    [InlineData(1F, 2F, 3F, 4F, 3F, 4F, 5F, 6F, 1F - 3F, 2F - 4F, 3F - 5F, 4F - 6F)]
    [InlineData(2F, 3F, 4F, 5F, 4F, 5F, 6F, 7F, 2F - 4F, 3F - 5F, 4F - 6F, 5F - 7F)]
    [InlineData(-1F, -2F, -3F, -4F, -3F, -4F, -5F, -6F, -1F - -3F, -2F - -4F, -3F - -5F, -4F - -6F)]
    [InlineData(-2F, -3F, -4F, -5F, -4F, -5F, -6F, -7F, -2F - -4F, -3F - -5F, -4F - -6F, -5F - -7F)]
    public void Subtracts_quaternions(float x1, float y1, float z1, float w1, float x2, float y2, float z2, float w2, float expectedX, float expectedY, float expectedZ, float expectedW)
    {
        // Given
        var sut = new Quaternion(x1, y1, z1, w1);
        var right = new Quaternion(x2, y2, z2, w2);
        
        // When
        var actual = sut.Subtract(right);

        // Then
        Assert.Equal(expectedX, actual.X);
        Assert.Equal(expectedY, actual.Y);
        Assert.Equal(expectedZ, actual.Z);
        Assert.Equal(expectedW, actual.W);
    }
    
    [Theory]
    [InlineData(1F, 2F, 3F, 4F, 3F, 4F, 5F, 6F, 1F * 3F, 2F * 4F, 3F * 5F, 4F * 6F)]
    [InlineData(2F, 3F, 4F, 5F, 4F, 5F, 6F, 7F, 2F * 4F, 3F * 5F, 4F * 6F, 5F * 7F)]
    [InlineData(-1F, -2F, -3F, -4F, -3F, -4F, -5F, -6F, -1F * -3F, -2F * -4F, -3F * -5F, -4F * -6F)]
    [InlineData(-2F, -3F, -4F, -5F, -4F, -5F, -6F, -7F, -2F * -4F, -3F * -5F, -4F * -6F, -5F * -7F)]
    public void Multiplies_quaternions(float x1, float y1, float z1, float w1, float x2, float y2, float z2, float w2, float expectedX, float expectedY, float expectedZ, float expectedW)
    {
        // Given
        var sut = new Quaternion(x1, y1, z1, w1);
        var right = new Quaternion(x2, y2, z2, w2);
        
        // When
        var actual = sut.Multiply(right);

        // Then
        Assert.Equal(expectedX, actual.X);
        Assert.Equal(expectedY, actual.Y);
        Assert.Equal(expectedZ, actual.Z);
        Assert.Equal(expectedW, actual.W);
    }
    
    [Theory]
    [InlineData(1F, 2F, 3F, 4F, 3F, 4F, 5F, 6F, 1F / 3F, 2F / 4F, 3F / 5F, 4F / 6F)]
    [InlineData(2F, 3F, 4F, 5F, 4F, 5F, 6F, 7F, 2F / 4F, 3F / 5F, 4F / 6F, 5F / 7F)]
    [InlineData(-1F, -2F, -3F, -4F, -3F, -4F, -5F, -6F, -1F / -3F, -2F / -4F, -3F / -5F, -4F / -6F)]
    [InlineData(-2F, -3F, -4F, -5F, -4F, -5F, -6F, -7F, -2F / -4F, -3F / -5F, -4F / -6F, -5F / -7F)]
    public void Divides_quaternions(float x1, float y1, float z1, float w1, float x2, float y2, float z2, float w2, float expectedX, float expectedY, float expectedZ, float expectedW)
    {
        // Given
        var sut = new Quaternion(x1, y1, z1, w1);
        var right = new Quaternion(x2, y2, z2, w2);
    
        // When
        var actual = sut.Divide(right);

        // Then
        Assert.Equal(expectedX, actual.X);
        Assert.Equal(expectedY, actual.Y);
        Assert.Equal(expectedZ, actual.Z);
        Assert.Equal(expectedW, actual.W);
    }    
    
    [Theory]
    [InlineData(1F, 2F, 3F, 4F, 3F, 4F, 5F, 6F, 1F * 3F + 2F * 4F + 3F * 5F + 4F * 6F)]
    [InlineData(2F, 3F, 4F, 5F, 4F, 5F, 6F, 7F, 2F * 4F + 3F * 5F + 4F * 6F + 5F * 7F)]
    [InlineData(-1F, -2F, -3F, -4F, -3F, -4F, -5F, -6F, -1F * -3F + -2F * -4F + -3F * -5F + -4F * -6F)]
    [InlineData(-2F, -3F, -4F, -5F, -4F, -5F, -6F, -7F, -2F * -4F + -3F * -5F + -4F * -6F + -5F * -7F)]
    public void Dots_quaternions(float x1, float y1, float z1, float w1, float x2, float y2, float z2, float w2, float expected)
    {
        // Given
        var sut = new Quaternion(x1, y1, z1, w1);
        var right = new Quaternion(x2, y2, z2, w2);
        
        // When
        var actual = sut.Dot(right);

        // Then
        Assert.Equal(expected, actual);
    }
        
    [Fact]
    public void Normalizes_quaternion()
    {
        // Given
        var sut = new Quaternion(5F, 7F, 9F, 11F);
        
        // When
        var actual = sut.Normalize();

        // Then
        Assert.Equal(sut.X / (float)System.Math.Pow(sut.X * sut.X + sut.Y * sut.Y + sut.Z * sut.Z + sut.W * sut.W, 0.5F), actual.X);
        Assert.Equal(sut.Y / (float)System.Math.Pow(sut.X * sut.X + sut.Y * sut.Y + sut.Z * sut.Z + sut.W * sut.W, 0.5F), actual.Y);
        Assert.Equal(sut.Z / (float)System.Math.Pow(sut.X * sut.X + sut.Y * sut.Y + sut.Z * sut.Z + sut.W * sut.W, 0.5F), actual.Z);
        Assert.Equal(sut.W / (float)System.Math.Pow(sut.X * sut.X + sut.Y * sut.Y + sut.Z * sut.Z + sut.W * sut.W, 0.5F), actual.W);
    }
    
    [Fact]
    public void Calculates_length_of_quaternion()
    {
        // Given
        var sut = new Quaternion(5F, 7F, 9F, 11F);
        
        // When
        var actual = sut.Length();

        // Then
        Assert.Equal((float)System.Math.Pow(sut.X * sut.X + sut.Y * sut.Y + sut.Z * sut.Z + sut.W * sut.W, 0.5F), actual);
    }
    
    [Fact]
    public void Calculates_squared_length_of_quaternion()
    {
        // Given
        var sut = new Quaternion(5F, 7F, 9F, 11F);
        
        // When
        var actual = sut.SquaredLength();

        // Then
        Assert.Equal(sut.X * sut.X + sut.Y * sut.Y + sut.Z * sut.Z + sut.W * sut.W, actual);
    }

    [Theory]
    [InlineData(2F, 3F, 4F, 5F, 6F)]
    [InlineData(-2F, -3F, -4F, -5F, 6F)]
    public void Adds_number(float x, float y, float z, float w, float value)
    {
        // Given
        var sut = new Quaternion(x, y, z, w);
        
        // When
        var actual = sut.Add(value);

        // Then
        Assert.Equal(x + value, actual.X);
        Assert.Equal(y + value, actual.Y);
        Assert.Equal(z + value, actual.Z);
        Assert.Equal(w + value, actual.W);
    }

}