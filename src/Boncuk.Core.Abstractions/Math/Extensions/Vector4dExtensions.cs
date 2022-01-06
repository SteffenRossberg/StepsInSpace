namespace Boncuk.Core.Abstractions.Math.Extensions;

public static class Vector4dExtensions
{
    public static Vector4d Add(this Vector4d left, Vector4d right)
        => new (left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);

    public static Vector4d Subtract(this Vector4d left, Vector4d right)
        => new (left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);

    public static Vector4d Multiply(this Vector4d left, Vector4d right)
        => new (left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);

    public static Vector4d Divide(this Vector4d left, Vector4d right)
        => new (left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W / right.W);
    
    public static float Dot(this Vector4d left, Vector4d right)
        => left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
}