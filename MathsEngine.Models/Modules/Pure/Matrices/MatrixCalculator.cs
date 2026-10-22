using MathsEngine.Core.Utils.Exceptions;

namespace MathsEngine.Core.Modules.Pure.Matrices
{
    public static class MatrixCalculator
    {
        /// <summary>
        /// A method to take add or subtract matrices together based on user input
        /// </summary>
        /// <param name="matrix1"> The matrix that will be subtracted from or added to. </param>
        /// <param name="matrix2"> The matrix that will be subtracted by or added to. </param>
        public static MatrixBase AddMatrix(MatrixBase matrix1, MatrixBase matrix2)
        {
            if (matrix1 == null || matrix2 == null)
                throw new NullInputException();
            if (MatrixBase.IsNull(matrix1)|| MatrixBase.IsNull(matrix2))
                throw new NullInputException();

            if (matrix1.NumRows != matrix2.NumRows || matrix1.NumCols != matrix2.NumCols)
                throw new IncompatibleMatrixAdditionException();

            var result = new double[matrix1.NumRows, matrix1.NumCols];

            for(int i = 0; i <  matrix1.NumRows; i++)
            {
                for(int j = 0; j < matrix1.NumCols; j++)
                {
                    result[i, j] = matrix1.Matrix[i, j] + matrix2.Matrix[i, j];
                }
            }
            return new MatrixBase(result);
        }

        public static MatrixBase SubtractMatrix(MatrixBase matrix1, MatrixBase matrix2)
        {
            if (matrix1 == null || matrix2 == null)
                throw new NullInputException();
            if (MatrixBase.IsNull(matrix1) || MatrixBase.IsNull(matrix2))
                throw new NullInputException();

            if (matrix1.NumRows != matrix2.NumRows || matrix1.NumCols != matrix2.NumCols)
                throw new IncompatibleMatrixSubtractionException();

            var result = new double[matrix1.NumRows, matrix1.NumCols];

            for (int i = 0; i < matrix1.NumRows; i++)
            {
                for (int j = 0; j < matrix1.NumCols; j++)
                {
                    result[i, j] = matrix1.Matrix[i, j] - matrix2.Matrix[i, j];
                }
            }
            return new MatrixBase(result);
        }


        /// <summary>
        /// Multiplying or dividing, all the values in a matrix by an integer
        /// </summary>
        /// <param name="matrix"> The matrix being multiplied by. </param>
        /// <param name="number"> The number to multiply the matrix by. </param>
        /// <returns> The result of the matrix * number.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static MatrixBase ScalarMultiplication(MatrixBase matrix, double number)
        {
            if (MatrixBase.IsNull(matrix))
                throw new NullInputException();

            var result = new double[matrix.NumRows, matrix.NumCols];

            for (int i = 0; i < matrix.NumRows; i++)
            {
                for (int j = 0; j < matrix.NumCols; j++)
                {
                    result[i, j] = matrix.Matrix[i, j] * number;
                }
            }
            return new MatrixBase(result);
        }

        public static MatrixBase ScalarDivision(MatrixBase matrix, double number)
        {
            if (MatrixBase.IsNull(matrix))
                throw new NullInputException();

            if (number == 0)
                throw new DivideByZeroException();

            var result = new double[matrix.NumRows, matrix.NumCols];

            for (int i = 0; i < matrix.NumRows; i++)
            {
                for (int j = 0; j < matrix.NumCols; j++)
                {
                    result[i, j] = matrix.Matrix[i, j] / number;
                }
            }
            return new MatrixBase(result);
        }

        /// <summary>
        /// A method to multiply matrices. They multiply by going across rows and down columns
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static MatrixBase MatrixMultiplication(MatrixBase matrix1, MatrixBase matrix2)
        {
            if (!IsValidForMultiplication(matrix1, matrix2))
                throw new IncompatibleMatrixMultiplicationException();

            double[,] result = new double[matrix1.NumRows, matrix2.NumCols];

            for (int i = 0; i < matrix1.NumRows; i++)
            {
                for (int j = 0; j < matrix2.NumCols; j++)
                {
                    double sum = 0;

                    for (int k = 0; k < matrix1.NumCols; k++)
                    {
                        sum += matrix1.Matrix[i, k] * matrix2.Matrix[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return new MatrixBase(result);
        }

        /// <summary>
        /// Checks if matrices are compatible for multiplication.
        /// The number of columns for matrix 1 must equal the number of rows for matrix 2
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private static bool IsValidForMultiplication(MatrixBase matrix1, MatrixBase matrix2)
        {
            if (matrix1 == null || matrix2 == null)
                throw new NullInputException();

            if (matrix1.NumCols == matrix2.NumRows)
                return true;
            return false;
        }
    }
}