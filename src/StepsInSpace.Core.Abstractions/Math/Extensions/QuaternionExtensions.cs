using System.Runtime.CompilerServices;

namespace StepsInSpace.Core.Abstractions.Math.Extensions;

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
    
    public static Matrix4d ToRotation(this Quaternion rotation)
    {
        var squareRotation = rotation.Multiply(rotation);
        var xy = rotation.X * rotation.Y;
        var xz = rotation.X * rotation.Z;
        var xw = rotation.X * rotation.W;
        var yz = rotation.Y * rotation.Z;
        var yw = rotation.Y * rotation.W;
        var zw = rotation.Z * rotation.W;
        var s2 = 2F / (squareRotation.X + squareRotation.Y + squareRotation.Z + squareRotation.W);
        var m00 = 1F - (s2 * (squareRotation.Y + squareRotation.Z));
        var m01 = s2 * (xy + zw);
        var m02 = s2 * (xz - yw);
        var m10 = s2 * (xy - zw);
        var m11 = 1f - (s2 * (squareRotation.X + squareRotation.Z));
        var m12 = s2 * (yz + xw);
        var m20 = s2 * (xz + yw);
        var m21 = s2 * (yz - xw);
        var m22 = 1F - (s2 * (squareRotation.X + squareRotation.Y));
        return new(
            m00, m01, m02, 0F,
            m10, m11, m12, 0F,
            m20, m21, m22, 0F,
            0F, 0F, 0F, 1F);
    }
}