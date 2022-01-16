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
        var actual = sut.ToVertexArray();
        
        // Then
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Converts_to_vertex_array()
    {
        // Given
        var triangle1 = new Triangle(
            new Vector3d(-1F, 2F, 3F),
            new Vector3d(4F, -5F, 6F),
            new Vector3d(7F, 8F, -9F));
        var triangle2 = new Triangle(
            new Vector3d(1F, 2F, -3F),
            new Vector3d(-4F, 5F, 6F),
            new Vector3d(7F, -8F, 9F));
        var triangle3 = new Triangle(
            new Vector3d(1F, -2F, 3F),
            new Vector3d(4F, 5F, -6F),
            new Vector3d(-7F, 8F, 9F));
        var expected = new[]
        {
            triangle1.A.X, triangle1.A.Y, triangle1.A.Z,
            triangle1.B.X, triangle1.B.Y, triangle1.B.Z,
            triangle1.C.X, triangle1.C.Y, triangle1.C.Z,
            triangle2.A.X, triangle2.A.Y, triangle2.A.Z,
            triangle2.B.X, triangle2.B.Y, triangle2.B.Z,
            triangle2.C.X, triangle2.C.Y, triangle2.C.Z,
            triangle3.A.X, triangle3.A.Y, triangle3.A.Z,
            triangle3.B.X, triangle3.B.Y, triangle3.B.Z,
            triangle3.C.X, triangle3.C.Y, triangle3.C.Z,
        };
        var sut = new[]
        {
            triangle1,
            triangle2,
            triangle3,
        };
        
        // When
        var actual = sut.ToVertexArray();
        
        // Then
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void Converts_to_vertex_uv_array()
    {
        // Given
        var sut = new Triangle(
            new Vector3d(-1F, 2F, 3F),
            new Vector3d(4F, -5F, 6F),
            new Vector3d(7F, 8F, -9F),
            new Vector2d(0F, 0F),
            new Vector2d(1F, 0F),
            new Vector2d(0F, 1F));
        var expected = new[]
        {
            sut.TextureA.X, sut.TextureA.Y,
            sut.TextureB.X, sut.TextureB.Y,
            sut.TextureC.X, sut.TextureC.Y,
        };
        
        // When
        var actual = sut.ToTextureArray();
        
        // Then
        Assert.Equal(expected, actual);
    }
   
    [Fact]
    public void Converts_to_texture_uv_array()
    {
        // Given
        var triangle1 = new Triangle(
            new Vector3d(-1F, 2F, 3F),
            new Vector3d(4F, -5F, 6F),
            new Vector3d(7F, 8F, -9F),
            new Vector2d(0F, 0F),
            new Vector2d(1F, 0F),
            new Vector2d(0F, 1F));
        var triangle2 = new Triangle(
            new Vector3d(1F, 2F, -3F),
            new Vector3d(-4F, 5F, 6F),
            new Vector3d(7F, -8F, 9F),
            new Vector2d(1F, 1F),
            new Vector2d(1F, 0F),
            new Vector2d(0F, 1F));
        var triangle3 = new Triangle(
            new Vector3d(1F, -2F, 3F),
            new Vector3d(4F, 5F, -6F),
            new Vector3d(-7F, 8F, 9F),
            new Vector2d(0F, 1F),
            new Vector2d(1F, 0F),
            new Vector2d(1F, 1F));
        var expected = new[]
        {
            triangle1.TextureA.X, triangle1.TextureA.Y,
            triangle1.TextureB.X, triangle1.TextureB.Y,
            triangle1.TextureC.X, triangle1.TextureC.Y,
            triangle2.TextureA.X, triangle2.TextureA.Y,
            triangle2.TextureB.X, triangle2.TextureB.Y,
            triangle2.TextureC.X, triangle2.TextureC.Y,
            triangle3.TextureA.X, triangle3.TextureA.Y,
            triangle3.TextureB.X, triangle3.TextureB.Y,
            triangle3.TextureC.X, triangle3.TextureC.Y,
        };
        var sut = new[]
        {
            triangle1,
            triangle2,
            triangle3,
        };
        
        // When
        var actual = sut.ToTextureArray();
        
        // Then
        Assert.Equal(expected, actual);
    }
}