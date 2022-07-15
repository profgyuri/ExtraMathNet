namespace ExtraMathNet.Geometry.Extensions;

using ExtraMathNet.Geometry.Shapes;

public static class TriangleExtensions
{
    /// <summary>
    ///     Determines if the triangle can be drawn based on the size of it's sides.
    /// </summary>
    public static bool IsValid(this Triangle t)
    {
        var sideA = t.B.GetDistanceFrom(t.C);
        var sideB = t.A.GetDistanceFrom(t.C);
        var sideC = t.B.GetDistanceFrom(t.A);

        return !(sideA + sideB < sideC || sideB + sideC < sideA || sideA + sideC < sideB);
    }

    /// <summary>
    ///     Gets the angles of the triangle, if all sides are provided.
    /// </summary>
    /// <param name="precision">The number of fractional digits in the return value.</param>
    /// <returns>A tuple representing alpha, beta and gamma angles respectively in degrees.</returns>
    public static (double, double, double) GetAngles(this Triangle t, byte precision)
    {
        var sideA = t.B.GetDistanceFrom(t.C);
        var sideB = t.A.GetDistanceFrom(t.C);
        var sideC = t.B.GetDistanceFrom(t.A);

        var angleA = Math.Acos((Math.Pow(sideB, 2) + Math.Pow(sideC, 2) - Math.Pow(sideA, 2)) / (2 * sideB * sideC)) * 180 / Math.PI;
        var angleB = Math.Acos((Math.Pow(sideA, 2) + Math.Pow(sideC, 2) - Math.Pow(sideB, 2)) / (2 * sideA * sideC)) * 180 / Math.PI;
        var angleC = Math.Acos((Math.Pow(sideA, 2) + Math.Pow(sideB, 2) - Math.Pow(sideC, 2)) / (2 * sideA * sideB)) * 180 / Math.PI;

        angleA = Math.Round(angleA, precision);
        angleB = Math.Round(angleB, precision);
        angleC = Math.Round(angleC, precision);

        return (angleA, angleB, angleC);
    }
}
