using System.Text;
using Core.Explanations.Models.Base;
using Core.Modules.Pure.Matrices;

namespace Core.Explanations.Pure.Matrices;

/// <summary>
/// Provides step-by-step explanations for matrix calculations.
/// </summary>
/// 
public static class MatrixTutor
{
    public static MatrixCalculationResult AddMatrixWithSteps(MatrixBase matrix1, MatrixBase matrix2)
    {
        var steps = new List<string>();

        steps.Add("Step 1: Verify matrix dimensions are compatible for addition");
        steps.Add($"  Matrix 1: {matrix1.NumRows}×{matrix1.NumCols}");
        steps.Add($"  Matrix 2: {matrix2.NumRows}×{matrix2.NumCols}");
        
        if (matrix1.NumRows != matrix2.NumRows || matrix1.NumCols != matrix2.NumCols)
        {
            steps.Add($"  ERROR: Matrices must have the same dimensions!");
        }
        else
        {
            steps.Add($"  ✓ Both matrices are {matrix1.NumRows}×{matrix1.NumCols}");
        }
        steps.Add("");

        steps.Add("Step 2: Add corresponding elements");
        steps.Add("  Formula: C[i,j] = A[i,j] + B[i,j]");
        steps.Add("");

        MatrixBase result = MatrixCalculator.AddMatrix(matrix1, matrix2);

        steps.Add("Step 3: Show the addition");
        steps.Add(FormatMatrixOperation(matrix1.Matrix, matrix2.Matrix, result.Matrix, "+"));
        steps.Add("");

        steps.Add("Final Answer:");
        steps.Add(FormatMatrix(result.Matrix));

        return new MatrixCalculationResult(result.Matrix, steps);
    }

    public static MatrixCalculationResult SubtractMatrixWithSteps(MatrixBase matrix1, MatrixBase matrix2)
    {
        var steps = new List<string>();

        steps.Add("Step 1: Verify matrix dimensions are compatible for subtraction");
        steps.Add($"  Matrix 1: {matrix1.NumRows}×{matrix1.NumCols}");
        steps.Add($"  Matrix 2: {matrix2.NumRows}×{matrix2.NumCols}");
        
        if (matrix1.NumRows != matrix2.NumRows || matrix1.NumCols != matrix2.NumCols)
        {
            steps.Add($"  ERROR: Matrices must have the same dimensions!");
        }
        else
        {
            steps.Add($"  ✓ Both matrices are {matrix1.NumRows}×{matrix1.NumCols}");
        }
        steps.Add("");

        steps.Add("Step 2: Subtract corresponding elements");
        steps.Add("  Formula: C[i,j] = A[i,j] - B[i,j]");
        steps.Add("");

        MatrixBase result = MatrixCalculator.SubtractMatrix(matrix1, matrix2);

        steps.Add("Step 3: Show the subtraction");
        steps.Add(FormatMatrixOperation(matrix1.Matrix, matrix2.Matrix, result.Matrix, "-"));
        steps.Add("");

        steps.Add("Final Answer:");
        steps.Add(FormatMatrix(result.Matrix));

        return new MatrixCalculationResult(result.Matrix, steps);
    }

    public static MatrixCalculationResult ScalarMultiplicationWithSteps(MatrixBase matrix, double scalar)
    {
        var steps = new List<string>();

        steps.Add("Step 1: Identify the matrix and scalar");
        steps.Add($"  Scalar value: {scalar:F2}");
        steps.Add($"  Matrix dimensions: {matrix.NumRows}×{matrix.NumCols}");
        steps.Add("");

        steps.Add("Step 2: Multiply each element by the scalar");
        steps.Add($"  Formula: C[i,j] = {scalar:F2} × A[i,j]");
        steps.Add("");

        steps.Add("Step 3: Original matrix");
        steps.Add(FormatMatrix(matrix.Matrix));
        steps.Add("");

        MatrixBase result = MatrixCalculator.ScalarMultiplication(matrix, scalar);

        steps.Add("Step 4: After scalar multiplication");
        steps.Add(FormatMatrix(result.Matrix));
        steps.Add("");

        steps.Add("Final Answer:");
        steps.Add(FormatMatrix(result.Matrix));

        return new MatrixCalculationResult(result.Matrix, steps);
    }

    public static MatrixCalculationResult ScalarDivisionWithSteps(MatrixBase matrix, double scalar)
    {
        var steps = new List<string>();

        steps.Add("Step 1: Identify the matrix and scalar");
        steps.Add($"  Scalar value: {scalar:F2}");
        steps.Add($"  Matrix dimensions: {matrix.NumRows}×{matrix.NumCols}");
        steps.Add("");

        if (scalar == 0)
        {
            steps.Add("  ERROR: Cannot divide by zero!");
            throw new DivideByZeroException();
        }

        steps.Add("Step 2: Divide each element by the scalar");
        steps.Add($"  Formula: C[i,j] = A[i,j] / {scalar:F2}");
        steps.Add("");

        steps.Add("Step 3: Original matrix");
        steps.Add(FormatMatrix(matrix.Matrix));
        steps.Add("");

        MatrixBase result = MatrixCalculator.ScalarDivision(matrix, scalar);

        steps.Add("Step 4: After scalar division");
        steps.Add(FormatMatrix(result.Matrix));
        steps.Add("");

        steps.Add("Final Answer:");
        steps.Add(FormatMatrix(result.Matrix));

        return new MatrixCalculationResult(result.Matrix, steps);
    }

    public static MatrixCalculationResult MatrixMultiplicationWithSteps(MatrixBase matrix1, MatrixBase matrix2)
    {
        var steps = new List<string>();

        steps.Add("Step 1: Verify matrix dimensions are compatible for multiplication");
        steps.Add($"  Matrix 1: {matrix1.NumRows}×{matrix1.NumCols}");
        steps.Add($"  Matrix 2: {matrix2.NumRows}×{matrix2.NumCols}");
        
        if (matrix1.NumCols != matrix2.NumRows)
        {
            steps.Add($"  ERROR: Number of columns in Matrix 1 ({matrix1.NumCols}) must equal number of rows in Matrix 2 ({matrix2.NumRows})!");
        }
        else
        {
            steps.Add($"  ✓ Matrix 1 columns ({matrix1.NumCols}) = Matrix 2 rows ({matrix2.NumRows})");
            steps.Add($"  Result will be {matrix1.NumRows}×{matrix2.NumCols}");
        }
        steps.Add("");

        steps.Add("Step 2: Matrix multiplication formula");
        steps.Add("  C[i,j] = Σ(A[i,k] × B[k,j]) for k = 0 to n-1");
        steps.Add("  (Sum of products of row i from Matrix 1 and column j from Matrix 2)");
        steps.Add("");

        MatrixBase result = MatrixCalculator.MatrixMultiplication(matrix1, matrix2);

        steps.Add("Step 3: Calculate each element");
        for (int i = 0; i < matrix1.NumRows; i++)
        {
            for (int j = 0; j < matrix2.NumCols; j++)
            {
                var calculation = new StringBuilder();
                calculation.Append($"  C[{i},{j}] = ");
                
                var terms = new List<string>();
                for (int k = 0; k < matrix1.NumCols; k++)
                {
                    terms.Add($"({matrix1.Matrix[i, k]:F1}×{matrix2.Matrix[k, j]:F1})");
                }
                calculation.Append(string.Join(" + ", terms));
                calculation.Append($" = {result.Matrix[i, j]:F2}");
                steps.Add(calculation.ToString());
            }
        }
        steps.Add("");

        steps.Add("Final Answer:");
        steps.Add(FormatMatrix(result.Matrix));

        return new MatrixCalculationResult(result.Matrix, steps);
    }

    public static ScalarCalculationResult CalculateDeterminantWithSteps(MatrixBase matrix)
    {
        var steps = new List<string>();

        steps.Add("Step 1: Verify matrix is 2×2");
        steps.Add($"  Matrix dimensions: {matrix.NumRows}×{matrix.NumCols}");
        
        if (matrix.NumRows != 2 || matrix.NumCols != 2)
        {
            steps.Add("  ERROR: Determinant calculation only supports 2×2 matrices!");
        }
        else
        {
            steps.Add("  ✓ Matrix is 2×2");
        }
        steps.Add("");

        steps.Add("Step 2: Show the matrix");
        steps.Add(FormatMatrix(matrix.Matrix));
        steps.Add("");

        steps.Add("Step 3: Apply determinant formula for 2×2 matrix");
        steps.Add("  det(A) = ad - bc");
        steps.Add($"  where a={matrix.Matrix[0,0]:F2}, b={matrix.Matrix[0,1]:F2}, c={matrix.Matrix[1,0]:F2}, d={matrix.Matrix[1,1]:F2}");
        steps.Add("");

        double ad = matrix.Matrix[0, 0] * matrix.Matrix[1, 1];
        double bc = matrix.Matrix[0, 1] * matrix.Matrix[1, 0];

        steps.Add("Step 4: Calculate ad and bc");
        steps.Add($"  ad = {matrix.Matrix[0,0]:F2} × {matrix.Matrix[1,1]:F2} = {ad:F2}");
        steps.Add($"  bc = {matrix.Matrix[0,1]:F2} × {matrix.Matrix[1,0]:F2} = {bc:F2}");
        steps.Add("");

        double value = matrix.CalculateDeterminant();

        steps.Add("Step 5: Calculate ad - bc");
        steps.Add($"  det(A) = {ad:F2} - {bc:F2} = {value:F2}");
        steps.Add("");

        steps.Add("Final Answer:");
        steps.Add($"  Determinant = {value:F2}");

        return new ScalarCalculationResult(value, steps);
    }

    private static string FormatMatrix(double[,] matrix)
    {
        var sb = new StringBuilder();
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            sb.Append("  [ ");
            for (int j = 0; j < cols; j++)
            {
                sb.Append($"{matrix[i, j],6:F2}");
                if (j < cols - 1) sb.Append("  ");
            }
            sb.AppendLine(" ]");
        }

        return sb.ToString();
    }

    private static string FormatMatrixOperation(double[,] matrix1, double[,] matrix2, double[,] result, string operation)
    {
        var sb = new StringBuilder();
        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            sb.Append("  [ ");
            for (int j = 0; j < cols; j++)
            {
                sb.Append($"{matrix1[i, j],6:F2}");
                if (j < cols - 1) sb.Append("  ");
            }
            sb.Append(" ]");

            if (i == rows / 2)
                sb.Append($"  {operation}  ");
            else
                sb.Append("     ");

            sb.Append("[ ");
            for (int j = 0; j < cols; j++)
            {
                sb.Append($"{matrix2[i, j],6:F2}");
                if (j < cols - 1) sb.Append("  ");
            }
            sb.Append(" ]");

            if (i == rows / 2)
                sb.Append("  =  ");
            else
                sb.Append("     ");

            sb.Append("[ ");
            for (int j = 0; j < cols; j++)
            {
                sb.Append($"{result[i, j],6:F2}");
                if (j < cols - 1) sb.Append("  ");
            }
            sb.AppendLine(" ]");
        }

        return sb.ToString();
    }
}