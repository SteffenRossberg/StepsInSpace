using StepsInSpace.Core.Abstractions.Collision;
using StepsInSpace.Core.Abstractions.Math;
using StepsInSpace.Core.Abstractions.Math.Extensions;
using Xunit;

namespace UnitTests.StepsInSpace.Core.Abstractions.Collision;

public class PlaneFacts
{
    [Theory]
    [InlineData(1F, 2F, 3F, 4F, 5F, 6F, 7F, 8F, 9F)]
    [InlineData(2F, 3F, 4F, 5F, 6F, 7F, 8F, 9F, 10F)]
    public void Initializes_plane(
        float aX, float aY, float aZ, 
        float bX, float bY, float bZ, 
        float cX, float cY, float cZ)
    {
        // Given
        var a = new Vector3d(aX, aY, aZ);
        var b = new Vector3d(bX, bY, bZ);
        var c = new Vector3d(cX, cY, cZ);
        
        var v0 = b.Subtract(a);
        var v1 = c.Subtract(a);
        var normal = v0.Cross(v1).Normalize();
        var d = normal.Dot(a);
        
        // When
        var sut = new Plane(a, b, c);
        
        // Then
        Assert.Equal(v0.X, sut.V0.X);
        Assert.Equal(v0.Y, sut.V0.Y);
        Assert.Equal(v0.Z, sut.V0.Z);

        Assert.Equal(v1.X, sut.V1.X);
        Assert.Equal(v1.Y, sut.V1.Y);
        Assert.Equal(v1.Z, sut.V1.Z);

        Assert.Equal(normal.X, sut.Normal.X);
        Assert.Equal(normal.Y, sut.Normal.Y);
        Assert.Equal(normal.Z, sut.Normal.Z);
        
        Assert.Equal(d, sut.D);
    }
}