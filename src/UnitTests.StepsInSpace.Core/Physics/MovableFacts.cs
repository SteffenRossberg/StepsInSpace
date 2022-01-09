using System;
using StepsInSpace.Core.Abstractions.Math;
using StepsInSpace.Core.Abstractions.Math.Extensions;
using StepsInSpace.Core.Physics;
using Xunit;

namespace UnitTests.StepsInSpace.Core.Physics;

public class MovableFacts
{
    private readonly Func<Movable> _createMovable;

    public MovableFacts()
    {
        _createMovable = () => new Movable();
    }
    
    [Fact]
    public void Initializes_movable()
    {
        // Given
        
        // When
        var sut = _createMovable();
        
        // Then
        Assert.Equal(Vector3d.Zero.X, sut.Position.X);
        Assert.Equal(Vector3d.Zero.Y, sut.Position.Y);
        Assert.Equal(Vector3d.Zero.Z, sut.Position.Z);
        
        Assert.Equal(Quaternion.Identity.X, sut.Orientation.X);
        Assert.Equal(Quaternion.Identity.Y, sut.Orientation.Y);
        Assert.Equal(Quaternion.Identity.Z, sut.Orientation.Z);
        Assert.Equal(Quaternion.Identity.W, sut.Orientation.W);
    }

    [Theory]
    [InlineData(0F)]
    [InlineData(1F)]
    [InlineData(90F)]
    [InlineData(180F)]
    [InlineData(360F)]
    public void Pitches_movable(float angleInDegree)
    {
        // Given
        var sut = _createMovable();
        var expected = sut.Orientation.Multiply(Vector3d.UnitX.CreateRotation(angleInDegree)).Normalize();
        
        // When
        sut.Pitch(angleInDegree);

        // Then
        Assert.Equal(expected.X, sut.Orientation.X);
        Assert.Equal(expected.Y, sut.Orientation.Y);
        Assert.Equal(expected.Z, sut.Orientation.Z);
        Assert.Equal(expected.W, sut.Orientation.W);
    }
    
    [Theory]
    [InlineData(0F, -1F)]
    [InlineData(1F, -90F)]
    [InlineData(90F, -180F)]
    [InlineData(180F, -360F)]
    [InlineData(360F, -90F)]
    public void Pitches_movable_second_time(float initAngleInDegree, float finalAngleInDegree)
    {
        // Given
        var sut = _createMovable();
        sut.Pitch(initAngleInDegree);
        var expected = sut.Orientation.Multiply(Vector3d.UnitX.CreateRotation(finalAngleInDegree)).Normalize();
        
        // When
        sut.Pitch(finalAngleInDegree);

        // Then
        Assert.Equal(expected.X, sut.Orientation.X);
        Assert.Equal(expected.Y, sut.Orientation.Y);
        Assert.Equal(expected.Z, sut.Orientation.Z);
        Assert.Equal(expected.W, sut.Orientation.W);
    }

    [Theory]
    [InlineData(0F)]
    [InlineData(1F)]
    [InlineData(90F)]
    [InlineData(180F)]
    [InlineData(360F)]
    public void Yaws_movable(float angleInDegree)
    {
        // Given
        var sut = _createMovable();
        var expected = sut.Orientation.Multiply(Vector3d.UnitY.CreateRotation(angleInDegree)).Normalize();
        
        // When
        sut.Yaw(angleInDegree);

        // Then
        Assert.Equal(expected.X, sut.Orientation.X);
        Assert.Equal(expected.Y, sut.Orientation.Y);
        Assert.Equal(expected.Z, sut.Orientation.Z);
        Assert.Equal(expected.W, sut.Orientation.W);
    }
    
    [Theory]
    [InlineData(0F, -1F)]
    [InlineData(1F, -90F)]
    [InlineData(90F, -180F)]
    [InlineData(180F, -360F)]
    [InlineData(360F, -90F)]
    public void Yaws_movable_second_time(float initAngleInDegree, float finalAngleInDegree)
    {
        // Given
        var sut = _createMovable();
        sut.Yaw(initAngleInDegree);
        var expected = sut.Orientation.Multiply(Vector3d.UnitY.CreateRotation(finalAngleInDegree)).Normalize();
        
        // When
        sut.Yaw(finalAngleInDegree);

        // Then
        Assert.Equal(expected.X, sut.Orientation.X);
        Assert.Equal(expected.Y, sut.Orientation.Y);
        Assert.Equal(expected.Z, sut.Orientation.Z);
        Assert.Equal(expected.W, sut.Orientation.W);
    }

    [Theory]
    [InlineData(0F)]
    [InlineData(1F)]
    [InlineData(90F)]
    [InlineData(180F)]
    [InlineData(360F)]
    public void Rolls_movable(float angleInDegree)
    {
        // Given
        var sut = _createMovable();
        var expected = sut.Orientation.Multiply(Vector3d.UnitZ.CreateRotation(angleInDegree)).Normalize();
        
        // When
        sut.Roll(angleInDegree);

        // Then
        Assert.Equal(expected.X, sut.Orientation.X);
        Assert.Equal(expected.Y, sut.Orientation.Y);
        Assert.Equal(expected.Z, sut.Orientation.Z);
        Assert.Equal(expected.W, sut.Orientation.W);
    }
    
    [Theory]
    [InlineData(0F, -1F)]
    [InlineData(1F, -90F)]
    [InlineData(90F, -180F)]
    [InlineData(180F, -360F)]
    [InlineData(360F, -90F)]
    public void Rolls_movable_second_time(float initAngleInDegree, float finalAngleInDegree)
    {
        // Given
        var sut = _createMovable();
        sut.Roll(initAngleInDegree);
        var expected = sut.Orientation.Multiply(Vector3d.UnitZ.CreateRotation(finalAngleInDegree)).Normalize();
        
        // When
        sut.Roll(finalAngleInDegree);

        // Then
        Assert.Equal(expected.X, sut.Orientation.X);
        Assert.Equal(expected.Y, sut.Orientation.Y);
        Assert.Equal(expected.Z, sut.Orientation.Z);
        Assert.Equal(expected.W, sut.Orientation.W);
    }

    [Theory]
    [InlineData(0F, 0F, 0F)]
    [InlineData(1F, 0F, 0F)]
    [InlineData(0F, 1F, 0F)]
    [InlineData(0F, 0F, 1F)]
    [InlineData(1F, 2F, 3F)]
    [InlineData(-1F, 0F, 0F)]
    [InlineData(0F, -1F, 0F)]
    [InlineData(0F, 0F, -1F)]
    [InlineData(-1F, -2F, -3F)]
    public void Moves_movable(float x, float y, float z)
    {
        // Given
        var sut = _createMovable();
        sut.Pitch(10);
        sut.Yaw(20);
        sut.Roll(30);
        var direction = new Vector3d(x, y, z);
        var expected = sut.Position.Add(direction.Transform(sut.Orientation));
        
        // When
        sut.Move(direction);
        
        // Then
        Assert.Equal(expected.X, sut.Position.X);
        Assert.Equal(expected.Y, sut.Position.Y);
        Assert.Equal(expected.Z, sut.Position.Z);
    }

    [Theory]
    [InlineData(0F, 0F, 0F)]
    [InlineData(1F, 0F, 0F)]
    [InlineData(0F, 1F, 0F)]
    [InlineData(0F, 0F, 1F)]
    [InlineData(1F, 2F, 3F)]
    [InlineData(-1F, 0F, 0F)]
    [InlineData(0F, -1F, 0F)]
    [InlineData(0F, 0F, -1F)]
    [InlineData(-1F, -2F, -3F)]
    public void Moves_movable_second_time(float x, float y, float z)
    {
        // Given
        var sut = _createMovable();
        sut.Pitch(10);
        sut.Yaw(20);
        sut.Roll(30);
        var direction = new Vector3d(x, y, z);
        sut.Move(direction);
        var expected = sut.Position.Add(direction.Transform(sut.Orientation));
        
        // When
        sut.Move(direction);
        
        // Then
        Assert.Equal(expected.X, sut.Position.X);
        Assert.Equal(expected.Y, sut.Position.Y);
        Assert.Equal(expected.Z, sut.Position.Z);
    }
    
    [Theory]
    [InlineData(0F)]
    [InlineData(1F)]
    [InlineData(2F)]
    [InlineData(3F)]
    [InlineData(-1F)]
    [InlineData(-2F)]
    [InlineData(-3F)]
    public void Moves_movable_on_x(float distance)
    {
        // Given
        var sut = _createMovable();
        sut.Pitch(10);
        sut.Yaw(20);
        sut.Roll(30);
        var direction = new Vector3d(distance, 0F, 0F);
        var expected = sut.Position.Add(direction.Transform(sut.Orientation));
        
        // When
        sut.MoveX(distance);
        
        // Then
        Assert.Equal(expected.X, sut.Position.X);
        Assert.Equal(expected.Y, sut.Position.Y);
        Assert.Equal(expected.Z, sut.Position.Z);
    }
    
    [Theory]
    [InlineData(0F)]
    [InlineData(1F)]
    [InlineData(2F)]
    [InlineData(3F)]
    [InlineData(-1F)]
    [InlineData(-2F)]
    [InlineData(-3F)]
    public void Moves_movable_on_x_second_time(float distance)
    {
        // Given
        var sut = _createMovable();
        sut.Pitch(10);
        sut.Yaw(20);
        sut.Roll(30);
        var direction = new Vector3d(distance, 0F, 0F);
        sut.MoveX(distance);
        var expected = sut.Position.Add(direction.Transform(sut.Orientation));
        
        // When
        sut.MoveX(distance);
        
        // Then
        Assert.Equal(expected.X, sut.Position.X);
        Assert.Equal(expected.Y, sut.Position.Y);
        Assert.Equal(expected.Z, sut.Position.Z);
    }
    
    [Theory]
    [InlineData(0F)]
    [InlineData(1F)]
    [InlineData(2F)]
    [InlineData(3F)]
    [InlineData(-1F)]
    [InlineData(-2F)]
    [InlineData(-3F)]
    public void Moves_movable_on_y(float distance)
    {
        // Given
        var sut = _createMovable();
        sut.Pitch(10);
        sut.Yaw(20);
        sut.Roll(30);
        var direction = new Vector3d(0F, distance, 0F);
        var expected = sut.Position.Add(direction.Transform(sut.Orientation));
        
        // When
        sut.MoveY(distance);
        
        // Then
        Assert.Equal(expected.X, sut.Position.X);
        Assert.Equal(expected.Y, sut.Position.Y);
        Assert.Equal(expected.Z, sut.Position.Z);
    }
    
    [Theory]
    [InlineData(0F)]
    [InlineData(1F)]
    [InlineData(2F)]
    [InlineData(3F)]
    [InlineData(-1F)]
    [InlineData(-2F)]
    [InlineData(-3F)]
    public void Moves_movable_on_y_second_time(float distance)
    {
        // Given
        var sut = _createMovable();
        sut.Pitch(10);
        sut.Yaw(20);
        sut.Roll(30);
        var direction = new Vector3d(0F, distance, 0F);
        sut.MoveY(distance);
        var expected = sut.Position.Add(direction.Transform(sut.Orientation));
        
        // When
        sut.MoveY(distance);
        
        // Then
        Assert.Equal(expected.X, sut.Position.X);
        Assert.Equal(expected.Y, sut.Position.Y);
        Assert.Equal(expected.Z, sut.Position.Z);
    }
    
    [Theory]
    [InlineData(0F)]
    [InlineData(1F)]
    [InlineData(2F)]
    [InlineData(3F)]
    [InlineData(-1F)]
    [InlineData(-2F)]
    [InlineData(-3F)]
    public void Moves_movable_on_z(float distance)
    {
        // Given
        var sut = _createMovable();
        sut.Pitch(10);
        sut.Yaw(20);
        sut.Roll(30);
        var direction = new Vector3d(0F, 0F, distance);
        var expected = sut.Position.Add(direction.Transform(sut.Orientation));
        
        // When
        sut.MoveZ(distance);
        
        // Then
        Assert.Equal(expected.X, sut.Position.X);
        Assert.Equal(expected.Y, sut.Position.Y);
        Assert.Equal(expected.Z, sut.Position.Z);
    }
    
    [Theory]
    [InlineData(0F)]
    [InlineData(1F)]
    [InlineData(2F)]
    [InlineData(3F)]
    [InlineData(-1F)]
    [InlineData(-2F)]
    [InlineData(-3F)]
    public void Moves_movable_on_z_second_time(float distance)
    {
        // Given
        var sut = _createMovable();
        sut.Pitch(10);
        sut.Yaw(20);
        sut.Roll(30);
        var direction = new Vector3d(0F, 0F, distance);
        sut.MoveZ(distance);
        var expected = sut.Position.Add(direction.Transform(sut.Orientation));
        
        // When
        sut.MoveZ(distance);
        
        // Then
        Assert.Equal(expected.X, sut.Position.X);
        Assert.Equal(expected.Y, sut.Position.Y);
        Assert.Equal(expected.Z, sut.Position.Z);
    }
    
    [Theory]
    [InlineData(0F, 0F, 0F)]
    [InlineData(1F, 0F, 0F)]
    [InlineData(0F, 1F, 0F)]
    [InlineData(0F, 0F, 1F)]
    [InlineData(1F, 2F, 3F)]
    [InlineData(-1F, 0F, 0F)]
    [InlineData(0F, -1F, 0F)]
    [InlineData(0F, 0F, -1F)]
    [InlineData(-1F, -2F, -3F)]
    public void Gets_model_matrix(float x, float y, float z)
    {
        // Given
        var sut = _createMovable();
        sut.Pitch(10);
        sut.Yaw(20);
        sut.Roll(30);
        sut.Move(new Vector3d(x, y, z));
        var expected = sut.Orientation.ToRotation().Multiply(sut.Position.ToTranslation());
        
        // When
        var actual = sut.GetModelMatrix();
        
        // Then
        Assert.Equal(expected.M00, actual.M00);
        Assert.Equal(expected.M01, actual.M01);
        Assert.Equal(expected.M02, actual.M02);
        Assert.Equal(expected.M03, actual.M03);

        Assert.Equal(expected.M10, actual.M10);
        Assert.Equal(expected.M11, actual.M11);
        Assert.Equal(expected.M12, actual.M12);
        Assert.Equal(expected.M13, actual.M13);

        Assert.Equal(expected.M20, actual.M20);
        Assert.Equal(expected.M21, actual.M21);
        Assert.Equal(expected.M22, actual.M22);
        Assert.Equal(expected.M23, actual.M23);

        Assert.Equal(expected.M30, actual.M30);
        Assert.Equal(expected.M31, actual.M31);
        Assert.Equal(expected.M32, actual.M32);
        Assert.Equal(expected.M33, actual.M33);
    }
}
