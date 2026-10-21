using Xunit;
using MathsEngine.Core.Modules.Pure.Matrices;
using MathsEngine.Core.Utils.Exceptions;

namespace MathsEngine.Tests.PureTests.MatrixTests;

public class AddSubtractMatrixTests
{
    ///// ADDITION TESTS

    /*
     * VALUE TESTS
     */

    [Fact]
    public void MatrixAdditionIsValid()
    {
        double[,] array1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        double[,] array2 = { { 9, 8, 7 }, { 6, 5, 4 }, { 3, 2, 1 } };

        MatrixBase matrix1 = new MatrixBase(array1);
        MatrixBase matrix2 = new MatrixBase(array2);

        double[,] expectedResult = { { 10, 10, 10 }, { 10, 10, 10 }, { 10, 10, 10 } };
        MatrixBase result = MatrixCalculator.AddMatrix(matrix1, matrix2);

        Assert.True(result.Equals(expectedResult));
    }

    /*
     * EXCEPTION TESTS
     */

    [Fact]
    public void Addition_NullInputException_Throw()
    {
        double[,] emptyArray = { };

        MatrixBase matrix1 = new MatrixBase(emptyArray);
        MatrixBase matrix2 = new MatrixBase(emptyArray);

        Assert.Throws<NullInputException>(() =>
            MatrixCalculator.AddMatrix(matrix1, matrix2));
    }

    [Fact]
    public void Addition_IncompatibleMatrixAdditionException_Throw()
    {
        double[,] array1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        double[,] array2 = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 } };

        MatrixBase matrix1 = new MatrixBase(array1);
        MatrixBase matrix2 = new MatrixBase(array2);

        Assert.Throws<IncompatibleMatrixAdditionException>(() =>
            MatrixCalculator.AddMatrix(matrix1, matrix2));
    }

    ///// SUBTRACTION TESTS

    /*
     * VALUE TESTS
     */

    [Fact]
    public void MatrixSubtractionIsValid()
    {
        double[,] array1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        double[,] array2 = { { 9, 8, 7 }, { 6, 5, 4 }, { 3, 2, 1 } };

        MatrixBase matrix1 = new MatrixBase(array1);
        MatrixBase matrix2 = new MatrixBase(array2);

        double[,] expectedResult = { { 8, 6, 4 }, { 2, 0, -2 }, { -4, -6, -8 } };
        MatrixBase result = MatrixCalculator.SubtractMatrix(matrix2, matrix1);

        Assert.True(result.Equals(expectedResult));
    }

    /*
     * EXCEPTION TESTS
     */

    [Fact]
    public void Subtraction_NullInputException_Throw()
    {
        double[,] emptyArray = { };

        MatrixBase matrix1 = new MatrixBase(emptyArray);
        MatrixBase matrix2 = new MatrixBase(emptyArray);

        Assert.Throws<NullInputException>(() =>
            MatrixCalculator.SubtractMatrix(matrix1, matrix2));
    }

    [Fact]
    public void Subtraction_IncompatibleMatrixAdditionException_Throw()
    {
        double[,] array1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        double[,] array2 = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 } };

        MatrixBase matrix1 = new MatrixBase(array1);
        MatrixBase matrix2 = new MatrixBase(array2);

        Assert.Throws<IncompatibleMatrixAdditionException>(() =>
            MatrixCalculator.SubtractMatrix(matrix1, matrix2));
    }
}