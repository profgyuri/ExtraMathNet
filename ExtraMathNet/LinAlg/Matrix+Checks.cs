namespace ExtraMathNet.LinAlg;

public static partial class Matrix
{
    /// <summary>
    ///     Gets if the matrix is a Square matrix.
    /// </summary>
    /// <param name="matrix">Input matrix for the check.</param>
    /// <returns>True, if the matrix has the same amount of rows as columns.</returns>
    public static bool IsSquare(double [,] matrix)
    {
        return matrix.GetLength(0) == matrix.GetLength(1);
    }
    
    /// <summary>
    ///    Gets if the matrix is diagonal.
    /// </summary>
    /// <param name="matrix">Input matrix for the check.</param>
    /// <returns>True, if the matrix is diagonal.</returns>
    /// <remarks>
    ///     A matrix is diagonal if it has the same amount of rows and columns
    ///     and only the elements on the diagonal are not zero.
    ///  </remarks>
    public static bool IsDiagonal(double [,] matrix)
    {
        if (!IsSquare(matrix))
        {
            return false;
        }

        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                if (i != j && matrix[i, j] != 0)
                {
                    return false;
                }
            }
        }
        
        return true;
    }
    
    /// <summary>
    ///    Gets if the matrix is Identity.
    /// </summary>
    /// <param name="matrix">Input matrix for the check.</param>
    /// <returns>True, if the matrix is Identity.</returns>
    /// <remarks>
    ///    A matrix is Identity if it is diagonal and all elements on the diagonal are 1.
    /// </remarks>
    public static bool IsIdentity(double [,] matrix)
    {
        if (!IsDiagonal(matrix))
        {
            return false;
        }
        
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, i] != 1)
            {
                return false;
            }
        }
        
        return true;
    }
    
    /// <summary>
    ///    Gets if the matrix is Scalar.
    /// </summary>
    /// <param name="matrix">Input matrix for the check.</param>
    /// <returns>True, if the matrix is Scalar matrix.</returns>
    /// <remarks>
    ///    Scalar matrix is an identity matrix multiplied with a scalar.
    /// </remarks>
    public static bool IsScalar(double [,] matrix)
    {
        var baseValue = matrix[0, 0];
        
        if (baseValue == 0 || !IsDiagonal(matrix))
        {
            return false;
        }

        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, i] != baseValue)
            {
                return false;
            }
        }
        
        return true;
    }
    
    /// <summary>
    ///    Gets if the matrix is Symmetric.
    /// </summary>
    /// <param name="matrix">Input matrix for the check.</param>
    /// <returns>True, if the matrix is Symmetric.</returns>
    /// <remarks>
    ///    A matrix is Symmetric if it is equal to its transpose.
    /// </remarks>
    public static bool IsSymmetric(double [,] matrix)
    {
        if (!IsSquare(matrix))
        {
            return false;
        }
        
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] != matrix[j, i])
                {
                    return false;
                }
            }
        }
        
        return true;
    }
    
    /// <summary>
    ///    Gets if the matrix is Asymmetric.
    /// </summary>
    /// <param name="matrix">Input matrix for the check.</param>
    /// <returns>True, if the matrix is Asymmetric.</returns>
    /// <remarks>
    ///    A matrix is Asymmetric if it is equal to its transpose multiplied by -1.
    /// </remarks>
    public static bool IsAsymmetric(double [,] matrix)
    {
        if (!IsSquare(matrix))
        {
            return false;
        }
        
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                if (i != j && matrix[i, j] != -matrix[j, i])
                {
                    return false;
                }
            }
        }
        
        return true;
    }
    
    /// <summary>
    ///    Gets if the matrix is Upper Triangular.
    /// </summary>
    /// <param name="matrix">Input matrix for the check.</param>
    /// <returns>True, if the matrix is Upper Triangular.</returns>
    /// <remarks>
    ///    A matrix is Upper Triangular if all elements below the diagonal are 0.
    /// </remarks>
    public static bool IsUpperTriangular(double [,] matrix)
    {
        if (!IsSquare(matrix))
        {
            return false;
        }
        
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                if (i > j && matrix[i, j] != 0)
                {
                    return false;
                }
            }
        }
        
        return true;
    }
    
    /// <summary>
    ///    Gets if the matrix is Lower Triangular.
    /// </summary>
    /// <param name="matrix">Input matrix for the check.</param>
    /// <returns>True, if the matrix is Lower Triangular.</returns>
    /// <remarks>
    ///    A matrix is Lower Triangular if all elements above the diagonal are 0.
    /// </remarks>
    public static bool IsLowerTriangular(double [,] matrix)
    {
        if (!IsSquare(matrix))
        {
            return false;
        }
        
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                if (i < j && matrix[i, j] != 0)
                {
                    return false;
                }
            }
        }
        
        return true;
    }
}