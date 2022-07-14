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
}
