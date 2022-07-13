namespace ExtraMathNet.Tests.Geometry.Points;

using ExtraMathNet.Geometry;
using ExtraMathNet.Geometry.Points;
using NUnit.Framework;
using System;

[TestFixture]
public class PointOperationTests
{
    [TestCase(0, 2, 2, 2, 2)]
    [TestCase(-5, 0, 5, 0, 10)]
    public void GetDistance_ReturnsCorrectValue(double Ax, double Ay, double Bx, double By, double expected)
    {
        var actual = PointOperations.GetDistance(new Point2D(Ax, Ay), new Point2D(Bx, By));

        Assert.That(actual, Is.EqualTo(expected));
    }
}
