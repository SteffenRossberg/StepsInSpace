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

    [Theory]
    [InlineData(0F, 0F, 0F,  0F, 1F, 0F,  0F, 0F, 1F,  -1F, 0F,  0F,  0F, 1F, 1F, false)]
    [InlineData(0F, 0F, 0F,  1F, 0F, 0F,  0F, 1F, 0F,   0F, 0F, -1F,  1F, 1F, 0F, false)]
    [InlineData(0F, 0F, 0F,  1F, 0F, 0F,  0F, 1F, 0F,   0F, 0F, -1F,  0F, 0F, 1F, true)]
    [InlineData(0F, 0F, 0F,  0F, 1F, 0F,  0F, 0F, 1F,  -1F, 0F,  0F,  1F, 0F, 0F, true)]
    public void Ray_intersects_plane(
        float aX, float aY, float aZ,
        float bX, float bY, float bZ,
        float cX, float cY, float cZ,
        float originX, float originY, float originZ,
        float directionX, float directionY, float directionZ,
        bool expected)
    {
        // Given
        var ray = new Ray(
            new Vector3d(originX, originY, originZ),
            new Vector3d(directionX, directionY, directionZ));

        var plane = new Plane(
            new Vector3d(aX, aY, aZ),
            new Vector3d(bX, bY, bZ),
            new Vector3d(cX, cY, cZ));
        
        // When
        var actual = ray.Intersects(plane);
            
        // Then
        Assert.Equal(expected, actual);
        
        // When
        actual = plane.Intersects(ray);
            
        // Then
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0F, 0F, 0F,  0F, 1F, 0F,  0F, 0F, 1F,  -2F, 0F,  0F,  1F, false)]
    [InlineData(0F, 0F, 0F,  1F, 0F, 0F,  0F, 1F, 0F,   0F, 0F, -2F,  1F, false)]
    [InlineData(0F, 0F, 0F,  0F, 1F, 0F,  0F, 0F, 1F,  -2F, 0F,  0F,  2F, true)]
    [InlineData(0F, 0F, 0F,  1F, 0F, 0F,  0F, 1F, 0F,   0F, 0F, -2F,  2F, true)]
    [InlineData(0F, 0F, 0F,  0F, 1F, 0F,  0F, 0F, 1F,  -2F, 0F,  0F,  3F, true)]
    [InlineData(0F, 0F, 0F,  1F, 0F, 0F,  0F, 1F, 0F,   0F, 0F, -2F,  3F, true)]
    public void Bounding_sphere_intersects_plane(
        float aX, float aY, float aZ,
        float bX, float bY, float bZ,
        float cX, float cY, float cZ,
        float centerX, float centerY, float centerZ,float radius,
        bool expected)
    {
        // Given
        var sphere = new BoundingSphere(
            new Vector3d(centerX, centerY, centerZ),
            radius);

        var plane = new Plane(
            new Vector3d(aX, aY, aZ),
            new Vector3d(bX, bY, bZ),
            new Vector3d(cX, cY, cZ));
        
        // When
        var actual = sphere.Intersects(plane);
            
        // Then
        Assert.Equal(expected, actual);
        
        // When
        actual = plane.Intersects(sphere);
            
        // Then
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData(0F, 0F, 0F, 1F,  3F, 0F, 0F, 1F, false)]
    [InlineData(0F, 0F, 0F, 1F,  2F, 0F, 0F, 1F, true)]
    [InlineData(0F, 0F, 0F, 0.1F,  0.2F, 0F, 0F, 0.1F, true)]
    [InlineData(0F, 0F, 0F, 1F,  1F, 0F, 0F, 1F, true)]
    public void Bounding_sphere_intersects_other_bounding_sphere(
        float centerX1, float centerY1, float centerZ1,float radius1,
        float centerX2, float centerY2, float centerZ2,float radius2,
        bool expected)
    {
        // Given
        var sut = new BoundingSphere(
            new Vector3d(centerX1, centerY1, centerZ1),
            radius1);

        var other = new BoundingSphere(
            new Vector3d(centerX2, centerY2, centerZ2),
            radius2);
        
        // When
        var actual = sut.Intersects(other);
            
        // Then
        Assert.Equal(expected, actual);
        
        // When
        actual = other.Intersects(sut);
            
        // Then
        Assert.Equal(expected, actual);
    }
}