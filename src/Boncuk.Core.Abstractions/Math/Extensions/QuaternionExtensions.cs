namespace Boncuk.Core.Abstractions.Math.Extensions;

public static class QuaternionExtensions
{
    public static Quaternion Add(this Quaternion left, Quaternion right)
        => new (left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);

    public static Quaternion Add(this Quaternion left, float value)
        => new (left.X + value, left.Y + value, left.Z + value, left.W + value);

    public static Quaternion Subtract(this Quaternion left, Quaternion right)
        => new (left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);

    public static Quaternion Subtract(this Quaternion left, float value)
        => new (left.X - value, left.Y - value, left.Z - value, left.W - value);

    public static Quaternion Multiply(this Quaternion left, Quaternion right)
        => new (left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);

    public static Quaternion Multiply(this Quaternion left, float value)
        => new (left.X * value, left.Y * value, left.Z * value, left.W * value);

    public static Quaternion Divide(this Quaternion left, Quaternion right)
        => new (left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W / right.W);
    
    public static float Dot(this Quaternion left, Quaternion right)
        => left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
    
    public static Quaternion Normalize(this Quaternion source)
    {
        var length = source.Length();
        return new (source.X / length, source.Y / length, source.Z / length, source.W / length);
    }

    public static float Length(this Quaternion source)
        => (float) System.Math.Sqrt(source.SquaredLength());

    public static float SquaredLength(this Quaternion source)
        => source.Dot(source);
}