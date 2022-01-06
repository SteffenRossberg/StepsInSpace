using Boncuk.Core.Abstractions.Math;
using Xunit;

namespace UnitTests.Boncuk.Core.Abstractions.Math;

public class Matrix4dFacts
{
    [Fact]
    public void Inits_matrix_using_floats()
    {
        // Given
        
        // When
        var actual = new Matrix4d(
             1,  2,  3,  4,
             5,  6,  7,  8,
             9, 10, 11, 12,
            13, 14, 15, 16);
        
        // Then
        Assert.Equal(1F, actual.M00);
        Assert.Equal(2F, actual.M01);
        Assert.Equal(3F, actual.M02);
        Assert.Equal(4F, actual.M03);

        Assert.Equal(5F, actual.M10);
        Assert.Equal(6F, actual.M11);
        Assert.Equal(7F, actual.M12);
        Assert.Equal(8F, actual.M13);

        Assert.Equal(9F, actual.M20);
        Assert.Equal(10F, actual.M21);
        Assert.Equal(11F, actual.M22);
        Assert.Equal(12F, actual.M23);

        Assert.Equal(13F, actual.M30);
        Assert.Equal(14F, actual.M31);
        Assert.Equal(15F, actual.M32);
        Assert.Equal(16F, actual.M33);
    }
    
    [Fact]
    public void Inits_matrix_using_vector4d()
    {
        // Given
        
        // When
        var actual = new Matrix4d(
            new Vector4d(10, 20, 30, 40),
            new Vector4d(50, 60, 70, 80),
            new Vector4d(90, 100, 110, 120),
            new Vector4d(130, 140, 150, 160));
        
        // Then
        Assert.Equal(10F, actual.M00);
        Assert.Equal(20F, actual.M01);
        Assert.Equal(30F, actual.M02);
        Assert.Equal(40F, actual.M03);

        Assert.Equal(50F, actual.M10);
        Assert.Equal(60F, actual.M11);
        Assert.Equal(70F, actual.M12);
        Assert.Equal(80F, actual.M13);

        Assert.Equal(90F, actual.M20);
        Assert.Equal(100F, actual.M21);
        Assert.Equal(110F, actual.M22);
        Assert.Equal(120F, actual.M23);

        Assert.Equal(130F, actual.M30);
        Assert.Equal(140F, actual.M31);
        Assert.Equal(150F, actual.M32);
        Assert.Equal(160F, actual.M33);
    }
    
    [Fact]
    public void Returns_row0()
    {
        // Given
        var row0 = new Vector4d(100, 200, 300, 400);
        var row1 = new Vector4d(500, 600, 700, 800);
        var row2 = new Vector4d(900, 1000, 1100, 1200);
        var row3 = new Vector4d(1300, 1400, 1500, 1600);
        var sut = new Matrix4d(row0, row1, row2, row3);
        
        // When
        var actual = sut.Row0;
        
        // Then
        Assert.Equal(row0.X, actual.X);
        Assert.Equal(row0.Y, actual.Y);
        Assert.Equal(row0.Z, actual.Z);
        Assert.Equal(row0.W, actual.W);
    }
    
    [Fact]
    public void Returns_row1()
    {
        // Given
        var row0 = new Vector4d(100, 200, 300, 400);
        var row1 = new Vector4d(500, 600, 700, 800);
        var row2 = new Vector4d(900, 1000, 1100, 1200);
        var row3 = new Vector4d(1300, 1400, 1500, 1600);
        var sut = new Matrix4d(row0, row1, row2, row3);
        
        // When
        var actual = sut.Row1;
        
        // Then
        Assert.Equal(row1.X, actual.X);
        Assert.Equal(row1.Y, actual.Y);
        Assert.Equal(row1.Z, actual.Z);
        Assert.Equal(row1.W, actual.W);
    }
    
    [Fact]
    public void Returns_row2()
    {
        // Given
        var row0 = new Vector4d(100, 200, 300, 400);
        var row1 = new Vector4d(500, 600, 700, 800);
        var row2 = new Vector4d(900, 1000, 1100, 1200);
        var row3 = new Vector4d(1300, 1400, 1500, 1600);
        var sut = new Matrix4d(row0, row1, row2, row3);
        
        // When
        var actual = sut.Row2;
        
        // Then
        Assert.Equal(row2.X, actual.X);
        Assert.Equal(row2.Y, actual.Y);
        Assert.Equal(row2.Z, actual.Z);
        Assert.Equal(row2.W, actual.W);
    }
    
    [Fact]
    public void Returns_row3()
    {
        // Given
        var row0 = new Vector4d(100, 200, 300, 400);
        var row1 = new Vector4d(500, 600, 700, 800);
        var row2 = new Vector4d(900, 1000, 1100, 1200);
        var row3 = new Vector4d(1300, 1400, 1500, 1600);
        var sut = new Matrix4d(row0, row1, row2, row3);
        
        // When
        var actual = sut.Row3;
        
        // Then
        Assert.Equal(row3.X, actual.X);
        Assert.Equal(row3.Y, actual.Y);
        Assert.Equal(row3.Z, actual.Z);
        Assert.Equal(row3.W, actual.W);
    }
        
    [Fact]
    public void Returns_column0()
    {
        // Given
        var row0 = new Vector4d(100, 200, 300, 400);
        var row1 = new Vector4d(500, 600, 700, 800);
        var row2 = new Vector4d(900, 1000, 1100, 1200);
        var row3 = new Vector4d(1300, 1400, 1500, 1600);
        var sut = new Matrix4d(row0, row1, row2, row3);
        
        // When
        var actual = sut.Column0;
        
        // Then
        Assert.Equal(row0.X, actual.X);
        Assert.Equal(row1.X, actual.Y);
        Assert.Equal(row2.X, actual.Z);
        Assert.Equal(row3.X, actual.W);
    }
        
    [Fact]
    public void Returns_column1()
    {
        // Given
        var row0 = new Vector4d(100, 200, 300, 400);
        var row1 = new Vector4d(500, 600, 700, 800);
        var row2 = new Vector4d(900, 1000, 1100, 1200);
        var row3 = new Vector4d(1300, 1400, 1500, 1600);
        var sut = new Matrix4d(row0, row1, row2, row3);
        
        // When
        var actual = sut.Column1;
        
        // Then
        Assert.Equal(row0.Y, actual.X);
        Assert.Equal(row1.Y, actual.Y);
        Assert.Equal(row2.Y, actual.Z);
        Assert.Equal(row3.Y, actual.W);
    }
        
    [Fact]
    public void Returns_column2()
    {
        // Given
        var row0 = new Vector4d(100, 200, 300, 400);
        var row1 = new Vector4d(500, 600, 700, 800);
        var row2 = new Vector4d(900, 1000, 1100, 1200);
        var row3 = new Vector4d(1300, 1400, 1500, 1600);
        var sut = new Matrix4d(row0, row1, row2, row3);
        
        // When
        var actual = sut.Column2;
        
        // Then
        Assert.Equal(row0.Z, actual.X);
        Assert.Equal(row1.Z, actual.Y);
        Assert.Equal(row2.Z, actual.Z);
        Assert.Equal(row3.Z, actual.W);
    }
        
    [Fact]
    public void Returns_column3()
    {
        // Given
        var row0 = new Vector4d(100, 200, 300, 400);
        var row1 = new Vector4d(500, 600, 700, 800);
        var row2 = new Vector4d(900, 1000, 1100, 1200);
        var row3 = new Vector4d(1300, 1400, 1500, 1600);
        var sut = new Matrix4d(row0, row1, row2, row3);
        
        // When
        var actual = sut.Column3;
        
        // Then
        Assert.Equal(row0.W, actual.X);
        Assert.Equal(row1.W, actual.Y);
        Assert.Equal(row2.W, actual.Z);
        Assert.Equal(row3.W, actual.W);
    }
        
    [Fact]
    public void Returns_identity()
    {
        // Given
        
        // When
        var actual = Matrix4d.Identity;
        
        // Then
        Assert.Equal(1F, actual.M00);
        Assert.Equal(0F, actual.M01);
        Assert.Equal(0F, actual.M02);
        Assert.Equal(0F, actual.M03);

        Assert.Equal(0F, actual.M10);
        Assert.Equal(1F, actual.M11);
        Assert.Equal(0F, actual.M12);
        Assert.Equal(0F, actual.M13);

        Assert.Equal(0F, actual.M20);
        Assert.Equal(0F, actual.M21);
        Assert.Equal(1F, actual.M22);
        Assert.Equal(0F, actual.M23);

        Assert.Equal(0F, actual.M30);
        Assert.Equal(0F, actual.M31);
        Assert.Equal(0F, actual.M32);
        Assert.Equal(1F, actual.M33);
    }

}