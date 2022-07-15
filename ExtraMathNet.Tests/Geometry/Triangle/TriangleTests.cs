namespace ExtraMathNet.Tests.Geometry.Triangle;

using ExtraMathNet.Geometry;
using ExtraMathNet.Geometry.Shapes;
using ExtraMathNet.Geometry.Extensions;
using NUnit.Framework;

[TestFixture]
public class TriangleTests
{
    [TestCase(0, 0, 0, 1, 1, 0)]
    [TestCase(0, 0, 0, 10, 2, 8)]
    public void IsValidIdentifiesCorrectly(double a, double b, double c, double d, double e, double f)
    {
        var t = new Triangle(new Point2D(a, b), new Point2D(c, d), new Point2D(e, f));
        Assert.That(t.IsValid(), Is.True);
    }

    [TestCase(0, 0, 0, 1, 1, 0, 90, 45, 45)]
    public void GetAnglesGetsCorrectAngles(double a, double b, double c, double d, double e, double f, double expectedA, double expectedB, double expectedC)
    {
        var t = new Triangle(new Point2D(a, b), new Point2D(c, d), new Point2D(e, f));
        Assert.That(t.GetAngles(10), Is.EqualTo((expectedA, expectedB, expectedC)));
    }
}
