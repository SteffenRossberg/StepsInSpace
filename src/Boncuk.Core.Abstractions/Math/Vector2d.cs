namespace Boncuk.Core.Abstractions.Math;

public readonly struct Vector2d
{
    public readonly float X;
    public readonly float Y;
    
    public static readonly Vector2d UnitX = new(1.0f, 0.0f);
    public static readonly Vector2d UnitY = new(0.0f, 1.0f);
    
    public Vector2d(float x, float y) => (X, Y) = (x, y);
}