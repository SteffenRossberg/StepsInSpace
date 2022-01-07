using System;
using Boncuk.Core.Abstractions.Math;
using Boncuk.Core.Abstractions.Math.Extensions;

namespace Boncuk.Core.Abstractions.Collision.Extensions;

public static class CollisionExtensions
{
    public static bool Intersects(this BoundingSphere sphere, Ray ray)
        => GetIntersection(ray, sphere).HasValue;

    public static bool Intersects(this Ray ray, BoundingSphere sphere)
        => GetIntersection(ray, sphere).HasValue;

    public static bool Intersects(this Ray ray, Plane plane)
        => IntersectsRayPlane(ray, plane);

    public static bool Intersects(this Plane plane, Ray ray)
        => IntersectsRayPlane(ray, plane);

    private static bool IntersectsRayPlane(Ray ray, Plane plane)
    {
        var nd = ray.NormalizedDirection.Dot(plane.Normal);
        if (nd == 0.0)
            return false;
        var no = -(plane.Normal.Dot(ray.Origin) + plane.D) / nd;
        return no >= 0F;
    }

    public static bool Intersects(this BoundingSphere sphere, Plane plane)
        => IntersectsBoundingSpherePlane(sphere, plane);

    public static bool Intersects(this Plane plane, BoundingSphere sphere)
        => IntersectsBoundingSpherePlane(sphere, plane);

    private static bool IntersectsBoundingSpherePlane(BoundingSphere sphere, Plane plane)
    {
        var distance = plane.Normal.Dot(sphere.Center) + plane.D;
        return distance * distance <= sphere.SquaredRadius;
    }

    public static bool Intersects(this BoundingSphere sphere, BoundingSphere other)
    {
        var direction = sphere.Center.Subtract(other.Center);
        var distance = sphere.Radius + other.Radius;
        return direction.SquaredLength() <= distance * distance;
    }

    public static Intersection? GetIntersection(this Ray ray, BoundingSphere sphere)
    {
        var centerToOrigin = ray.Origin.Subtract(sphere.Center);
        var b = centerToOrigin.Dot(ray.Direction);
        var c = centerToOrigin.SquaredLength() - sphere.SquaredRadius;
        if (c > 0F && b > 0F) return null;
        var discriminant = b * b - c;
        if (discriminant < 0F) return null;
        var t = (float)System.Math.Max(0F, -b - System.Math.Sqrt(discriminant));
        var hit = ray.Origin.Add(ray.NormalizedDirection.Multiply(t));
        return new Intersection(hit.Subtract(ray.Origin), hit);
    }

    
    public static Intersection? GetIntersection(this Ray ray, Plane plane)
        => throw new NotImplementedException();
}