using ExtraMathNet.LinAlg;
using NUnit.Framework;
using System;

namespace ExtraMathNet.Tests.LinAlg.Matrices;

[TestFixture]
public class ChecksTests 
{
    Random rnd;

    [SetUp]
    public void Setup()
    {
        rnd = new Random();
    }

    [Test]
    public void IsSquare_ReturnsTrue_ForSquareMatrix()
    {
        var square = Matrix.Create(3, 3);

        Assert.That(Matrix.IsSquare(square));
    }

    [Test]
    public void IsSquare_ReturnsFalse_ForNonSquareMatrix()
    {
        var rectangle = Matrix.Create(4, 3);

        Assert.That(Matrix.IsSquare(rectangle), Is.False);
    }

    [Test]
    public void IsDiagonal_ReturnsTrue_ForDiagonalMatrix()
    {
        var diagonal = Matrix.Create(3, 3, (i, j) => i == j ? rnd.Next(10) : 0);

        Assert.That(Matrix.IsDiagonal(diagonal));
    }

    [Test]
    public void IsDiagonal_ReturnsFalse_ForNonDiagonalSquareMatrix()
    {
        var nonDiagonal = Matrix.Create(3, 3, (i, j) => rnd.Next(10));

        Assert.That(Matrix.IsDiagonal(nonDiagonal), Is.False);
    }

    [Test]
    public void IsDiagonal_ReturnsFalse_ForNonSquareMatrix()
    {
        var rectangle = Matrix.Create(4, 3);

        Assert.That(Matrix.IsDiagonal(rectangle), Is.False);
    }

    [Test]
    public void IsIdentity_ReturnsTrue_ForIdentityMatrix()
    {
        var identity = Matrix.Create(3, 3, (i, j) => i == j ? 1 : 0);

        Assert.That(Matrix.IsIdentity(identity));
    }

    [Test]
    public void IsIdentity_ReturnsFalse_ForNonIdentityDiagonalMatrix()
    {
        var nonIdentity = Matrix.Create(new double[] { 1, 1, 2 });

        Assert.That(Matrix.IsIdentity(nonIdentity), Is.False);
    }

    [Test]
    public void IsIdentity_ReturnsFalse_ForNonDiagonalMatrix()
    {
        var nonIdentity = Matrix.Create(3, 3, (i, j) => rnd.Next(10));

        Assert.That(Matrix.IsIdentity(nonIdentity), Is.False);
    }

    [Test]
    public void IsIdentity_ReturnsFalse_ForNonSquareMatrix()
    {
        var nonIdentity = Matrix.Create(3, 2, (i, j) => rnd.Next(10));

        Assert.That(Matrix.IsIdentity(nonIdentity), Is.False);
    }

    [Test]
    public void IsScalar_ReturnsTrue_ForScalarMatrix()
    {
        var scalar = Matrix.Create(3, 3, (i, j) => (i == j) ? 2 : 0);

        Assert.That(Matrix.IsScalar(scalar));
    }

    [Test]
    public void IsScalar_ReturnsFalse_ForNonScalarMatrix()
    {
        var nonScalar = Matrix.Create(3, 3, (i, j) => (i == j) ? i + j : 0);

        Assert.That(Matrix.IsScalar(nonScalar), Is.False);
    }

    [Test]
    public void IsScalar_ReturnsFalse_ForNonDiagonalSquareMatrix()
    {
        var nonScalar = Matrix.Create(3, 3, (i, j) => rnd.Next(10));

        Assert.That(Matrix.IsScalar(nonScalar), Is.False);
    }

    [Test]
    public void IsScalar_ReturnsFalse_ForNonSquareMatrix()
    {
        var nonScalar = Matrix.Create(3, 4, (i, j) => rnd.Next(10));

        Assert.That(Matrix.IsScalar(nonScalar), Is.False);
    }

    [Test]
    public void IsSymmetric_ReturnsTrue_ForSymmetricMatrix()
    {
        var symmetric = new double[,] 
        { 
            { 1, 2, 3 }, 
            { 2, 4, 6 }, 
            { 3, 6, 9 } 
        };

        Assert.That(Matrix.IsSymmetric(symmetric));
    }
    
    [Test]
    public void IsSymmetric_ReturnsFalse_ForNonSymmetricMatrix()
    {
        var nonSymmetric = new double[,] 
        { 
            { 1, 2, 3 }, 
            { 2, 4, 5 }, 
            { 3, 6, 9 }
        };

        Assert.That(Matrix.IsSymmetric(nonSymmetric), Is.False);
    }
    
    [Test]
    public void IsSymmetric_ReturnsFalse_ForNonSquareMatrix()
    {
        var nonSymmetric = Matrix.Create(3, 2);

        Assert.That(Matrix.IsSymmetric(nonSymmetric), Is.False);
    }
    
    [Test]
    public void IsAsymmetric_ReturnsTrue_ForAsymmetricMatrix()
    {
        var asymmetric = new double[,] 
        { 
            { 1, -2, -3 }, 
            { 2, 4, -6 }, 
            { 3, 6, 9 }
        };

        Assert.That(Matrix.IsAsymmetric(asymmetric));
    }

    [Test]
    public void IsAsymmetric_ReturnsFalse_ForNonAsymmetricMatrix()
    {
        var nonAsymmetric = new double[,] 
        { 
            { 1, -2, -3 }, 
            { 2, 4, -5 }, 
            { 3, 6, 9 }
        };

        Assert.That(Matrix.IsAsymmetric(nonAsymmetric), Is.False);
    }

    [Test]
    public void IsAsymmetric_ReturnsFalse_ForNonSquareMatrix()
    {
        var nonAsymmetric = Matrix.Create(3, 2);

        Assert.That(Matrix.IsAsymmetric(nonAsymmetric), Is.False);
    }
    
    [Test]
    public void IsUpperTriangular_ReturnsTrue_ForUpperTriangularMatrix()
    {
        var upperTriangular = Matrix.Create(3, 3, (i, j) => i > j ? 0 : rnd.Next(10));

        Assert.That(Matrix.IsUpperTriangular(upperTriangular));
    }
    
    [Test]
    public void IsUpperTriangular_ReturnsFalse_ForNonUpperTriangularMatrix()
    {
        var nonUpperTriangular = new double[,] 
        { 
            { 1, 2, 3 }, 
            { 0, 4, 5 }, 
            { 3, 0, 9 }
        };

        Assert.That(Matrix.IsUpperTriangular(nonUpperTriangular), Is.False);
    }

    [Test]
    public void IsUpperTriangular_ReturnsFalse_ForNonSquareMatrix()
    {
        var nonUpperTriangular = Matrix.Create(3, 2);

        Assert.That(Matrix.IsUpperTriangular(nonUpperTriangular), Is.False);
    }
    
    [Test]
    public void IsLowerTriangular_ReturnsTrue_ForLowerTriangularMatrix()
    {
        var lowerTriangular = Matrix.Create(3, 3, (i, j) => i < j ? 0 : rnd.Next(10));

        Assert.That(Matrix.IsLowerTriangular(lowerTriangular));
    }
    
    [Test]
    public void IsLowerTriangular_ReturnsFalse_ForNonLowerTriangularMatrix()
    {
        var nonLowerTriangular = new double[,] 
        { 
            { 1, 0, 0 }, 
            { 2, 4, 5 }, 
            { 3, 5, 9 }
        };

        Assert.That(Matrix.IsLowerTriangular(nonLowerTriangular), Is.False);
    }
    
    [Test]
    public void IsLowerTriangular_ReturnsFalse_ForNonSquareMatrix()
    {
        var nonLowerTriangular = Matrix.Create(3, 2);

        Assert.That(Matrix.IsLowerTriangular(nonLowerTriangular), Is.False);
    }
}