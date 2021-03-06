using StepsInSpace.Core.Abstractions.Math;
using StepsInSpace.Core.Abstractions.Math.Extensions;

namespace StepsInSpace.Core.Math;

public class Matrix4dFactory : IMatrix4dFactory
{
    public Matrix4d Create(
        float m00, float m01, float m02, float m03,
        float m10, float m11, float m12, float m13,
        float m20, float m21, float m22, float m23,
        float m30, float m31, float m32, float m33)
        => new(
            m00, m01, m02, m03,
            m10, m11, m12, m13,
            m20, m21, m22, m23,
            m30, m31, m32, m33);

    public Matrix4d Create(
        Vector4d row0,
        Vector4d row1,
        Vector4d row2,
        Vector4d row3)
        => Create(
            row0.X, row0.Y, row0.Z, row0.W,
            row1.X, row1.Y, row1.Z, row1.W,
            row2.X, row2.Y, row2.Z, row2.W,
            row3.X, row3.Y, row3.Z, row3.W);

    public Matrix4d Create(
        Quaternion row0, 
        Quaternion row1, 
        Quaternion row2, 
        Quaternion row3)
        => Create(
            row0.X, row0.Y, row0.Z, row0.W,
            row1.X, row1.Y, row1.Z, row1.W,
            row2.X, row2.Y, row2.Z, row2.W,
            row3.X, row3.Y, row3.Z, row3.W);

    public Matrix4d CreatePerspectiveFieldOfView(
        float fovy, 
        float aspect, 
        float near, 
        float far)
    {
        var top = (float)(near * System.Math.Tan(0.5F * fovy));
        var bottom = -top;
        var left = bottom * aspect;
        var right = top * aspect;
        
        return CreatePerspectiveOfCenter(left, right, bottom, top, near, far);
    }

    public Matrix4d CreatePerspectiveOfCenter(
        float left, 
        float right, 
        float bottom, 
        float top, 
        float near,
        float far)
    {
        var horizontalRange = right - left;
        var verticalRange = top - bottom;
        var depthRange = far - near;
        var x = 2F * near / horizontalRange;
        var y = 2F * near / verticalRange;
        var a = (right + left) / horizontalRange;
        var b = (top + bottom) / verticalRange;
        var c = -(far + near) / depthRange;
        var d = -(2F * far * near) / depthRange;

        return Create(
            x, 0, 0, 0,
            0, y, 0, 0,
            a, b, c, -1,
            0, 0, d, 0);
    }
}