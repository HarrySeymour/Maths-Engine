using MathsEngine.Core.Explanations.Pure.Matrices;
using MathsEngine.Core.Modules.Pure.Matrices;
using Xunit;

namespace MathsEngine.Tests.ExplanationsTests.PureTests;

public class MatrixTutorTests
{
    /// <summary>
    /// Matrix Addition Tests
    /// </summary>
    [Fact]
    public void AddMatrixWithSteps_ReturnsCorrectValue()
    {
        var matrix1 = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });
        var matrix2 = new MatrixBase(new double[,] { { 5, 6 }, { 7, 8 } });

        var result = MatrixTutor.AddMatrixWithSteps(matrix1, matrix2);

        Assert.True(result.IsMatrix);
        Assert.Equal(6, result.MatrixValue[0, 0], 2);
        Assert.Equal(8, result.MatrixValue[0, 1], 2);
        Assert.Equal(10, result.MatrixValue[1, 0], 2);
        Assert.Equal(12, result.MatrixValue[1, 1], 2);
    }

    [Fact]
    public void AddMatrixWithSteps_GeneratesSteps()
    {
        var matrix1 = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });
        var matrix2 = new MatrixBase(new double[,] { { 5, 6 }, { 7, 8 } });

        var result = MatrixTutor.AddMatrixWithSteps(matrix1, matrix2);

        Assert.NotEmpty(result.Steps);
        string stepsText = result.GetStepsAsString();
        Assert.Contains("addition", stepsText);
        Assert.Contains("2×2", stepsText);
    }

    /// <summary>
    /// Matrix Substraction Tests
    /// </summary>
    [Fact]
    public void SubtractMatrixWithSteps_ReturnsCorrectValue()
    {
        var matrix1 = new MatrixBase(new double[,] { { 5, 6 }, { 7, 8 } });
        var matrix2 = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });

        var result = MatrixTutor.SubtractMatrixWithSteps(matrix1, matrix2);

        Assert.True(result.IsMatrix);
        Assert.Equal(4, result.MatrixValue[0, 0], 2);
        Assert.Equal(4, result.MatrixValue[0, 1], 2);
        Assert.Equal(4, result.MatrixValue[1, 0], 2);
        Assert.Equal(4, result.MatrixValue[1, 1], 2);
    }

    [Fact]
    public void SubtractMatrixWithSteps_GeneratesSteps()
    {
        var matrix1 = new MatrixBase(new double[,] { { 5, 6 }, { 7, 8 } });
        var matrix2 = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });

        var result = MatrixTutor.SubtractMatrixWithSteps(matrix1, matrix2);

        Assert.NotEmpty(result.Steps);
        string stepsText = result.GetStepsAsString();
        Assert.Contains("subtraction", stepsText);
    }

    /// <summary>
    /// Matrix Scalar Multiplication and Division Tests
    /// </summary>
    [Fact]
    public void ScalarMultiplicationWithSteps_ReturnsCorrectValue()
    {
        var matrix = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });
        double scalar = 2;

        var result = MatrixTutor.ScalarMultiplicationWithSteps(matrix, scalar);

        Assert.True(result.IsMatrix);
        Assert.Equal(2, result.MatrixValue[0, 0], 2);
        Assert.Equal(4, result.MatrixValue[0, 1], 2);
        Assert.Equal(6, result.MatrixValue[1, 0], 2);
        Assert.Equal(8, result.MatrixValue[1, 1], 2);
    }

    [Fact]
    public void ScalarMultiplicationWithSteps_GeneratesSteps()
    {
        var matrix = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });

        var result = MatrixTutor.ScalarMultiplicationWithSteps(matrix, 2);

        Assert.NotEmpty(result.Steps);
        string stepsText = result.GetStepsAsString();
        Assert.Contains("scalar", stepsText);
        Assert.Contains("2.00", stepsText);
    }

    [Fact]
    public void ScalarDivisionWithSteps_ReturnsCorrectValue()
    {
        var matrix = new MatrixBase(new double[,] { { 2, 4 }, { 6, 8 } });
        double scalar = 2;

        var result = MatrixTutor.ScalarDivisionWithSteps(matrix, scalar);

        Assert.True(result.IsMatrix);
        Assert.Equal(1, result.MatrixValue[0, 0], 2);
        Assert.Equal(2, result.MatrixValue[0, 1], 2);
        Assert.Equal(3, result.MatrixValue[1, 0], 2);
        Assert.Equal(4, result.MatrixValue[1, 1], 2);
    }

    [Fact]
    public void MatrixMultiplicationWithSteps_ReturnsCorrectValue()
    {
        var matrix1 = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });
        var matrix2 = new MatrixBase(new double[,] { { 2, 0 }, { 1, 2 } });

        var result = MatrixTutor.MatrixMultiplicationWithSteps(matrix1, matrix2);

        Assert.True(result.IsMatrix);
        Assert.Equal(4, result.MatrixValue[0, 0], 2);
        Assert.Equal(4, result.MatrixValue[0, 1], 2);
        Assert.Equal(10, result.MatrixValue[1, 0], 2);
        Assert.Equal(8, result.MatrixValue[1, 1], 2);
    }

    [Fact]
    public void MatrixMultiplicationWithSteps_GeneratesSteps()
    {
        var matrix1 = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });
        var matrix2 = new MatrixBase(new double[,] { { 2, 0 }, { 1, 2 } });

        var result = MatrixTutor.MatrixMultiplicationWithSteps(matrix1, matrix2);

        Assert.NotEmpty(result.Steps);
        string stepsText = result.GetStepsAsString();
        Assert.Contains("multiplication", stepsText);
        Assert.Contains("C[", stepsText);
    }

    /// <summary>
    /// Matrix Determinant Tests
    /// </summary>
    [Fact]
    public void CalculateDeterminantWithSteps_ReturnsCorrectValue()
    {
        var matrix = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });

        var result = MatrixTutor.CalculateDeterminantWithSteps(matrix);

        Assert.Equal(-2, result.Value, 2);
    }

    [Fact]
    public void CalculateDeterminantWithSteps_GeneratesSteps()
    {
        var matrix = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });

        var result = MatrixTutor.CalculateDeterminantWithSteps(matrix);

        Assert.NotEmpty(result.Steps);
        string stepsText = result.GetStepsAsString();
        Assert.Contains("determinant", stepsText);
        Assert.Contains("ad - bc", stepsText);
    }
}
