using Boncuk.Core.Abstractions.Math;

namespace Boncuk.Core.Abstractions.Collision;

public readonly struct Intersection
{
    public readonly Vector3d Direction;
    public readonly Vector3d Hit;

    public Intersection(Vector3d direction, Vector3d hit)
        => (Direction, Hit) = (direction, hit);
}