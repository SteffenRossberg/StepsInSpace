namespace Boncuk.Core.Abstractions.Math;

public readonly struct Vector3d
{
    public readonly float X;
    public readonly float Y;
    public readonly float Z;

    public static readonly Vector3d UnitX = new(1.0F, 0.0F, 0.0F);
    public static readonly Vector3d UnitY = new(0.0F, 1.0F, 0.0F);
    public static readonly Vector3d UnitZ = new(0.0F, 0.0F, 1.0F);
    public static readonly Vector3d Zero = new();
    public static readonly Vector3d One = new(1.0F, 1.0F, 1.0F);

    public Vector3d(float x, float y, float z) => (X, Y, Z) = (x, y, z);
}