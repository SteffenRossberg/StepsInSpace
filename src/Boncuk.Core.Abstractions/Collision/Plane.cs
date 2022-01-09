using Boncuk.Core.Abstractions.Math;
using Boncuk.Core.Abstractions.Math.Extensions;

namespace Boncuk.Core.Abstractions.Collision;

public readonly struct Plane
{
    public readonly Vector3d Normal;
    public readonly Vector3d V0;
    public readonly Vector3d V1;
    public readonly float D;

    public Plane(Vector3d a, Vector3d b, Vector3d c)
    {
        V0 = b.Subtract(a);
        V1 = c.Subtract(a);
        Normal = V0.Cross(V1).Normalize();
        D = Normal.Dot(a);
    }
}