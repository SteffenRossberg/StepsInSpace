using System.Runtime.CompilerServices;

namespace Boncuk.Core.Abstractions.Math.Extensions;

public static class QuaternionExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Quaternion Add(this Quaternion left, Quaternion right)
        => new (left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Quaternion Add(this Quaternion left, float value)
        => new (left.X + value, left.Y + value, left.Z + value, left.W + value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Quaternion Subtract(this Quaternion left, Quaternion right)
        => new (left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Quaternion Subtract(this Quaternion left, float value)
        => new (left.X - value, left.Y - value, left.Z - value, left.W - value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Quaternion Multiply(this Quaternion left, Quaternion right)
        => new(
            right.W * left.X + left.W * right.X + (left.Y * right.Z - left.Z * right.Y),
            right.W * left.Y + left.W * right.Y + (left.Z * right.X - left.X * right.Z),
            right.W * left.Z + left.W * right.Z + (left.X * right.Y - left.Y * right.X),
            left.W * right.W - (left.X * right.X + left.Y * right.Y + left.Z * right.Z));
    

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Quaternion Multiply(this Quaternion left, float value)
        => new (left.X * value, left.Y * value, left.Z * value, left.W * value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Quaternion Divide(this Quaternion left, float value)
        => new (left.X / value, left.Y / value, left.Z / value, left.W / value);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Dot(this Quaternion left, Quaternion right)
        => left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Quaternion Normalize(this Quaternion source)
        => source.Divide(source.Length());

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Length(this Quaternion source)
        => (float) System.Math.Sqrt(source.SquaredLength());

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float SquaredLength(this Quaternion source)
        => source.Dot(source);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Quaternion Invert(this Quaternion source)
    {
        var squaredLength = source.SquaredLength();
        var factor = squaredLength != 0F ? -(1F / squaredLength) : 1F;
        return source.Multiply(factor);
    }
}