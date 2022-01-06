namespace Boncuk.Core.Abstractions.Math;

public readonly struct Vector2d
{
    public readonly float X;
    public readonly float Y;

    public Vector2d(float x, float y) => (X, Y) = (x, y);
}