using Boncuk.Core.Abstractions.Collision;
using Boncuk.Core.Abstractions.Math;
using Xunit;

namespace UnitTests.Boncuk.Core.Abstractions.Collision;

public class RayFacts
{
    [Theory]
    [InlineData(1F, 2F, 3F, 4F, 5F, 6F)]
    [InlineData(2F, 3F, 4F, 5F, 6F, 7F)]
    public void Initializes_bounding_sphere(
        float originX, float originY, float originZ, 
        float directionX, float directionY, float directionZ)
    {
        // Given
        var origin = new Vector3d(originX, originY, originZ);
        var direction = new Vector3d(directionX, directionY, directionZ);
        
        
        // When
        var sut = new Ray(origin, direction);
        
        // Then
        Assert.Equal(originX, sut.Origin.X);
        Assert.Equal(originY, sut.Origin.Y);
        Assert.Equal(originZ, sut.Origin.Z);

        Assert.Equal(directionX, sut.Direction.X);
        Assert.Equal(directionY, sut.Direction.Y);
        Assert.Equal(directionZ, sut.Direction.Z);
    }
}