using System;
using System.Runtime.CompilerServices;

namespace Boncuk.Core.Abstractions.Math.Extensions;

public static class Vector3dExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector3d Add(this Vector3d left, Vector3d right)
        => new (left.X + right.X, left.Y + right.Y, left.Z + right.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector3d Add(this Vector3d left, float value)
        => new (left.X + value, left.Y + value, left.Z + value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector3d Subtract(this Vector3d left, Vector3d right)
        => new (left.X - right.X, left.Y - right.Y, left.Z - right.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector3d Subtract(this Vector3d left, float value)
        => new (left.X - value, left.Y - value, left.Z - value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector3d Multiply(this Vector3d left, Vector3d right)
        => new (left.X * right.X, left.Y * right.Y, left.Z * right.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector3d Multiply(this Vector3d left, float value)
        => new (left.X * value, left.Y * value, left.Z * value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector3d Divide(this Vector3d left, Vector3d right)
        => new (left.X / right.X, left.Y / right.Y, left.Z / right.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector3d Divide(this Vector3d left, float value)
        => new (left.X / value, left.Y / value, left.Z / value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Dot(this Vector3d left, Vector3d right)
        => left.X * right.X + left.Y * right.Y + left.Z * right.Z;

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector3d Cross(this Vector3d left, Vector3d right)
        => new (left.Y * right.Z - left.Z * right.Y,
            left.Z * right.X - left.X * right.Z,
            left.X * right.Y - left.Y * right.X);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector3d Normalize(this Vector3d source)
        => source.Divide(source.Length());

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Length(this Vector3d source)
        => (float) System.Math.Sqrt(source.SquaredLength());

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float SquaredLength(this Vector3d source)
        => source.Dot(source);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Quaternion CreateRotation(this Vector3d axis, float angleInDegree)
        => axis.SquaredLength() != 0.0
            ? CreateFromAxisAngle(axis, angleInDegree)
            : Quaternion.Identity;

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private static Quaternion CreateFromAxisAngle(Vector3d axis, float angleInDegree)
    {
        var (sin, cos) = System.Math.SinCos(angleInDegree.ToRadians() * 0.5); 
        axis = axis.Normalize().Multiply((float)sin);
        return new Quaternion(axis.X, axis.Y, axis.Z, (float)cos).Normalize();
    }
}