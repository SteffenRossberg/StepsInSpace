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
        var right = new Vector3d(x2, y2, z2);
        
        // When
        var actual = sut.Add(right);

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
        var right = new Vector3d(x2, y2, z2);
        
        // When
        var actual = sut.Subtract(right);

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
        var right = new Vector3d(x2, y2, z2);
        
        // When
        var actual = sut.Multiply(right);

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
        var right = new Vector3d(x2, y2, z2);
        
        // When
        var actual = sut.Divide(right);

        // Then
        Assert.Equal(expectedX, actual.X);
        Assert.Equal(expectedY, actual.Y);
        Assert.Equal(expectedZ, actual.Z);
    }
        
    [Theory]
    [InlineData(1F, 2F, 3F, 3F, 4F, 5F, 1F * 3F + 2F * 4F + 3F * 5F)]
    [InlineData(2F, 2F, 3F, 3F, 5F, 6F, 2F * 3F + 2F * 5F + 3F * 6F)]
    [InlineData(-1F, -2F, -3F, -3F, -4F, -5F, -1F * -3F + -2F * -4F + -3F * -5F)]
    [InlineData(2F, 2F, 2F, -3F, -5F, -7F, 2F * -3F + 2F * -5F + 2F * -7F)]
    public void Dots_vectors(float x1, float y1, float z1, float x2, float y2, float z2, float expected)
    {
        // Given
        var sut = new Vector3d(x1, y1, z1);
        var right = new Vector3d(x2, y2, z2);
        
        // When
        var actual = sut.Dot(right);

        // Then
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1F, 2F, 3F, 3F, 4F, 5F, 2F * 5F - 3F * 4F, 3F * 3F - 1F * 5F, 1F * 4F - 2F * 3F)]
    public void Crosses_vectors(float x1, float y1, float z1, float x2, float y2, float z2, float expectedX, float expectedY, float expectedZ)
    {
        // Given
        var sut = new Vector3d(x1, y1, z1);
        var right = new Vector3d(x2, y2, z2);
        
        // When
        var actual = sut.Cross(right);

        // Then
        Assert.Equal(expectedX, actual.X);
        Assert.Equal(expectedY, actual.Y);
        Assert.Equal(expectedZ, actual.Z);
    }
    
    [Fact]
    public void Normalizes_vector()
    {
        // Given
        var sut = new Vector3d(5F, 7F, 9F);
        
        // When
        var actual = sut.Normalize();

        // Then
        Assert.Equal(sut.X / (float)System.Math.Pow(sut.X * sut.X + sut.Y * sut.Y + sut.Z * sut.Z, 0.5F), actual.X);
        Assert.Equal(sut.Y / (float)System.Math.Pow(sut.X * sut.X + sut.Y * sut.Y + sut.Z * sut.Z, 0.5F), actual.Y);
        Assert.Equal(sut.Z / (float)System.Math.Pow(sut.X * sut.X + sut.Y * sut.Y + sut.Z * sut.Z, 0.5F), actual.Z);
    }
    
    [Fact]
    public void Calculates_length_of_vector()
    {
        // Given
        var sut = new Vector3d(5F, 7F, 9F);
        
        // When
        var actual = sut.Length();

        // Then
        Assert.Equal((float)System.Math.Pow(sut.X * sut.X + sut.Y * sut.Y + sut.Z * sut.Z, 0.5F), actual);
    }
    
    [Fact]
    public void Calculates_squared_length_of_vector()
    {
        // Given
        var sut = new Vector3d(5F, 7F, 9F);
        
        // When
        var actual = sut.SquaredLength();

        // Then
        Assert.Equal(sut.X * sut.X + sut.Y * sut.Y + sut.Z * sut.Z, actual);
    }

    [Theory]
    [InlineData(2F, 3F, 4F, 5F)]
    [InlineData(-2F, -3F, -4F, 5F)]
    public void Adds_number(float x, float y, float z, float value)
    {
        // Given
        var sut = new Vector3d(x, y, z);
        
        // When
        var actual = sut.Add(value);

        // Then
        Assert.Equal(x + value, actual.X);
        Assert.Equal(y + value, actual.Y);
        Assert.Equal(z + value, actual.Z);
    }

    [Theory]
    [InlineData(2F, 3F, 4F, 5F)]
    [InlineData(-2F, -3F, -4F, 5F)]
    public void Subtracts_number(float x, float y, float z, float value)
    {
        // Given
        var sut = new Vector3d(x, y, z);
        
        // When
        var actual = sut.Subtract(value);

        // Then
        Assert.Equal(x - value, actual.X);
        Assert.Equal(y - value, actual.Y);
        Assert.Equal(z - value, actual.Z);
    }

    [Theory]
    [InlineData(2F, 3F, 4F, 5F)]
    [InlineData(-2F, -3F, -4F, 5F)]
    public void Multiplies_number(float x, float y, float z, float value)
    {
        // Given
        var sut = new Vector3d(x, y, z);
        
        // When
        var actual = sut.Multiply(value);

        // Then
        Assert.Equal(x * value, actual.X);
        Assert.Equal(y * value, actual.Y);
        Assert.Equal(z * value, actual.Z);
    }

    [Theory]
    [InlineData(2F, 3F, 4F, 5F)]
    [InlineData(-2F, -3F, -4F, 5F)]
    public void Divides_number(float x, float y, float z, float value)
    {
        // Given
        var sut = new Vector3d(x, y, z);
        
        // When
        var actual = sut.Divide(value);

        // Then
        Assert.Equal(x / value, actual.X);
        Assert.Equal(y / value, actual.Y);
        Assert.Equal(z / value, actual.Z);
    }

    [Theory]
    [InlineData(0F, 0F, 0F, 0F)]
    [InlineData(1F, 0F, 0F, 0F)]
    [InlineData(1F, 2F, 3F, 0F)]
    [InlineData(0F, 0F, 0F, 1F)]
    [InlineData(1F, 0F, 0F, 1F)]
    [InlineData(1F, 2F, 3F, 1F)]
    [InlineData(0F, 0F, 0F, 90F)]
    [InlineData(1F, 0F, 0F, 90F)]
    [InlineData(1F, 2F, 3F, 90F)]
    [InlineData(0F, 0F, 0F, 180F)]
    [InlineData(1F, 0F, 0F, 180F)]
    [InlineData(1F, 2F, 3F, 180F)]
    [InlineData(0F, 0F, 0F, 360F)]
    [InlineData(1F, 0F, 0F, 360F)]
    [InlineData(1F, 2F, 3F, 360F)]
    public void Creates_rotation_quaternion(float x, float y, float z, float angleInDegree)
    {
        // Given
        var angle = angleInDegree.ToRadians() * 0.5F;
        var sut = new Vector3d(x, y, z);
        var axis = sut.Normalize().Multiply((float)System.Math.Sin(angle));
        var expected =
            sut.SquaredLength() == 0F
                ? Quaternion.Identity
                : new Quaternion(axis.X, axis.Y, axis.Z, (float) System.Math.Cos(angle)).Normalize();

        // When
        var actual = sut.CreateRotation(angleInDegree);
        
        // Then
        Assert.Equal(expected.X, actual.X);
        Assert.Equal(expected.Y, actual.Y);
        Assert.Equal(expected.Z, actual.Z);
        Assert.Equal(expected.W, actual.W);
    }
}