using StepsInSpace.Core.Abstractions.Math;

namespace StepsInSpace.Core.Abstractions.Collision;

public readonly struct BoundingSphere
{
    public readonly Vector3d Center;
    public readonly float Radius;
    public readonly float SquaredRadius;

    public BoundingSphere(Vector3d center, float radius)
        => (Center, Radius, SquaredRadius) = (center, radius, radius * radius);
}