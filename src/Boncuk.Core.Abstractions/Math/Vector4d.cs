namespace Boncuk.Core.Abstractions.Math;

public readonly struct Vector4d
{
    public readonly float X;
    public readonly float Y;
    public readonly float Z;
    public readonly float W;

    public static readonly Vector4d UnitX = new(1.0F, 0.0F, 0.0F, 0.0F);
    public static readonly Vector4d UnitY = new(0.0F, 1.0F, 0.0F, 0.0F);
    public static readonly Vector4d UnitZ = new(0.0F, 0.0F, 1.0F, 0.0F);
    public static readonly Vector4d UnitW = new(0.0F, 0.0F, 0.0F, 1.0F);

    public Vector4d(float x, float y, float z, float w) => (X, Y, Z, W) = (x, y, z, w);
}