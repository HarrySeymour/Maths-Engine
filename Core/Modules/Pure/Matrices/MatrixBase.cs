using Core.Utils.Exceptions;

namespace Core.Modules.Pure.Matrices
{
    public class MatrixBase : IEquatable<int[,]>
    {
        public int NumRows { get; }
        public int NumCols { get; }
        public double[,] Matrix { get; }

        public MatrixBase(int rows, int cols)
        {
            if (rows > 0 && cols > 0)
            {
                NumRows = rows;
                NumCols = cols;
                Matrix = new double[NumRows, NumCols];
            }
            else
                throw new ArgumentException("Matrix cannot have negative side");
        }

        public MatrixBase(double[,] array)
        {
            NumRows = array.GetLength(0);
            NumCols = array.GetLength(1);
            Matrix = array;
        }

        /// <summary>
        /// A method that provides the identity matrix for a square matrix of the given size
        /// </summary>
        public static MatrixBase GetIdentityMatrix(int size)
        {
            if (size <= 0)
                throw new ArgumentException();

            var identityMatrix = new MatrixBase(size, size);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    identityMatrix.Matrix[i, j] = (i == j) ? 1 : 0;
                }
            }
            return identityMatrix;
        }

        public static bool IsNull(MatrixBase matrix)
        {
            if (matrix.Matrix.GetLength(0) == 0)
                return true;
            if (matrix.Matrix.GetLength(1) == 0)
                return true;
            return false;
        }

        /// <summary>
        /// Calculates the determinant for any given matrix 2D. ***AD - BC***
        /// </summary>
        public double CalculateDeterminant()
        {
            if (Matrix == null)
                throw new NullInputException();

            if (NumCols != 2 || NumRows != 2)
                throw new NotSquareMatrixException("Must be a 2x2 Square matrix");

            double ad = Matrix[0, 0] * Matrix[1, 1];
            double bc = Matrix[0, 1] * Matrix[1, 0];

            return ad - bc;
        }

        // public MatrixBase CalculateInverseMatrix() {}

        public bool Equals(int[,]? other)
        {
            if (other is null) return false;
            if (NumRows != other.GetLength(0) || NumCols != other.GetLength(1)) return false;

            for (int i = 0; i < NumRows; i++)
            {
                for (int j = 0; j < NumCols; j++)
                {
                    if (Matrix[i, j] != other[i, j]) return false;
                }
            }

            return true;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not MatrixBase) return false;
            if (NumRows != ((MatrixBase)obj).NumRows || NumCols != ((MatrixBase)obj).NumCols) return false;

            for (int i = 0; i < NumRows; i++)
            {
                for (int j = 0; j < NumCols; j++)
                {
                    if (Matrix[i, j]  != ((MatrixBase)obj).Matrix[j, i]) return false;
                }
            }

            return true;
        }
    }
}