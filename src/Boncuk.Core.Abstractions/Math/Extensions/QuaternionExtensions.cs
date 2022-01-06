namespace Boncuk.Core.Abstractions.Math.Extensions;

public static class QuaternionExtensions
{
    public static Quaternion Add(this Quaternion left, Quaternion right)
        => new (left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);

    public static Quaternion Subtract(this Quaternion left, Quaternion right)
        => new (left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);

    public static Quaternion Multiply(this Quaternion left, Quaternion right)
        => new (left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);

    public static Quaternion Divide(this Quaternion left, Quaternion right)
        => new (left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W / right.W);
    
    public static float Dot(this Quaternion left, Quaternion right)
        => left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
    
    public static Quaternion Normalize(this Quaternion source)
    {
        var length = (float) System.Math.Pow(source.Dot(source), 0.5);
        return new (source.X / length, source.Y / length, source.Z / length, source.W / length);
    }}