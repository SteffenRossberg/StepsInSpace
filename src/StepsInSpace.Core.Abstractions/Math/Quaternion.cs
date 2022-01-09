namespace StepsInSpace.Core.Abstractions.Math;

public readonly struct Quaternion
{
    public readonly float X;
    public readonly float Y;
    public readonly float Z;
    public readonly float W;

    public static readonly Quaternion UnitX = new(1.0F, 0.0F, 0.0F, 0.0F);
    public static readonly Quaternion UnitY = new(0.0F, 1.0F, 0.0F, 0.0F);
    public static readonly Quaternion UnitZ = new(0.0F, 0.0F, 1.0F, 0.0F);
    public static readonly Quaternion UnitW = new(0.0F, 0.0F, 0.0F, 1.0F);
    public static readonly Quaternion Identity = UnitW;
    public static readonly Quaternion Zero = new();
    public static readonly Quaternion One = new(1.0F, 1.0F, 1.0F, 1.0F);

    public Quaternion(float x, float y, float z, float w) => (X, Y, Z, W) = (x, y, z, w);
}