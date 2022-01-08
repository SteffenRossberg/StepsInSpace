using Boncuk.Core.Abstractions.Math.Extensions;
using Xunit;

namespace UnitTests.Boncuk.Core.Abstractions.Math.Extensions;

public class FloatExtensionsFacts
{
    [Theory]
    [InlineData(0F)]
    [InlineData(1F)]
    [InlineData(90F)]
    [InlineData(180F)]
    [InlineData(360F)]
    public void Converts_angle_in_degree_to_radian(float angleInDegree)
    {
        // Given
        var expected = (float)(angleInDegree * System.Math.PI / 180F);
        
        // When
        var actual = angleInDegree.ToRadians();
        
        // Then
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData((float)(0F * System.Math.PI / 180F))]
    [InlineData((float)(1F * System.Math.PI / 180F))]
    [InlineData((float)(90F * System.Math.PI / 180F))]
    [InlineData((float)(180F * System.Math.PI / 180F))]
    [InlineData((float)(360F * System.Math.PI / 180F))]
    public void Converts_angle_in_radians_to_degree(float angleInRadians)
    {
        // Given
        var expected = (float)(angleInRadians * 180F / System.Math.PI);
        
        // When
        var actual = angleInRadians.ToDegree();
        
        // Then
        Assert.Equal(expected, actual);
    }
}