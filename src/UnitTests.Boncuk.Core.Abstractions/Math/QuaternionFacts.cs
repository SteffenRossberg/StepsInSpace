using Boncuk.Core.Abstractions.Math;
using Xunit;

namespace UnitTests.Boncuk.Core.Abstractions.Math;

public class QuaternionFacts
{
    [Theory]
    [InlineData(1, 2, 3, 4)]
    [InlineData(-1, -2, -3, -4)]
    [InlineData(0, 0, 0, 0)]
    [InlineData(float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue)]
    [InlineData(float.MinValue, float.MinValue, float.MinValue, float.MinValue)]
    public void Constructs_Quaternion(float x, float y, float z, float w)
    {
        // Given
        
        // When
        var sut = new Quaternion(x, y, z, w);
        
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
        var sut = Quaternion.UnitX;
        
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
        var sut = Quaternion.UnitY;
        
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
        var sut = Quaternion.UnitZ;
        
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
        var sut = Quaternion.UnitW;
        
        // Then
        Assert.Equal(0.0F, sut.X);
        Assert.Equal(0.0F, sut.Y);
        Assert.Equal(0.0F, sut.Z);
        Assert.Equal(1.0F, sut.W);
    }
    
    [Fact]
    public void Returns_identity()
    {
        // Given
        
        // When
        var sut = Quaternion.Identity;
        
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
        var sut = Quaternion.Zero;
        
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
        var sut = Quaternion.One;
        
        // Then
        Assert.Equal(1.0F, sut.X);
        Assert.Equal(1.0F, sut.Y);
        Assert.Equal(1.0F, sut.Z);
        Assert.Equal(1.0F, sut.W);
    }
}