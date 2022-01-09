using StepsInSpace.Core.Abstractions.Collision;
using StepsInSpace.Core.Abstractions.Math;
using Xunit;

namespace UnitTests.StepsInSpace.Core.Abstractions.Collision;

public class BoundingSphereFacts
{
    [Theory]
    [InlineData(1F, 2F, 3F, 4F)]
    [InlineData(2F, 3F, 4F, 5F)]
    public void Initializes_bounding_sphere(float centerX, float centerY, float centerZ, float radius)
    {
        // Given
        var center = new Vector3d(centerX, centerY, centerZ);
        var squaredRadius = radius * radius;
        
        // When
        var sut = new BoundingSphere(center, radius);
        
        // Then
        Assert.Equal(centerX, sut.Center.X);
        Assert.Equal(centerY, sut.Center.Y);
        Assert.Equal(centerZ, sut.Center.Z);
        Assert.Equal(radius, sut.Radius);
        Assert.Equal(squaredRadius, sut.SquaredRadius);
    }
}