using Boncuk.Core.Abstractions.Math;
using Boncuk.Core.Abstractions.Math.Extensions;
using Xunit;

namespace UnitTests.Boncuk.Core.Abstractions.Math.Extensions;

public class Matrix4dExtensionsFacts
{
    [Fact]
    public void Multiplies_matrices()
    {
        // Given
        var sut = new Matrix4d(
            01, 02, 03, 04,
            05, 06, 07, 08,
            09, 10, 11, 12,
            13, 14, 15, 16);
        
        var right = new Matrix4d(
            17, 18, 19, 20,
            21, 22, 23, 24,
            25, 26, 27, 28,
            29, 30, 31, 32);
        
        var row0 = sut.Row0;
        var row1 = sut.Row1;
        var row2 = sut.Row2;
        var row3 = sut.Row3;

        var column0 = right.Column0;
        var column1 = right.Column1;
        var column2 = right.Column2;
        var column3 = right.Column3;
        
        // When
        var actual = sut.Multiply(right);
        
        // Then
        Assert.Equal(row0.Dot(column0), actual.M00);
        Assert.Equal(row0.Dot(column1), actual.M01);
        Assert.Equal(row0.Dot(column2), actual.M02);
        Assert.Equal(row0.Dot(column3), actual.M03);

        Assert.Equal(row1.Dot(column0), actual.M10);
        Assert.Equal(row1.Dot(column1), actual.M11);
        Assert.Equal(row1.Dot(column2), actual.M12);
        Assert.Equal(row1.Dot(column3), actual.M13);

        Assert.Equal(row2.Dot(column0), actual.M20);
        Assert.Equal(row2.Dot(column1), actual.M21);
        Assert.Equal(row2.Dot(column2), actual.M22);
        Assert.Equal(row2.Dot(column3), actual.M23);

        Assert.Equal(row3.Dot(column0), actual.M30);
        Assert.Equal(row3.Dot(column1), actual.M31);
        Assert.Equal(row3.Dot(column2), actual.M32);
        Assert.Equal(row3.Dot(column3), actual.M33);
    }
}