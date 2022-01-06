using Boncuk.Core.Abstractions.Math;
using Xunit;

namespace UnitTests.Boncuk.Core.Abstractions;

public class Vector4dFacts
{
    [Theory]
    [InlineData(1, 2, 3, 4)]
    [InlineData(-1, -2, -3, -4)]
    [InlineData(0, 0, 0, 0)]
    [InlineData(float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue)]
    [InlineData(float.MinValue, float.MinValue, float.MinValue, float.MinValue)]
    public void Constructs_Vector4d(float x, float y, float z, float w)
    {
        // Given
        
        // When
        var sut = new Vector4d(x, y, z, w);
        
        // Then
        Assert.Equal(x, sut.X);
        Assert.Equal(y, sut.Y);
        Assert.Equal(z, sut.Z);
        Assert.Equal(w, sut.W);
    }
}