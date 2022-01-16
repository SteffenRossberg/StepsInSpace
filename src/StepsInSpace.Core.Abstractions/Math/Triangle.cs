using StepsInSpace.Core.Abstractions.Collision;

namespace StepsInSpace.Core.Abstractions.Math;

public readonly struct Triangle
{
    public readonly Vector3d A;
    public readonly Vector3d B;
    public readonly Vector3d C;
    public readonly Plane Plane;
    public readonly Vector2d TextureA;
    public readonly Vector2d TextureB;
    public readonly Vector2d TextureC;
    
    public Triangle(
        Vector3d a,
        Vector3d b,
        Vector3d c)
        : this(
            a,
            b,
            c,
            Vector2d.Zero,
            Vector2d.Zero,
            Vector2d.Zero)
    {
    }

    public Triangle(
        Vector3d a, 
        Vector3d b, 
        Vector3d c, 
        Vector2d textureA, 
        Vector2d textureB, 
        Vector2d textureC)
    {
        A = a;
        B = b;
        C = c;
        Plane = new Plane(A, B, C);
        TextureA = textureA;
        TextureB = textureB;
        TextureC = textureC;
    }
}