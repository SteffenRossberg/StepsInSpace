namespace Boncuk.Core.Abstractions.Math.Extensions;

public static class Matrix4dExtensions
{
    public static Matrix4d Multiply(this Matrix4d left, Matrix4d right)
    {
        var row0 = left.Row0;
        var row1 = left.Row1;
        var row2 = left.Row2;
        var row3 = left.Row3;

        var column0 = right.Column0;
        var column1 = right.Column1;
        var column2 = right.Column2;
        var column3 = right.Column3;

        Matrix4d matrix = new(
            row0.Dot(column0), row0.Dot(column1), row0.Dot(column2), row0.Dot(column3),
            row1.Dot(column0), row1.Dot(column1), row1.Dot(column2), row1.Dot(column3),
            row2.Dot(column0), row2.Dot(column1), row2.Dot(column2), row2.Dot(column3),
            row3.Dot(column0), row3.Dot(column1), row3.Dot(column2), row3.Dot(column3));

        return matrix;
    }

    public static float[] ToArray(this Matrix4d source)
        => new[]
        {
            source.M00, source.M01, source.M02, source.M03,
            source.M10, source.M11, source.M12, source.M13,
            source.M20, source.M21, source.M22, source.M23,
            source.M30, source.M31, source.M32, source.M33,
        };
}