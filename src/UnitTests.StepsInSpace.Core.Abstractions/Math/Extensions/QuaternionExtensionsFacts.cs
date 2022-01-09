using StepsInSpace.Core.Abstractions.Math;
using StepsInSpace.Core.Abstractions.Math.Extensions;
using Xunit;

namespace UnitTests.StepsInSpace.Core.Abstractions.Math.Extensions;

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
    [InlineData(1F, 2F, 3F, 4F, 3F, 4F, 5F, 6F)]
    [InlineData(2F, 3F, 4F, 5F, 4F, 5F, 6F, 7F)]
    [InlineData(-1F, -2F, -3F, -4F, -3F, -4F, -5F, -6F)]
    [InlineData(-2F, -3F, -4F, -5F, -4F, -5F, -6F, -7F)]
    public void Multiplies_quaternions(float x1, float y1, float z1, float w1, float x2, float y2, float z2, float w2)
    {
        // Given
        var sut = new Quaternion(x1, y1, z1, w1);
        var right = new Quaternion(x2, y2, z2, w2);
        var expectedX = right.W * sut.X + sut.W * right.X + (sut.Y * right.Z - sut.Z * right.Y);
        var expectedY = right.W * sut.Y + sut.W * right.Y + (sut.Z * right.X - sut.X * right.Z);
        var expectedZ = right.W * sut.Z + sut.W * right.Z + (sut.X * right.Y - sut.Y * right.X);
        var expectedW = sut.W * right.W - (sut.X * right.X + sut.Y * right.Y + sut.Z * right.Z);
        
        // When
        var actual = sut.Multiply(right);

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

    [Theory]
    [InlineData(2F, 3F, 4F, 5F, 6F)]
    [InlineData(-2F, -3F, -4F, -5F, 6F)]
    public void Subtracts_number(float x, float y, float z, float w, float value)
    {
        // Given
        var sut = new Quaternion(x, y, z, w);
        
        // When
        var actual = sut.Subtract(value);

        // Then
        Assert.Equal(x - value, actual.X);
        Assert.Equal(y - value, actual.Y);
        Assert.Equal(z - value, actual.Z);
        Assert.Equal(w - value, actual.W);
    }

    [Theory]
    [InlineData(2F, 3F, 4F, 5F, 6F)]
    [InlineData(-2F, -3F, -4F, -5F, 6F)]
    public void Multiplies_number(float x, float y, float z, float w, float value)
    {
        // Given
        var sut = new Quaternion(x, y, z, w);

        // When
        var actual = sut.Multiply(value);

        // Then
        Assert.Equal(x * value, actual.X);
        Assert.Equal(y * value, actual.Y);
        Assert.Equal(z * value, actual.Z);
        Assert.Equal(w * value, actual.W);
    }

    [Theory]
    [InlineData(2F, 3F, 4F, 5F, 6F)]
    [InlineData(-2F, -3F, -4F, -5F, 6F)]
    public void Divides_number(float x, float y, float z, float w, float value)
    {
        // Given
        var sut = new Quaternion(x, y, z, w);
        
        // When
        var actual = sut.Divide(value);

        // Then
        Assert.Equal(x / value, actual.X);
        Assert.Equal(y / value, actual.Y);
        Assert.Equal(z / value, actual.Z);
        Assert.Equal(w / value, actual.W);
    }

    [Theory]
    [InlineData(1F, 0F, 0F, 0F,   -1F,  0F,  0F,  0F)]
    [InlineData(0F, 1F, 0F, 0F,    0F, -1F,  0F,  0F)]
    [InlineData(0F, 0F, 1F, 0F,    0F,  0F, -1F,  0F)]
    [InlineData(0F, 0F, 0F, 1F,    0F,  0F,  0F, -1F)]
    [InlineData(2F, 0F, 0F, 0F,   -0.5F,    0F,    0F,    0F)]
    [InlineData(0F, 2F, 0F, 0F,      0F, -0.5F,    0F,    0F)]
    [InlineData(0F, 0F, 2F, 0F,      0F,    0F, -0.5F,    0F)]
    [InlineData(0F, 0F, 0F, 2F,      0F,    0F,    0F, -0.5F)]
    [InlineData(0F, 0F, 0F, 0F,      0F,    0F,    0F,    0F)]
    public void Inverts_quaternion(
        float x, float y, float z, float w, 
        float expectedX, float expectedY, float expectedZ, float expectedW)
    {
        // Given
        var sut = new Quaternion(x, y, z, w);
        
        // When
        var actual = sut.Invert();
        
        // Then
        Assert.Equal(expectedX, actual.X);
        Assert.Equal(expectedY, actual.Y);
        Assert.Equal(expectedZ, actual.Z);
        Assert.Equal(expectedW, actual.W);
    }
    
        
    [Theory]
    [InlineData(0F, 0F, 0F, 0F)]
    [InlineData(1F, 2F, 3F, 4F)]
    [InlineData(-1F, -2F, -3F, -4F)]
    [InlineData(0.1F, 0.2F, 0.3F, 0.4F)]
    [InlineData(-0.1F, -0.2F, -0.3F, -0.4F)]
    [InlineData(float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue)]
    [InlineData(float.MinValue, float.MinValue, float.MinValue, float.MinValue)]
    public void Creates_rotation_matrix(float x, float y, float z, float w)
    {
        // Given
        var sut = new Quaternion(x, y, z, w);
        var squareRotation = sut.Multiply(sut);
        var xy = sut.X * sut.Y;
        var xz = sut.X * sut.Z;
        var xw = sut.X * sut.W;
        var yz = sut.Y * sut.Z;
        var yw = sut.Y * sut.W;
        var zw = sut.Z * sut.W;
        var s2 = 2f / (squareRotation.X + squareRotation.Y + squareRotation.Z + squareRotation.W);
        var row0 = new Vector4d(
            1f - (s2 * (squareRotation.Y + squareRotation.Z)),
            s2 * (xy + zw),
            s2 * (xz - yw),
            0);
        var row1 = new Vector4d(
            s2 * (xy - zw),
            1f - (s2 * (squareRotation.X + squareRotation.Z)),
            s2 * (yz + xw),
            0);
        var row2 = new Vector4d(
            s2 * (xz + yw),
            s2 * (yz - xw),
            1f - (s2 * (squareRotation.X + squareRotation.Y)),
            0);
        var row3 = Vector4d.UnitW;
        
        // When
        var actual = sut.ToRotation();

        // Then
        Assert.Equal(row0.X, actual.M00);
        Assert.Equal(row0.Y, actual.M01);
        Assert.Equal(row0.Z, actual.M02);
        Assert.Equal(row0.W, actual.M03);

        Assert.Equal(row1.X, actual.M10);
        Assert.Equal(row1.Y, actual.M11);
        Assert.Equal(row1.Z, actual.M12);
        Assert.Equal(row1.W, actual.M13);

        Assert.Equal(row2.X, actual.M20);
        Assert.Equal(row2.Y, actual.M21);
        Assert.Equal(row2.Z, actual.M22);
        Assert.Equal(row2.W, actual.M23);

        Assert.Equal(row3.X, actual.M30);
        Assert.Equal(row3.Y, actual.M31);
        Assert.Equal(row3.Z, actual.M32);
        Assert.Equal(row3.W, actual.M33);
    }

}