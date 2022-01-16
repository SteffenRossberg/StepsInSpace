using OpenTK.Graphics.OpenGL;
using StepsInSpace.Core.Abstractions.Math;
using StepsInSpace.Core.Abstractions.Math.Extensions;
using Xunit;

namespace UnitTests.StepsInSpace.Core.Abstractions.Math.Extensions;

public class TriangleExtensionsFacts
{
    [Fact]
    public void Transforms_triangle()
    {
        // Given
        var sut = new Triangle(
            new Vector3d(1F, 2F, 3F),
            new Vector3d(4F, 5F, 6F),
            new Vector3d(7F, 8F, 9F),
            new Vector2d(0F, 1F),
            new Vector2d(2F, 3F),
            new Vector2d(4F, 5F)
        );

        var matrix = new Matrix4d(
            1F, 2F, 3F, 4F,
            2F, 3F, 6F, 9F,
            3F, 4F, 7F, 10F,
            4F, 5F, 8F, 11F
        );

        var a = sut.A.Transform(matrix);
        var b = sut.B.Transform(matrix);
        var c = sut.C.Transform(matrix);

        // When
        var actual = sut.Transform(matrix);

        // Then
        Assert.Equal(a.X, actual.A.X);
        Assert.Equal(a.Y, actual.A.Y);
        Assert.Equal(a.Z, actual.A.Z);
        Assert.Equal(b.X, actual.B.X);
        Assert.Equal(b.Y, actual.B.Y);
        Assert.Equal(b.Z, actual.B.Z);
        Assert.Equal(c.X, actual.C.X);
        Assert.Equal(c.Y, actual.C.Y);
        Assert.Equal(c.Z, actual.C.Z);
        Assert.Equal(sut.TextureA.X, actual.TextureA.X);
        Assert.Equal(sut.TextureA.Y, actual.TextureA.Y);
        Assert.Equal(sut.TextureB.X, actual.TextureB.X);
        Assert.Equal(sut.TextureB.Y, actual.TextureB.Y);
        Assert.Equal(sut.TextureC.X, actual.TextureC.X);
        Assert.Equal(sut.TextureC.Y, actual.TextureC.Y);
    }

    [Theory]
    [InlineData(1F, 1F, 0F, 2F, 1F, 0F, 1F, 2F, 0F, 1.1F, 1.1F, 0F, true)]
    [InlineData(1F, 1F, 0F, 2F, 1F, 0F, 1F, 2F, 0F, -1.1F, 1.1F, 0F, false)]
    [InlineData(1F, 1F, 0F, 2F, 1F, 0F, 1F, 2F, 0F, 1.1F, -1.1F, 0F, false)]
    [InlineData(1F, 1F, 0F, 2F, 1F, 0F, 1F, 2F, 0F, -1.1F, -1.1F, 0F, false)]
    public void Checks_if_point_is_inside_or_not(
        float ax, float ay, float az,
        float bx, float by, float bz,
        float cx, float cy, float cz,
        float px, float py, float pz,
        bool expected)
    {
        // Given
        var sut = new Triangle(
            new Vector3d(ax, ay, az),
            new Vector3d(bx, by, bz),
            new Vector3d(cx, cy, cz));

        var point = new Vector3d(px, py, pz);
        
        // When
        var actual = sut.IsPointInside(point);
        
        // Then
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1F, 2F, 3F, 4F, 5F, 6F, 7F, 8F, 9F)]
    [InlineData(-1F, -2F, -3F, -4F, -5F, -6F, -7F, -8F, -9F)]
    [InlineData(9F, 8F, 7F, 6F, 5F, 4F, 3F, 2F, 1F)]
    [InlineData(-9F, -8F, -7F, -6F, -5F, -4F, -3F, -2F, -1F)]
    public void Returns_coordinates_array(
        float ax, float ay, float az,
        float bx, float by, float bz,
        float cx, float cy, float cz)
    {
        // Given
        var sut = new Triangle(
            new Vector3d(ax, ay, az),
            new Vector3d(bx, by, bz),
            new Vector3d(cx, cy, cz));
        var expected = new[]
        {
            ax, ay, az,
            bx, by, bz,
            cx, cy, cz
        };
        
        // When
        var actual = sut.ToArray();
        
        // Then
        Assert.Equal(expected, actual);
    }
}