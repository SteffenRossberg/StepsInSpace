using System;
using StepsInSpace.Core.Abstractions.Math;
using StepsInSpace.Core.Abstractions.Math.Extensions;
using StepsInSpace.Core.Physics;
using Xunit;

namespace UnitTests.StepsInSpace.Core.Physics;

public class CameraFacts
{
    private readonly Func<Camera> _createCamera;
    
    public CameraFacts()
    {
        _createCamera = () => new Camera();
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
        var sut = _createCamera();
        
        var position = sut.Position;
        var orientation = sut.Orientation;
        const float pitchDegree = 10;
        const float yawDegree = 20;
        const float rollDegree = 30;
        orientation = orientation.Multiply(Vector3d.UnitX.CreateRotation(pitchDegree));
        orientation = orientation.Multiply(Vector3d.UnitY.CreateRotation(yawDegree));
        orientation = orientation.Multiply(Vector3d.UnitZ.CreateRotation(rollDegree));
        position = position.Add(new Vector3d(x, 0, 0).Transform(orientation));
        position = position.Add(new Vector3d(0, y, 0).Transform(orientation));
        position = position.Add(new Vector3d(0, 0, z).Transform(orientation));
        position = position.Add(new Vector3d(x, y, z).Transform(orientation));
        
        sut.Pitch(pitchDegree);
        sut.Yaw(yawDegree);
        sut.Roll(rollDegree);
        sut.MoveX(x);
        sut.MoveY(y);
        sut.MoveZ(z);
        sut.Move(new Vector3d(x, y, z));
        
        var expectedTarget = position.Add(Vector3d.UnitZ.Transform(orientation));
        var expectedUp = Vector3d.UnitY.Transform(orientation).Normalize();
        var expected = position.LookAt(expectedTarget, expectedUp);
        
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