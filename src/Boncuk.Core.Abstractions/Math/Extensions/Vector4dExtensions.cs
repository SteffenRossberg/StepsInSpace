using System.Runtime.CompilerServices;

namespace Boncuk.Core.Abstractions.Math.Extensions;

public static class Vector4dExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector4d Add(this Vector4d left, Vector4d right)
        => new (left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector4d Add(this Vector4d left, float value)
        => new (left.X + value, left.Y + value, left.Z + value, left.W + value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector4d Subtract(this Vector4d left, Vector4d right)
        => new (left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector4d Subtract(this Vector4d left, float value)
        => new (left.X - value, left.Y - value, left.Z - value, left.W - value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector4d Multiply(this Vector4d left, Vector4d right)
        => new (left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector4d Multiply(this Vector4d left, float value)
        => new (left.X * value, left.Y * value, left.Z * value, left.W * value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector4d Divide(this Vector4d left, Vector4d right)
        => new (left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W / right.W);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector4d Divide(this Vector4d left, float value)
        => new (left.X / value, left.Y / value, left.Z / value, left.W / value);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Dot(this Vector4d left, Vector4d right)
        => left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector4d Normalize(this Vector4d source)
        => source.Divide(source.Length());

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Length(this Vector4d source)
        => (float) System.Math.Sqrt(source.SquaredLength());

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float SquaredLength(this Vector4d source)
        => source.Dot(source);
}