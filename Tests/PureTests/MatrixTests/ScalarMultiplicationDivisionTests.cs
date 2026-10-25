using Xunit;
using Core.Modules.Pure.Matrices;
using Core.Utils.Exceptions;

namespace Tests.PureTests.MatrixTests;

public class ScalarMultiplicationDivisionTests
{
    ///// MULTIPLICATION TESTS

    /*
     * VALUE TESTS
     */

    [Fact]
    public void Multiplication_CheckValidOutput()
    {
        MatrixBase matrix = new MatrixBase(new double[,] { { 1, 2, 3 }, { 2, 3, 4 } });
        int number = 3;
        double[,] expectedResult = new double[,] { { 3, 6, 9 }, { 6, 9, 12 } };

        MatrixBase result = MatrixCalculator.ScalarMultiplication(matrix, number);

        Assert.True(result.Equals(expectedResult));
    }

    /*
     * EXCEPTION TESTS
     */

    [Fact]
    public void Multiplication_NullInputException_Throw()
    {
        MatrixBase matrix = new MatrixBase(new double[,] { });
        int number = 3;

        Assert.Throws<NullInputException>(() =>
            MatrixCalculator.ScalarMultiplication(matrix, number));
    }

    ///// DIVISION TESTS

    /*
     * VALUE TESTS
     */

    [Fact]
    public void Division_CheckValidOutput()
    {
        MatrixBase matrix = new MatrixBase(new double[,] { { 2, 4, 6 }, { 4, 6, 8 } });
        int number = 2;

        double[,] expectedResult = new double[,] { { 1, 2, 3 }, { 2, 3, 4 } };
        MatrixBase result = MatrixCalculator.ScalarDivision(matrix, number);

        Assert.True(result.Equals(expectedResult));
    }

    /*
     * EXCEPTION TESTS
     */

    [Fact]
    public void Division_NullInputException_Throw()
    {
        MatrixBase matrix = new MatrixBase(new double[,] { });
        int number = 3;

        Assert.Throws<NullInputException>(() =>
            MatrixCalculator.ScalarDivision(matrix, number));
    }
}