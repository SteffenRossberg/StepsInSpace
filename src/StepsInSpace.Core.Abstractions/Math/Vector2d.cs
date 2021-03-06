namespace StepsInSpace.Core.Abstractions.Math;

public readonly struct Vector2d
{
    public readonly float X;
    public readonly float Y;
    
    public static readonly Vector2d UnitX = new(1.0f, 0.0f);
    public static readonly Vector2d UnitY = new(0.0f, 1.0f);
    public static readonly Vector2d Zero = new();
    public static readonly Vector2d One = new(1.0F, 1.0F);

    public Vector2d(float x, float y) => (X, Y) = (x, y);
}