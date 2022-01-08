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
    
    [Fact]
    public void Returns_unit_x()
    {
        // Given
        
        // When
        var sut = Vector3d.UnitX;
        
        // Then
        Assert.Equal(1.0F, sut.X);
        Assert.Equal(0.0F, sut.Y);
        Assert.Equal(0.0F, sut.Z);
    }

    [Fact]
    public void Returns_unit_y()
    {
        // Given
        
        // When
        var sut = Vector3d.UnitY;
        
        // Then
        Assert.Equal(0.0F, sut.X);
        Assert.Equal(1.0F, sut.Y);
        Assert.Equal(0.0F, sut.Z);
    }
    
    [Fact]
    public void Returns_unit_z()
    {
        // Given
        
        // When
        var sut = Vector3d.UnitZ;
        
        // Then
        Assert.Equal(0.0F, sut.X);
        Assert.Equal(0.0F, sut.Y);
        Assert.Equal(1.0F, sut.Z);
    }
        
    [Fact]
    public void Returns_zero()
    {
        // Given
        
        // When
        var sut = Vector3d.Zero;
        
        // Then
        Assert.Equal(0.0F, sut.X);
        Assert.Equal(0.0F, sut.Y);
        Assert.Equal(0.0F, sut.Z);
    }    
    [Fact]
    public void Returns_one()
    {
        // Given
        
        // When
        var sut = Vector3d.One;
        
        // Then
        Assert.Equal(1.0F, sut.X);
        Assert.Equal(1.0F, sut.Y);
        Assert.Equal(1.0F, sut.Z);
    }
}