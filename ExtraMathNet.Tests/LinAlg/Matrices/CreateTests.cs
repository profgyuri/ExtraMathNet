using NUnit.Framework;
using ExtraMathNet.LinAlg;
using System;

namespace ExtraMathNet.Tests.LinAlg.Matrices;

[TestFixture]
public class CreateTests 
{
    [Test]
    public void CreateWithDefaultValues() 
    {
        var actual = Matrix.Create(2, 3, 2.0);
        var expected = new double[,]
        {
            { 2, 2, 2 },
            { 2, 2, 2 }
        };

        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void CreateWithFunc()
    {
        var rnd = new Random();
        var actual = Matrix.Create(2, 3, (i, j) => rnd.Next(10) + rnd.NextDouble());

        Assert.That(actual, Is.Unique);
    }

    [Test]
    public void CreateDiagonal()
    {
        var actual = Matrix.Create(new double[]{ 1, 2, 3 });
        var expected = new double[,]
        {
            { 1, 0, 0 },
            { 0, 2, 0 },
            { 0, 0, 3 }
        };

        Assert.That(actual, Is.EquivalentTo(expected));
    }
}