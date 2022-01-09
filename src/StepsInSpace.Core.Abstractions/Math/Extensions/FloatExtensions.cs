using System.Runtime.CompilerServices;

namespace StepsInSpace.Core.Abstractions.Math.Extensions;

public static class FloatExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float ToRadians(this float degree)
        => (float) (degree * System.Math.PI / 180F);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float ToDegree(this float radians)
        => (float) (radians * 180F / System.Math.PI);
}