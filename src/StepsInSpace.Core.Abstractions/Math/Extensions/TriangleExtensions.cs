using System;

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
}