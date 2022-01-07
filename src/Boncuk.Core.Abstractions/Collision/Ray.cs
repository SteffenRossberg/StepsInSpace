using Boncuk.Core.Abstractions.Math;

namespace Boncuk.Core.Abstractions.Collision;

public readonly struct Ray
{
    public readonly Vector3d Origin;
    public readonly Vector3d Direction;

    public Ray(Vector3d origin, Vector3d direction)
        => (Origin, Direction) = (origin, direction);
}