namespace Boncuk.Core.Abstractions.Math.Extensions;

public static class Vector3dExtensions
{
    public static Vector3d Add(this Vector3d left, Vector3d right)
        => new (left.X + right.X, left.Y + right.Y, left.Z + right.Z);

    public static Vector3d Subtract(this Vector3d left, Vector3d right)
        => new (left.X - right.X, left.Y - right.Y, left.Z - right.Z);

    public static Vector3d Multiply(this Vector3d left, Vector3d right)
        => new (left.X * right.X, left.Y * right.Y, left.Z * right.Z);

    public static Vector3d Divide(this Vector3d left, Vector3d right)
        => new (left.X / right.X, left.Y / right.Y, left.Z / right.Z);
}