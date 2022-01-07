using Boncuk.Core.Abstractions.Collision;
using Boncuk.Core.Abstractions.Collision.Extensions;
using Boncuk.Core.Abstractions.Math;
using Xunit;

namespace UnitTests.Boncuk.Core.Abstractions.Collision.Extensions;

public class CollisionExtensionsFacts
{
    [Theory]
    [InlineData(1F, 2F, 3F,  4F, 5F, 6F,  7F, -5F, -7F, -1F, false)]
    [InlineData(1F, 2F, 3F,  4F, 5F, 6F,  5F, 7F, 9F,  1F, true)]
    [InlineData(1F, 0F, 0F,  4F, 0F, 0F,  1F, 2F, 0F, 2F, true)]
    [InlineData(1F, 0F, 0F,  4F, 0F, 0F,  4F, 0F, 0F, 1F, true)]
    [InlineData(0F, 1F, 0F,  0F, 4F, 0F,  0F, 1F, 2F, 2F, true)]
    [InlineData(0F, 1F, 0F,  0F, 4F, 0F,  0F, 4F, 0F, 1F, true)]
    public void Ray_intersects_sphere(
        float originX, float originY, float originZ,
        float directionX, float directionY, float directionZ,
        float centerX, float centerY, float centerZ, float radius,
        bool expected)
    {
        // Given
        var ray = new Ray(
            new Vector3d(originX, originY, originZ),
            new Vector3d(directionX, directionY, directionZ));

        var sphere = new BoundingSphere(
            new Vector3d(centerX, centerY, centerZ),
            radius);
        
        // When
        var actual = ray.Intersects(sphere);
            
        // Then
        Assert.Equal(expected, actual);
        
        // When
        actual = sphere.Intersects(ray);
            
        // Then
        Assert.Equal(expected, actual);
    }
}