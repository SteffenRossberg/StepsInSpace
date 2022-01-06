namespace Boncuk.Core.Abstractions.Math;

public readonly struct Vector3d
{
    public readonly float X;
    public readonly float Y;
    public readonly float Z;

    public Vector3d(float x, float y, float z) => (X, Y, Z) = (x, y, z);
}