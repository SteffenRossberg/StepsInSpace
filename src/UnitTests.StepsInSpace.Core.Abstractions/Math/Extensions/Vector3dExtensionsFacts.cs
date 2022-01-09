using StepsInSpace.Core.Abstractions.Math;
using StepsInSpace.Core.Abstractions.Math.Extensions;
using Xunit;

namespace UnitTests.StepsInSpace.Core.Abstractions.Math.Extensions;

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

    [Theory]
    [InlineData( 0F,  0F,  0F,    0F,  0F,  0F,  0F)]
    [InlineData( 1F,  2F,  3F,    4F,  5F,  6F,  7F)]
    [InlineData(-1F, -2F, -3F,   -4F, -5F, -6F, -7F)]
    public void Transforms_vector_using_quaternion(float vX, float vY, float vZ, float qX, float qY, float qZ, float qW)
    {
        // Given
        var quaternion = new Quaternion(qX, qY, qZ, qW);
        var sut = new Vector3d(vX, vY, vZ);

        var left = new Vector3d(qX, qY, qZ);
        var tmp1 = left.Cross(sut);
        var tmp2 = sut.Multiply(qW);
        tmp1 = tmp1.Add(tmp2);
        tmp2 = left.Cross(tmp1);
        tmp2 = tmp2.Multiply(2F);
        var expected = sut.Add(tmp2);
        
        // When
        var actual = sut.Transform(quaternion);

        // Then
        Assert.Equal(expected.X, actual.X);
        Assert.Equal(expected.Y, actual.Y);
        Assert.Equal(expected.Z, actual.Z);
    }

    [Theory]
    [InlineData(0F, 0F, 0F)]
    [InlineData(1F, 0F, 0F)]
    [InlineData(0F, 1F, 0F)]
    [InlineData(0F, 0F, 1F)]
    [InlineData(1F, 1F, 1F)]
    [InlineData(1F, 2F, 3F)]
    [InlineData(-1F, 0F, 0F)]
    [InlineData(0F, -1F, 0F)]
    [InlineData(0F, 0F, -1F)]
    [InlineData(-1F, -1F, -1F)]
    [InlineData(-1F, -2F, -3F)]
    public void Transforms_vector_using_matrix(float x, float y, float z)
    {
        // Given
        var matrix = new Matrix4d(
             1F,  2F,  3F,  4F,
             5F,  6F,  7F,  8F,
             9F, 10F, 11F, 12F,
            13F, 14F, 15F, 16F);
        
        var sut = new Vector3d(x, y, z);

        var expected = new Vector3d(
            x * matrix.M00 + y * matrix.M10 + z * matrix.M20 + matrix.M30,
            x * matrix.M01 + y * matrix.M11 + z * matrix.M21 + matrix.M31,
            x * matrix.M02 + y * matrix.M12 + z * matrix.M22 + matrix.M32);
        
        // When
        var actual = sut.Transform(matrix);
        
        // Then
        Assert.Equal(expected.X, actual.X);
        Assert.Equal(expected.Y, actual.Y);
        Assert.Equal(expected.Z, actual.Z);
    }
    
    [Fact]
    public void Scales_vector_using_matrix()
    {
        // Given
        var matrix = new Matrix4d(
            2F, 0F, 0F, 0F,
            0F, 2F, 0F, 0F,
            0F, 0F, 2F, 0F,
            0F, 0F, 0F, 1F);
        
        var sut = new Vector3d(2F, 3F, 4F);

        var expected = new Vector3d(4F, 6F, 8F);
        
        // When
        var actual = sut.Transform(matrix);
        
        // Then
        Assert.Equal(expected.X, actual.X);
        Assert.Equal(expected.Y, actual.Y);
        Assert.Equal(expected.Z, actual.Z);
    }
    
    [Fact]
    public void Moves_vector_using_matrix()
    {
        // Given
        var matrix = new Matrix4d(
            1F, 0F, 0F, 0F,
            0F, 1F, 0F, 0F,
            0F, 0F, 1F, 0F,
            2F, 2F, 2F, 1F);
        
        var sut = new Vector3d(1F, 2F, 3F);

        var expected = new Vector3d(3F, 4F, 5F);
        
        // When
        var actual = sut.Transform(matrix);
        
        // Then
        Assert.Equal(expected.X, actual.X);
        Assert.Equal(expected.Y, actual.Y);
        Assert.Equal(expected.Z, actual.Z);
    }
        
    [Theory]
    [InlineData( 0F,  0F,  0F)]
    [InlineData( 1F,  0F,  0F)]
    [InlineData( 0F,  1F,  0F)]
    [InlineData( 0F,  0F,  1F)]
    [InlineData( 1F,  2F,  3F)]
    [InlineData(-1F,  0F,  0F)]
    [InlineData( 0F, -1F,  0F)]
    [InlineData( 0F,  0F, -1F)]
    [InlineData(-1F, -2F, -3F)]
    public void Creates_translation_matrix(float x, float y, float z)
    {
        // Given
        var sut = new Vector3d(x, y, z);
        var expectedRow0 = Vector4d.UnitX;
        var expectedRow1 = Vector4d.UnitY;
        var expectedRow2 = Vector4d.UnitZ;
        var expectedRow3 = new Vector4d(sut.X, sut.Y, sut.Z, 1F);

        // When
        var actual = sut.ToTranslation();

        // Then
        Assert.Equal(expectedRow0.X, actual.M00);
        Assert.Equal(expectedRow0.Y, actual.M01);
        Assert.Equal(expectedRow0.Z, actual.M02);
        Assert.Equal(expectedRow0.W, actual.M03);

        Assert.Equal(expectedRow1.X, actual.M10);
        Assert.Equal(expectedRow1.Y, actual.M11);
        Assert.Equal(expectedRow1.Z, actual.M12);
        Assert.Equal(expectedRow1.W, actual.M13);

        Assert.Equal(expectedRow2.X, actual.M20);
        Assert.Equal(expectedRow2.Y, actual.M21);
        Assert.Equal(expectedRow2.Z, actual.M22);
        Assert.Equal(expectedRow2.W, actual.M23);

        Assert.Equal(expectedRow3.X, actual.M30);
        Assert.Equal(expectedRow3.Y, actual.M31);
        Assert.Equal(expectedRow3.Z, actual.M32);
        Assert.Equal(expectedRow3.W, actual.M33);
    }

    [Theory]
    [InlineData( 0F,  0F,  0F)]
    [InlineData( 1F,  0F,  0F)]
    [InlineData( 0F,  1F,  0F)]
    [InlineData( 0F,  0F,  1F)]
    [InlineData( 1F,  2F,  3F)]
    [InlineData(-1F,  0F,  0F)]
    [InlineData( 0F, -1F,  0F)]
    [InlineData( 0F,  0F, -1F)]
    [InlineData(-1F, -2F, -3F)]
    public void Creates_scale_matrix(float x, float y, float z)
    {
        // Given
        var sut = new Vector3d(x, y, z);
        var expectedRow0 = new Vector4d(sut.X, 0, 0, 0);
        var expectedRow1 = new Vector4d(0, sut.Y, 0, 0);
        var expectedRow2 = new Vector4d(0, 0, sut.Z, 0);
        var expectedRow3 = new Vector4d(0, 0, 0, 1);

        // When
        var actual = sut.ToScale();

        // Then
        Assert.Equal(expectedRow0.X, actual.M00);
        Assert.Equal(expectedRow0.Y, actual.M01);
        Assert.Equal(expectedRow0.Z, actual.M02);
        Assert.Equal(expectedRow0.W, actual.M03);

        Assert.Equal(expectedRow1.X, actual.M10);
        Assert.Equal(expectedRow1.Y, actual.M11);
        Assert.Equal(expectedRow1.Z, actual.M12);
        Assert.Equal(expectedRow1.W, actual.M13);

        Assert.Equal(expectedRow2.X, actual.M20);
        Assert.Equal(expectedRow2.Y, actual.M21);
        Assert.Equal(expectedRow2.Z, actual.M22);
        Assert.Equal(expectedRow2.W, actual.M23);

        Assert.Equal(expectedRow3.X, actual.M30);
        Assert.Equal(expectedRow3.Y, actual.M31);
        Assert.Equal(expectedRow3.Z, actual.M32);
        Assert.Equal(expectedRow3.W, actual.M33);
    }

    [Theory]
    [InlineData( 0F,  0F,  0F)]
    [InlineData( 1F,  0F,  0F)]
    [InlineData( 0F,  1F,  0F)]
    [InlineData( 0F,  0F,  1F)]
    [InlineData( 1F,  2F,  3F)]
    [InlineData(-1F,  0F,  0F)]
    [InlineData( 0F, -1F,  0F)]
    [InlineData( 0F,  0F, -1F)]
    [InlineData(-1F, -2F, -3F)]

    public void Creates_look_at_matrix(float eyeX, float eyeY, float eyeZ)
    {
        // Given
        var sut = new Vector3d(eyeX, eyeY, eyeZ);
        var target = Vector3d.UnitZ;
        var up = Vector3d.UnitY;

        var z = sut.Subtract(target).Normalize();
        var x = up.Cross(z).Normalize();
        var y = z.Cross(x).Normalize();
        
        var expectedRow0 = new Vector4d(x.X, y.X, z.X, 0);
        var expectedRow1 = new Vector4d(x.Y, y.Y, z.Y, 0);
        var expectedRow2 = new Vector4d(x.Z, y.Z, z.Z, 0);
        var expectedRow3 = new Vector4d(-x.Dot(sut), -y.Dot(sut), -z.Dot(sut), 1);

        // When
        var actual = sut.LookAt(target, up);

        // Then
        Assert.Equal(expectedRow0.X, actual.M00);
        Assert.Equal(expectedRow0.Y, actual.M01);
        Assert.Equal(expectedRow0.Z, actual.M02);
        Assert.Equal(expectedRow0.W, actual.M03);

        Assert.Equal(expectedRow1.X, actual.M10);
        Assert.Equal(expectedRow1.Y, actual.M11);
        Assert.Equal(expectedRow1.Z, actual.M12);
        Assert.Equal(expectedRow1.W, actual.M13);

        Assert.Equal(expectedRow2.X, actual.M20);
        Assert.Equal(expectedRow2.Y, actual.M21);
        Assert.Equal(expectedRow2.Z, actual.M22);
        Assert.Equal(expectedRow2.W, actual.M23);

        Assert.Equal(expectedRow3.X, actual.M30);
        Assert.Equal(expectedRow3.Y, actual.M31);
        Assert.Equal(expectedRow3.Z, actual.M32);
        Assert.Equal(expectedRow3.W, actual.M33);
    }
}