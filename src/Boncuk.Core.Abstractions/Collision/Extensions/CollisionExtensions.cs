using System;
using Boncuk.Core.Abstractions.Math;
using Boncuk.Core.Abstractions.Math.Extensions;

namespace Boncuk.Core.Abstractions.Collision.Extensions;

public static class CollisionExtensions
{
    public static bool Intersects(this BoundingSphere sphere, Ray ray)
        => IntersectsRayBoundingSphere(ray, sphere);

    public static bool Intersects(this Ray ray, BoundingSphere sphere)
        => IntersectsRayBoundingSphere(ray, sphere);

    private static bool IntersectsRayBoundingSphere(Ray ray, BoundingSphere sphere)
    {
        var pointToCenter = sphere.Center.Subtract(ray.Origin);
        if (pointToCenter.SquaredLength() <= sphere.SquaredRadius)
            return true;
        var normalizedRayDirection = ray.Direction.Normalize();
        var distance = pointToCenter.Dot(normalizedRayDirection);
        if (distance < 0F)
            return false;
        var hit = ray.Origin.Add(normalizedRayDirection.Multiply(distance));
        return sphere.Center.Subtract(hit).SquaredLength() <= sphere.SquaredRadius;
    }

    public static bool Intersects(this BoundingSphere sphere, Plane plane)
        => throw new NotImplementedException();
    
    public static bool Intersects(this Ray ray, Plane plane)
        => throw new NotImplementedException();

    public static bool Intersects(this Plane plane, BoundingSphere sphere)
        => throw new NotImplementedException();

    public static bool Intersects(this Plane plane, Ray sphere)
        => throw new NotImplementedException();
    
    public static Intersection? GetIntersection(this Ray ray, BoundingSphere sphere)
        => throw new NotImplementedException();
    
    public static Intersection? GetIntersection(this Ray ray, Plane plane)
        => throw new NotImplementedException();
}