using System.Collections.Generic;
using System.Linq;

namespace StepsInSpace.Core.Abstractions.Math.Extensions;

public static class TriangleExtensions
{
    public static Triangle Transform(this Triangle source, Matrix4d matrix)
    {
        var newA = source.A.Transform(matrix);
        var newB = source.B.Transform(matrix);
        var newC = source.C.Transform(matrix);
        return new Triangle(
            newA, newB, newC, 
            source.TextureA, source.TextureB, source.TextureC);
    }

    public static bool IsPointInside(this Triangle triangle, Vector3d point)
    {
        var v0 = triangle.Plane.V0;
        var v1 = triangle.Plane.V1;
        var v2 = point.Subtract(triangle.A);
        
        var d00 = v0.Dot(v0);
        var d01 = v0.Dot(v1);
        var d02 = v0.Dot(v2);
        var d11 = v1.Dot(v1);
        var d12 = v1.Dot(v2);

        // compute barycentric coordinates
        var inverse = 1F / (d00 * d11 - d01 * d01);
        var u = (d11 * d02 - d01 * d12) * inverse;
        var v = (d00 * d12 - d01 * d02) * inverse;

        return u >= 0F && v >= 0F && u + v < 1F;
    }

    public static float[] ToVertexArray(this Triangle source)
        => new[]
        {
            source.A.X, source.A.Y, source.A.Z,
            source.B.X, source.B.Y, source.B.Z,
            source.C.X, source.C.Y, source.C.Z,
        };

    public static float[] ToTextureArray(this Triangle source)
        => new[]
        {
            source.TextureA.X, source.TextureA.Y,
            source.TextureB.X, source.TextureB.Y,
            source.TextureC.X, source.TextureC.Y,
        };

    public static float[] ToVertexArray(this IEnumerable<Triangle> source)
    {
        var vertices = 
            source
                .AsParallel()
                .SelectMany(ToVertexArray)
                .ToArray();
        return vertices;
    }

    public static float[] ToTextureArray(this IEnumerable<Triangle> source)
    {
        var vertices = 
            source
                .AsParallel()
                .SelectMany(ToTextureArray)
                .ToArray();
        return vertices;
    }
}