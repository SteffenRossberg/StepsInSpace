namespace Boncuk.Core.Abstractions.Math.Extensions;

public static class Vector3dExtensions
{
    public static Vector3d Add(this Vector3d left, Vector3d right)
        => new (left.X + right.X, left.Y + right.Y, left.Z + right.Z);

    public static Vector3d Add(this Vector3d left, float value)
        => new (left.X + value, left.Y + value, left.Z + value);

    public static Vector3d Subtract(this Vector3d left, Vector3d right)
        => new (left.X - right.X, left.Y - right.Y, left.Z - right.Z);

    public static Vector3d Multiply(this Vector3d left, Vector3d right)
        => new (left.X * right.X, left.Y * right.Y, left.Z * right.Z);

    public static Vector3d Divide(this Vector3d left, Vector3d right)
        => new (left.X / right.X, left.Y / right.Y, left.Z / right.Z);

    public static float Dot(this Vector3d left, Vector3d right)
        => left.X * right.X + left.Y * right.Y + left.Z * right.Z;

    public static Vector3d Cross(this Vector3d left, Vector3d right)
        => new (left.Y * right.Z - left.Z * right.Y,
            left.Z * right.X - left.X * right.Z,
            left.X * right.Y - left.Y * right.X);
    
    public static Vector3d Normalize(this Vector3d source)
    {
        var length = source.Length();
        return new (source.X / length, source.Y / length, source.Z / length);
    }

    public static float Length(this Vector3d source)
        => (float) System.Math.Sqrt(source.SquaredLength());

    public static float SquaredLength(this Vector3d source)
        => source.Dot(source);
}