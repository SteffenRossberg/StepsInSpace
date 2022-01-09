using StepsInSpace.Core.Abstractions.Math;
using Xunit;

namespace UnitTests.StepsInSpace.Core.Abstractions.Math;

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
        
    [Fact]
    public void Returns_unit_x()
    {
        // Given
        
        // When
        var sut = Vector4d.UnitX;
        
        // Then
        Assert.Equal(1.0F, sut.X);
        Assert.Equal(0.0F, sut.Y);
        Assert.Equal(0.0F, sut.Z);
        Assert.Equal(0.0F, sut.W);
    }

    [Fact]
    public void Returns_unit_y()
    {
        // Given
        
        // When
        var sut = Vector4d.UnitY;
        
        // Then
        Assert.Equal(0.0F, sut.X);
        Assert.Equal(1.0F, sut.Y);
        Assert.Equal(0.0F, sut.Z);
        Assert.Equal(0.0F, sut.W);
    }
    
    [Fact]
    public void Returns_unit_z()
    {
        // Given
        
        // When
        var sut = Vector4d.UnitZ;
        
        // Then
        Assert.Equal(0.0F, sut.X);
        Assert.Equal(0.0F, sut.Y);
        Assert.Equal(1.0F, sut.Z);
        Assert.Equal(0.0F, sut.W);
    }    
    
    [Fact]
    public void Returns_unit_w()
    {
        // Given
        
        // When
        var sut = Vector4d.UnitW;
        
        // Then
        Assert.Equal(0.0F, sut.X);
        Assert.Equal(0.0F, sut.Y);
        Assert.Equal(0.0F, sut.Z);
        Assert.Equal(1.0F, sut.W);
    }
            
    [Fact]
    public void Returns_zero()
    {
        // Given
        
        // When
        var sut = Vector4d.Zero;
        
        // Then
        Assert.Equal(0.0F, sut.X);
        Assert.Equal(0.0F, sut.Y);
        Assert.Equal(0.0F, sut.Z);
        Assert.Equal(0.0F, sut.W);
    }    
    [Fact]
    public void Returns_one()
    {
        // Given
        
        // When
        var sut = Vector4d.One;
        
        // Then
        Assert.Equal(1.0F, sut.X);
        Assert.Equal(1.0F, sut.Y);
        Assert.Equal(1.0F, sut.Z);
        Assert.Equal(1.0F, sut.W);
    }
}