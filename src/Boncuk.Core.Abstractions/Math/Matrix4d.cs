namespace Boncuk.Core.Abstractions.Math;

public readonly struct Matrix4d
{
    public readonly float M00, M01, M02, M03;
    public readonly float M10, M11, M12, M13;
    public readonly float M20, M21, M22, M23;
    public readonly float M30, M31, M32, M33;

    public Matrix4d(
        float m00, float m01, float m02, float m03,
        float m10, float m11, float m12, float m13,
        float m20, float m21, float m22, float m23,
        float m30, float m31, float m32, float m33
    ) => (
        M00, M01, M02, M03,
        M10, M11, M12, M13,
        M20, M21, M22, M23,
        M30, M31, M32, M33
    ) = (
        m00, m01, m02, m03,
        m10, m11, m12, m13,
        m20, m21, m22, m23,
        m30, m31, m32, m33
    );

    public Matrix4d(
        Vector4d row0,
        Vector4d row1,
        Vector4d row2,
        Vector4d row3
    ) => (
        M00, M01, M02, M03,
        M10, M11, M12, M13,
        M20, M21, M22, M23,
        M30, M31, M32, M33
    ) = (
        row0.X, row0.Y, row0.Z, row0.W,
        row1.X, row1.Y, row1.Z, row1.W,
        row2.X, row2.Y, row2.Z, row2.W,
        row3.X, row3.Y, row3.Z, row3.W
    );

    public Vector4d Row0 => new(M00, M01, M02, M03);
    public Vector4d Row1 => new(M10, M11, M12, M13);
    public Vector4d Row2 => new(M20, M21, M22, M23);
    public Vector4d Row3 => new(M30, M31, M32, M33);

    public Vector4d Column0 => new(M00, M10, M20, M30);
    public Vector4d Column1 => new(M01, M11, M21, M31);
    public Vector4d Column2 => new(M02, M12, M22, M32);
    public Vector4d Column3 => new(M03, M13, M23, M33);

    public static readonly Matrix4d Identity =
        new(1, 0, 0, 0,
            0, 1, 0, 0,
            0, 0, 1, 0,
            0, 0, 0, 1);
}