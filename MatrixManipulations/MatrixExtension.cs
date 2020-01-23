using System;

namespace MatrixManipulations
{
    /// <summary>
    /// Matrix manipulation.
    /// </summary>
    public static class MatrixExtension
    {
        /// <summary>
        /// Method fills the matrix with natural numbers, starting from 1 in the top-left corner,
        /// increasing in an inward, clockwise spiral order.
        /// </summary>
        /// <param name="size">Matrix order.</param>
        /// <returns>Filled matrix.</returns>
        /// <exception cref="ArgumentException">Throw ArgumentException, if matrix order less or equal zero.</exception>
        /// <example> size = 3
        ///     1 2 3
        ///     8 9 4
        ///     7 6 5.
        /// </example>
        /// <example> size = 4
        ///     1  2  3  4
        ///     12 13 14 5
        ///     11 16 15 6
        ///     10 9  8  7.
        /// </example>
        public static int[,] GetMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Matrix order must be more than 0", nameof(size));
            }

            int[,] matrix = new int[size, size];
            int row = 0;
            int column = 0;
            int dx = 1; // used to change direction. 1 0 -1 0
            int dy = 0; // used to change direction. 0 1 0 -1
            int dirChanges = 0;
            int switcher;
            int visits = size; // amount of values, that will be set before changing direction.

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[row, column] = i + 1;
                if (--visits == 0)
                {
                    visits = (size * (dirChanges % 2)) + (size * ((dirChanges + 1) % 2)) - ((dirChanges / 2) - 1) - 2; // finds amount of values, that will be set before changing direction.
                    switcher = dx;
                    dx = -dy;
                    dy = switcher; // change direction.
                    dirChanges++;
                }

                column += dx;
                row += dy;
            }

            return matrix;
        }
    }
}