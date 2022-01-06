namespace Boncuk.Core.Abstractions.Math.Extensions;

public static class Vector4dExtensions
{
    public static Vector4d Add(this Vector4d left, Vector4d right)
        => new (left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);

    public static Vector4d Add(this Vector4d left, float value)
        => new (left.X + value, left.Y + value, left.Z + value, left.W + value);

    public static Vector4d Subtract(this Vector4d left, Vector4d right)
        => new (left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);

    public static Vector4d Subtract(this Vector4d left, float value)
        => new (left.X - value, left.Y - value, left.Z - value, left.W - value);

    public static Vector4d Multiply(this Vector4d left, Vector4d right)
        => new (left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);

    public static Vector4d Divide(this Vector4d left, Vector4d right)
        => new (left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W / right.W);
    
    public static float Dot(this Vector4d left, Vector4d right)
        => left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
    
    public static Vector4d Normalize(this Vector4d source)
    {
        var length = source.Length();
        return new (source.X / length, source.Y / length, source.Z / length, source.W / length);
    }

    public static float Length(this Vector4d source)
        => (float) System.Math.Sqrt(source.SquaredLength());

    public static float SquaredLength(this Vector4d source)
        => source.Dot(source);
}