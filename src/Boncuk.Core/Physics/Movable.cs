using System;
using Boncuk.Core.Abstractions.Math;
using Boncuk.Core.Abstractions.Physics;

namespace Boncuk.Core.Physics;

public class Movable : IMovable
{
    public Vector3d Position => throw new NotImplementedException();
    
    public Quaternion Orientation => throw new NotImplementedException();

    public void Pitch(float angleInDegree) => throw new NotImplementedException();

    public void Yaw(float angleInDegree) => throw new NotImplementedException();

    public void Role(float angleInDegree) => throw new NotImplementedException();

    public void MoveX(float distance) => throw new NotImplementedException();

    public void MoveY(float distance) => throw new NotImplementedException();

    public void MoveZ(float distance) => throw new NotImplementedException();

    public void Move(Vector3d direction) => throw new NotImplementedException();
}