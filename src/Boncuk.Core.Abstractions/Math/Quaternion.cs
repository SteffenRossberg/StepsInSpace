namespace Boncuk.Core.Abstractions.Math;

public readonly struct Quaternion
{
    public readonly float X;
    public readonly float Y;
    public readonly float Z;
    public readonly float W;

    public Quaternion(float x, float y, float z, float w) => (X, Y, Z, W) = (x, y, z, w);
}