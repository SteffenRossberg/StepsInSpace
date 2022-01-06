using System;

namespace Boncuk.Core.Abstractions.Math.Extensions;

public static class Vector2dExtensions
{
    public static Vector2d Add(this Vector2d left, Vector2d right)
        => new (left.X + right.X, left.Y + right.Y);

    public static Vector2d Subtract(this Vector2d left, Vector2d right)
        => new (left.X - right.X, left.Y - right.Y);

    public static Vector2d Multiply(this Vector2d left, Vector2d right)
        => new (left.X * right.X, left.Y * right.Y);

    public static Vector2d Divide(this Vector2d left, Vector2d right)
        => new (left.X / right.X, left.Y / right.Y);

    public static float Dot(this Vector2d left, Vector2d right)
        => left.X * right.X + left.Y * right.Y;
}