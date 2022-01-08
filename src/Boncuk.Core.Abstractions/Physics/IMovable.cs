using Boncuk.Core.Abstractions.Math;

namespace Boncuk.Core.Abstractions.Physics;

public interface IMovable
{    
    Vector3d Position { get; }
    
    Quaternion Orientation { get; }

    void Pitch(float angleInDegree);

    void Yaw(float angleInDegree);

    void Roll(float angleInDegree);

    void MoveX(float distance);

    void MoveY(float distance);

    void MoveZ(float distance);

    void Move(Vector3d direction);
}