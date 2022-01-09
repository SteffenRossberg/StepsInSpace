using System.Runtime.CompilerServices;

namespace StepsInSpace.Core.Abstractions.Math.Extensions;

public static class Vector2dExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector2d Add(this Vector2d left, Vector2d right)
        => new (left.X + right.X, left.Y + right.Y);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector2d Add(this Vector2d left, float value)
        => new (left.X + value, left.Y + value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector2d Subtract(this Vector2d left, Vector2d right)
        => new (left.X - right.X, left.Y - right.Y);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector2d Subtract(this Vector2d left, float value)
        => new (left.X - value, left.Y - value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector2d Multiply(this Vector2d left, Vector2d right)
        => new (left.X * right.X, left.Y * right.Y);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector2d Multiply(this Vector2d left, float value)
        => new (left.X * value, left.Y * value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector2d Divide(this Vector2d left, Vector2d right)
        => new (left.X / right.X, left.Y / right.Y);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector2d Divide(this Vector2d left, float value)
        => new (left.X / value, left.Y / value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Dot(this Vector2d left, Vector2d right)
        => left.X * right.X + left.Y * right.Y;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector2d Normalize(this Vector2d source)
        => source.Divide(source.Length());

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Length(this Vector2d source)
        => (float) System.Math.Sqrt(source.SquaredLength());

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float SquaredLength(this Vector2d source)
        => source.Dot(source);
}