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
            if (size == 0)
            {
                throw new ArgumentException("size must not be empty");
            }

            if (size < 0)
            {
                throw new ArgumentException("size must be positive");
            }

            int sizeRow, sizeColumn, startRow = 0, startColumn = 0, endRow = size, endColumn = size;
            if (size % 2 == 0)
            {
                sizeRow = size / 2;
                sizeColumn = (size / 2) - 1;
            }
            else
            {
                sizeRow = size / 2;
                sizeColumn = size / 2;
            }

            int[,] array = new int[size, size];
            for (int i = 0, j = 0, p = 1; i <= sizeRow && j <= sizeColumn; i++, j++, endColumn--, endRow--, startColumn++, startRow++)
            {
                while (j < endColumn)
                {
                    array[i, j] = p++;
                    j++;
                }

                j--;
                i++;
                while (i < endRow)
                {
                    array[i, j] = p++;
                    i++;
                }

                i--;
                j--;
                while (j >= startColumn)
                {
                    array[i, j] = p++;
                    j--;
                }

                j++;
                i--;
                while (i > startRow)
                {
                    array[i, j] = p++;
                    i--;
                }
            }

            return array;
        }
    }
}