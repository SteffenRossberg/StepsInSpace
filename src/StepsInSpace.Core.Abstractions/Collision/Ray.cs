using StepsInSpace.Core.Abstractions.Math;
using StepsInSpace.Core.Abstractions.Math.Extensions;

namespace StepsInSpace.Core.Abstractions.Collision;

public readonly struct Ray
{
    public readonly Vector3d Origin;
    public readonly Vector3d Direction;
    public readonly Vector3d NormalizedDirection;

    public Ray(Vector3d origin, Vector3d direction)
        => (Origin, Direction, NormalizedDirection) = (origin, direction, direction.Normalize());
}