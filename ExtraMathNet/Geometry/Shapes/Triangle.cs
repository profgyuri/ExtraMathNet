namespace ExtraMathNet.Geometry.Shapes;

public class Triangle
{
    public Point2D A { get; set; }
    public Point2D B { get; set; }
    public Point2D C { get; set; }

    public Triangle(Point2D a, Point2D b, Point2D c)
    {
        A = a;
        B = b;
        C = c;
    }
}
