using Boncuk.Core.Abstractions.Math;
using Xunit;

namespace UnitTests.Boncuk.Core.Abstractions.Math;

public class Vector3dFacts
{
    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(-1, -2, -3)]
    [InlineData(0, 0, 0)]
    [InlineData(float.MaxValue, float.MaxValue, float.MaxValue)]
    [InlineData(float.MinValue, float.MinValue, float.MinValue)]
    public void Constructs_Vector3d(float x, float y, float z)
    {
        // Given
        
        // When
        var sut = new Vector3d(x, y, z);
        
        // Then
        Assert.Equal(x, sut.X);
        Assert.Equal(y, sut.Y);
        Assert.Equal(z, sut.Z);
    }
}