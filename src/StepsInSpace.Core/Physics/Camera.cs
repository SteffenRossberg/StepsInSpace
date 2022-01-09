using StepsInSpace.Core.Abstractions.Math;
using StepsInSpace.Core.Abstractions.Math.Extensions;
using StepsInSpace.Core.Abstractions.Physics;

namespace StepsInSpace.Core.Physics;

public class Camera : IMovable
{
    public Vector3d Position => _model.Position;
    public Quaternion Orientation => _model.Orientation;
    public void Pitch(float angleInDegree) => _model.Pitch(angleInDegree);
    public void Yaw(float angleInDegree) => _model.Yaw(angleInDegree);
    public void Roll(float angleInDegree) => _model.Roll(angleInDegree);
    public void MoveX(float distance) => _model.MoveX(distance);
    public void MoveY(float distance) => _model.MoveY(distance);
    public void MoveZ(float distance) => _model.MoveZ(distance);
    public void Move(Vector3d direction) => _model.Move(direction);
    public Matrix4d GetModelMatrix()
    {
        var position = _model.Position;
        var orientation = _model.Orientation;
        var expectedTarget = position.Add(Vector3d.UnitZ.Transform(orientation));
        var expectedUp = Vector3d.UnitY.Transform(orientation).Normalize();
        return position.LookAt(expectedTarget, expectedUp);
    }

    private readonly Movable _model = new();
}