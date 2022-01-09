using StepsInSpace.Core.Abstractions.Collision;
using StepsInSpace.Core.Abstractions.Math;
using Xunit;

namespace UnitTests.StepsInSpace.Core.Abstractions.Collision;

public class IntersectionFacts
{
    [Theory]
    [InlineData(1F, 2F, 3F, 4F, 5F, 6F)]
    [InlineData(2F, 3F, 4F, 5F, 6F, 7F)]
    public void Initializes_intersection(
        float directionX, float directionY, float directionZ,
        float hitX, float hitY, float hitZ
        )
    {
        // Given
        var direction = new Vector3d(directionX, directionY, directionZ);
        var hit = new Vector3d(hitX, hitY, hitZ);
        
        
        // When
        var sut = new Intersection(direction, hit);
        
        // Then
        Assert.Equal(directionX, sut.Direction.X);
        Assert.Equal(directionY, sut.Direction.Y);
        Assert.Equal(directionZ, sut.Direction.Z);
        
        Assert.Equal(hitX, sut.Hit.X);
        Assert.Equal(hitY, sut.Hit.Y);
        Assert.Equal(hitZ, sut.Hit.Z);
    }
}