using Boncuk.Core.Abstractions.Math;

namespace Boncuk.Core.Abstractions.Collision;

public struct BoundingSphere
{
    public readonly Vector3d Center;
    public readonly float Radius;
    public readonly float SquaredRadius;

    public BoundingSphere(Vector3d center, float radius)
        => (Center, Radius, SquaredRadius) = (center, radius, radius * radius);
}