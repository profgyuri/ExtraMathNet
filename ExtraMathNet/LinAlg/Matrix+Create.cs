namespace ExtraMathNet.LinAlg;

public static partial class Matrix
{
    /// <summary>
    ///     Creates an n*m matrix with all values set to the same number.
    /// </summary>
    /// <param name="rows">Number of rows in the matrix.</param>
    /// <param name="columns">Number of columns in the matrix.</param>
    /// <param name="value">Default value of each cell.</param>
    /// <returns>2D array of doubles representing a matrix.</returns>
    public static double[,] Create(int rows, int columns, double value = 0.0)
    {
        var matrix = new double[rows, columns];
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                matrix[i, j] = value;
            }
        }

        return matrix;
    }

    /// <summary>
    ///     Creates an n*m matrix with all values set to with a function.
    /// </summary>
    /// <param name="rows">Number of rows in the matrix.</param>
    /// <param name="columns">Number of columns in the matrix.</param>
    /// <param name="value">Function to set each cell to.</param>
    /// <returns>2D array of doubles representing a matrix.</returns>
    public static double[,] Create(int rows, int columns, Func<int, int, double> value)
    {
        var matrix = new double[rows, columns];
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                matrix[i, j] = value(i, j);
            }
        }

        return matrix;
    }

    /// <summary>
    ///     Creates a diagonal matrix with the given diagonal values.
    /// </summary>
    /// <param name="diagonalValues">The values of the diagonal.</param>
    /// <returns>A diagonal matrix.</returns>
    public static double[,] Create(double[] diagonalValues)
    {
        var matrix = new double[diagonalValues.Length, diagonalValues.Length];
        for (var i = 0; i < diagonalValues.Length; i++)
        {
            matrix[i, i] = diagonalValues[i];
        }

        return matrix;
    }
}