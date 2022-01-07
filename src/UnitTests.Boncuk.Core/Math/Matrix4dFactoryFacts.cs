using System;
using Boncuk.Core.Abstractions.Math;
using Boncuk.Core.Math;
using Xunit;

namespace UnitTests.Boncuk.Core.Math;

public class Matrix4dFactoryFacts
{
    private readonly Func<Matrix4dFactory> _createMatrix4dFactory;

    public Matrix4dFactoryFacts()
    {
        _createMatrix4dFactory = () => new Matrix4dFactory();
    }
    
    [Fact]
    public void Creates_from_floats()
    {
        // Given
        var sut = _createMatrix4dFactory();
        
        // When
        var actual = sut.Create(
            1,  2,  3,  4,
            5,  6,  7,  8,
            9, 10, 11, 12,
            13, 14, 15, 16);
        
        // Then
        Assert.Equal(01F, actual.M00);
        Assert.Equal(02F, actual.M01);
        Assert.Equal(03F, actual.M02);
        Assert.Equal(04F, actual.M03);

        Assert.Equal(05F, actual.M10);
        Assert.Equal(06F, actual.M11);
        Assert.Equal(07F, actual.M12);
        Assert.Equal(08F, actual.M13);

        Assert.Equal(09F, actual.M20);
        Assert.Equal(10F, actual.M21);
        Assert.Equal(11F, actual.M22);
        Assert.Equal(12F, actual.M23);

        Assert.Equal(13F, actual.M30);
        Assert.Equal(14F, actual.M31);
        Assert.Equal(15F, actual.M32);
        Assert.Equal(16F, actual.M33);
    }

    [Fact]
    public void Creates_from_vector4d()
    {
        // Given
        var sut = _createMatrix4dFactory();
        var row0 = new Vector4d(01, 02, 03, 04);
        var row1 = new Vector4d(05, 06, 07, 08);
        var row2 = new Vector4d(09, 10, 11, 12);
        var row3 = new Vector4d(13, 14, 15, 16);

        // When
        var actual = sut.Create(row0, row1, row2, row3);

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

    [Fact]
    public void Creates_from_quaternion()
    {
        // Given
        var sut = _createMatrix4dFactory();
        var row0 = new Quaternion(01, 02, 03, 04);
        var row1 = new Quaternion(05, 06, 07, 08);
        var row2 = new Quaternion(09, 10, 11, 12);
        var row3 = new Quaternion(13, 14, 15, 16);

        // When
        var actual = sut.Create(row0, row1, row2, row3);

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
    
    [Fact]
    public void Creates_translation_matrix()
    {
        // Given
        var sut = _createMatrix4dFactory();
        var direction = new Vector3d(2, 3, 4);
        var expectedRow0 = Vector4d.UnitX;
        var expectedRow1 = Vector4d.UnitY;
        var expectedRow2 = Vector4d.UnitZ;
        var expectedRow3 = new Vector4d(direction.X, direction.Y, direction.Z, 1);

        // When
        var actual = sut.CreateTranslation(direction);

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