namespace ExtraMathNet.Geometry.Points;

public static class PointOperations
{
    /// <summary>
    ///     Gets the distance between 2 points.
    /// </summary>
    public static double GetDistance(Point2D A, Point2D B)
    {
        var sum = Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2);
        return Math.Sqrt(sum);
    }

    /// <summary>
    ///     Gets the distance between 2 points.
    /// </summary>
    public static double GetDistance(Point3D A, Point3D B)
    {
        var sum = Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2) + Math.Pow(A.Z - B.Z, 2);
        return Math.Sqrt(sum);
    }
}
