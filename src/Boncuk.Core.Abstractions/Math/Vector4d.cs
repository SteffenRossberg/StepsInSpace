namespace Boncuk.Core.Abstractions.Math;

public readonly struct Vector4d
{
    public readonly float X;
    public readonly float Y;
    public readonly float Z;
    public readonly float W;

    public Vector4d(float x, float y, float z, float w) => (X, Y, Z, W) = (x, y, z, w);
}