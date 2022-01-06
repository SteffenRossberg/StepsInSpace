using Boncuk.Core.Abstractions.Math;
using Xunit;

namespace UnitTests.Boncuk.Core.Abstractions.Math;

public class Vector2dFacts
{
    [Theory]
    [InlineData(1, 2)]
    [InlineData(-1, -2)]
    [InlineData(0, 0)]
    [InlineData(float.MaxValue, float.MaxValue)]
    [InlineData(float.MinValue, float.MinValue)]
    public void Constructs_Vector2d(float x, float y)
    {
        // Given
        
        // When
        var sut = new Vector2d(x, y);
        
        // Then
        Assert.Equal(x, sut.X);
        Assert.Equal(y, sut.Y);
    }
}