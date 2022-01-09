namespace StepsInSpace.Core.Abstractions.Math;

public interface IMatrix4dFactory
{
    Matrix4d Create(
        float m00, float m01, float m02, float m03,
        float m10, float m11, float m12, float m13,
        float m20, float m21, float m22, float m23,
        float m30, float m31, float m32, float m33);

    Matrix4d Create(Vector4d row0, Vector4d row1, Vector4d row2, Vector4d row3);
    
    Matrix4d Create(Quaternion row0, Quaternion row1, Quaternion row2, Quaternion row3);

    Matrix4d CreatePerspectiveFieldOfView(float fovy, float aspect, float near, float far);
    
    Matrix4d CreatePerspectiveOfCenter(float left, float right, float bottom, float top, float near, float far);
}