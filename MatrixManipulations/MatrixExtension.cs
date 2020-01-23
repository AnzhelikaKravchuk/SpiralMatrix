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
                throw new ArgumentException("Zize cannot be zero or negative.");
            }

            int[,] array = new int[size, size];

            int numbers = 1;
            int i = 0;
            int j = 0;
            while (numbers <= size * size)
            {
                array[i, j] = numbers;
                if (i <= j + 1 && i + j < size - 1)
                {
                    ++j;
                }
                else if (i < j && i + j >= size - 1)
                {
                    ++i;
                }
                else if (i >= j && i + j > size - 1)
                {
                    --j;
                }
                else
                {
                    --i;
                }

                ++numbers;
            }

            return array;
        }
    }
}