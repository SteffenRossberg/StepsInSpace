using StepsInSpace.Core.Abstractions.Collision;
using StepsInSpace.Core.Abstractions.Math;
using Xunit;

namespace UnitTests.StepsInSpace.Core.Abstractions.Math;

public class TriangleFacts
{
    [Theory]
    [InlineData(1F, 2F, 3F, 4F, 5F, 6F, 7F, 8F, 9F, 10F, 11F, 12F, 13F, 14F, 15F)]
    [InlineData(-1F, -2F, -3F, -4F, -5F, -6F, -7F, -8F, -9F, -10F, -11F, -12F, -13F, -14F, -15F)]
    [InlineData(15F, 14F, 13F, 12F, 11F, 10F, 9F, 8F, 7F, 6F, 5F, 4F, 3F, 2F, 1F)]
    [InlineData(-15F, -14F, -13F, -12F, -11F, -10F, -9F, -8F, -7F, -6F, -5F, -4F, -3F, -2F, -1F)]
    public void Initializes_triangle(
        float aX, float aY, float aZ,
        float bX, float bY, float bZ,
        float cX, float cY, float cZ,
        float taX, float taY,
        float tbX, float tbY,
        float tcX, float tcY)
    {
        // Given
        var a = new Vector3d(aX, aY, aZ);
        var b = new Vector3d(bX, bY, bZ);
        var c = new Vector3d(cX, cY, cZ);
        var plane = new Plane(a, b, c);
        var textureA = new Vector2d(taX, taY);
        var textureB = new Vector2d(tbX, tbY);
        var textureC = new Vector2d(tcX, tcY);
        
        // When
        var sut = new Triangle(a, b, c, textureA, textureB, textureC);
        
        // Then
        Assert.Equal(a.X, sut.A.X);
        Assert.Equal(a.Y, sut.A.Y);
        Assert.Equal(a.Z, sut.A.Z);
        Assert.Equal(b.X, sut.B.X);
        Assert.Equal(b.Y, sut.B.Y);
        Assert.Equal(b.Z, sut.B.Z);
        Assert.Equal(c.X, sut.C.X);
        Assert.Equal(c.Y, sut.C.Y);
        Assert.Equal(c.Z, sut.C.Z);
        
        Assert.Equal(textureA.X, sut.TextureA.X);
        Assert.Equal(textureA.Y, sut.TextureA.Y);
        Assert.Equal(textureB.X, sut.TextureB.X);
        Assert.Equal(textureB.Y, sut.TextureB.Y);
        Assert.Equal(textureC.X, sut.TextureC.X);
        Assert.Equal(textureC.Y, sut.TextureC.Y);
        
        Assert.Equal(plane.D, sut.Plane.D);
        Assert.Equal(plane.Normal.X, sut.Plane.Normal.X);
        Assert.Equal(plane.Normal.Y, sut.Plane.Normal.Y);
        Assert.Equal(plane.Normal.Z, sut.Plane.Normal.Z);
        Assert.Equal(plane.V0.X, sut.Plane.V0.X);
        Assert.Equal(plane.V0.Y, sut.Plane.V0.Y);
        Assert.Equal(plane.V0.Z, sut.Plane.V0.Z);
        Assert.Equal(plane.V1.X, sut.Plane.V1.X);
        Assert.Equal(plane.V1.Y, sut.Plane.V1.Y);
        Assert.Equal(plane.V1.Z, sut.Plane.V1.Z);
    }

    [Theory]
    [InlineData(1F, 2F, 3F, 4F, 5F, 6F, 7F, 8F, 9F)]
    [InlineData(-1F, -2F, -3F, -4F, -5F, -6F, -7F, -8F, -9F)]
    [InlineData(15F, 14F, 13F, 12F, 11F, 10F, 9F, 8F, 7F)]
    [InlineData(-15F, -14F, -13F, -12F, -11F, -10F, -9F, -8F, -7F)]
    public void Initializes_triangle_with_vector3d_only(
        float aX, float aY, float aZ,
        float bX, float bY, float bZ,
        float cX, float cY, float cZ)
    {
        // Given
        var a = new Vector3d(aX, aY, aZ);
        var b = new Vector3d(bX, bY, bZ);
        var c = new Vector3d(cX, cY, cZ);
        var plane = new Plane(a, b, c);
        var textureA = Vector2d.Zero;
        var textureB = Vector2d.Zero;
        var textureC = Vector2d.Zero;
        
        // When
        var sut = new Triangle(a, b, c, textureA, textureB, textureC);
        
        // Then
        Assert.Equal(a.X, sut.A.X);
        Assert.Equal(a.Y, sut.A.Y);
        Assert.Equal(a.Z, sut.A.Z);
        Assert.Equal(b.X, sut.B.X);
        Assert.Equal(b.Y, sut.B.Y);
        Assert.Equal(b.Z, sut.B.Z);
        Assert.Equal(c.X, sut.C.X);
        Assert.Equal(c.Y, sut.C.Y);
        Assert.Equal(c.Z, sut.C.Z);
        
        Assert.Equal(textureA.X, sut.TextureA.X);
        Assert.Equal(textureA.Y, sut.TextureA.Y);
        Assert.Equal(textureB.X, sut.TextureB.X);
        Assert.Equal(textureB.Y, sut.TextureB.Y);
        Assert.Equal(textureC.X, sut.TextureC.X);
        Assert.Equal(textureC.Y, sut.TextureC.Y);
        
        Assert.Equal(plane.D, sut.Plane.D);
        Assert.Equal(plane.Normal.X, sut.Plane.Normal.X);
        Assert.Equal(plane.Normal.Y, sut.Plane.Normal.Y);
        Assert.Equal(plane.Normal.Z, sut.Plane.Normal.Z);
        Assert.Equal(plane.V0.X, sut.Plane.V0.X);
        Assert.Equal(plane.V0.Y, sut.Plane.V0.Y);
        Assert.Equal(plane.V0.Z, sut.Plane.V0.Z);
        Assert.Equal(plane.V1.X, sut.Plane.V1.X);
        Assert.Equal(plane.V1.Y, sut.Plane.V1.Y);
        Assert.Equal(plane.V1.Z, sut.Plane.V1.Z);
    }
}