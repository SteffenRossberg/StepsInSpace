using System;
using Boncuk.Core.Abstractions.Math;
using Boncuk.Core.Abstractions.Math.Extensions;
using Boncuk.Core.Abstractions.Physics;

namespace Boncuk.Core.Physics;

public class Movable : IMovable
{
    private Vector3d _position = Vector3d.Zero;
    public Vector3d Position => _position;
    
    private Quaternion _orientation = Quaternion.Identity;
    public Quaternion Orientation => _orientation;

    public void Pitch(float angleInDegree)
        => Rotate(Vector3d.UnitX, angleInDegree);
    
    public void Yaw(float angleInDegree)        
        => Rotate(Vector3d.UnitY, angleInDegree);

    public void Roll(float angleInDegree) 
        => Rotate(Vector3d.UnitZ, angleInDegree);

    private void Rotate(Vector3d axis, float angleInDegree)
        => _orientation = _orientation.Multiply(axis.CreateRotation(angleInDegree)).Normalize();
    
    public void MoveX(float distance) 
        => Move(new Vector3d(distance, 0F, 0F));

    public void MoveY(float distance) 
        => Move(new Vector3d(0F, distance, 0F));

    public void MoveZ(float distance) 
        => Move(new Vector3d(0F, 0F, distance));

    public void Move(Vector3d direction)
        => _position = _position.Add(direction);
}