using Core.Modules.Pure.Algebra.Core;
using Xunit;

namespace Tests.PureTests.AlgebraTests.TermTests;

public class TermArithmeticTests
{
    // --- Addition (operator +) ---
    [Theory]
    [InlineData(5, 2, 7, 2, 12, 2)]
    [InlineData(7, -1, 3, -1, 10, -1)]
    [InlineData(0, 3, 5, 3, 5, 3)]
    [InlineData(5, 3, 0, 3, 5, 3)]
    [InlineData(-4, 6, 10, 6, 6, 6)]
    [InlineData(10, 6, -4, 6, 6, 6)]
    [InlineData(-2.5, 4, 10.5, 4, 8, 4)]
    [InlineData(2.5, 4, -10.5, 4, -8, 4)]
    [InlineData(1.25, -2, 2.75, -2, 4, -2)]
    [InlineData(-1.25, -2, -2.75, -2, -4, -2)]
    [InlineData(1000, 1, -1, 1, 999, 1)]
    [InlineData(0.1, 8, 0.2, 8, 0.3, 8)]
    [InlineData(-0.1, 8, 0.2, 8, 0.1, 8)]
    public void AddTerms_ShouldOutputCorrectResult(
        double term1Coeff, int term1Expo, 
        double term2Coeff, int term2Expo, 
        double expectedCoeff, int expectedExpo)
    {
        Term term1 = new Term(term1Coeff, term1Expo);
        Term term2 = new Term(term2Coeff, term2Expo);
        Term expectedTerm = new Term(expectedCoeff, expectedExpo);

        var resultTerm = term1 + term2;

        Assert.True(expectedTerm.IsEqualTerm(resultTerm));
    }

    [Theory]
    [InlineData(5, 2, 7, 2)]
    [InlineData(-3, 1, 4, 1)]
    [InlineData(0, 0, 10, 0)]
    [InlineData(2.5, 4, -1.5, 4)]
    [InlineData(1.25, -2, 2.75, -2)]
    [InlineData(100, 3, 200, 3)]
    [InlineData(-0.5, 5, 0.5, 5)]
    [InlineData(0.1, 8, 0.2, 8)]
    [InlineData(7, -1, -2, -1)]
    [InlineData(3, 2, 0, 2)]
    public void AddTerms_Commutative_ForLikeTerms(
        double aCoeff, int aExp,
        double bCoeff, int bExp)
    {
        var a = new Term(aCoeff, aExp);
        var b = new Term(bCoeff, bExp);

        var r1 = a + b;
        var r2 = b + a;

        Assert.True(r1.IsEqualTerm(r2));
    }

    [Theory]
    [InlineData(1, 2, 3, 2)]
    [InlineData(5, 0, 3, 0)]
    [InlineData(2.5, 3, -4, 3)]
    [InlineData(-1, 1, 4, 1)]
    [InlineData(0, 4, 1, 4)]
    [InlineData(10, -2, 3, -2)]
    [InlineData(0.1, 7, 0.3, 7)]
    [InlineData(1000, 1, -1, 1)]
    [InlineData(3, 5, 2, 5)]
    [InlineData(4, 6, 0, 6)]
    public void AddTerms_Associative_ForLikeTerms(
        double aCoeff, int exp,
        double bCoeff, double cCoeff)
    {
        var a = new Term(aCoeff, exp);
        var b = new Term(bCoeff, exp);
        var c = new Term(cCoeff, exp);

        var left = (a + b) + c;
        var right = a + (b + c);

        Assert.True(left.IsEqualTerm(right));
    }

    [Theory]
    [InlineData(5, 2, 4, 3)]
    [InlineData(1, 1, 1, 2)]
    [InlineData(0, 0, 1, 1)]
    [InlineData(2.5, 3, -2.5, 2)]
    [InlineData(7, -1, 3, 0)]
    [InlineData(-1, 4, 1, 5)]
    [InlineData(3, 2, 3, -2)]
    [InlineData(5, 7, 1, 6)]
    [InlineData(2, 3, 2, 4)]
    [InlineData(9, 5, 9, 6)]
    public void AddTerms_ShouldThrowError_OnUnlikeTerms(
        double term1Coeff, int term1Expo,
        double term2Coeff, int term2Expo)
    {
        Term term1 = new Term(term1Coeff, term1Expo);
        Term term2 = new Term(term2Coeff, term2Expo);

        Assert.Throws<InvalidOperationException>(() => term1 + term2);
    }

    [Theory]
    [InlineData(5, 2, 4, 3)]
    [InlineData(1, 1, 1, 2)]
    [InlineData(2, 0, 2, 1)]
    [InlineData(3, 4, -3, 5)]
    [InlineData(-2, -1, 1, 0)]
    [InlineData(2.5, 3, 2.5, 4)]
    [InlineData(7, -2, 7, -1)]
    [InlineData(0, 0, 1, 1)]
    [InlineData(9, 5, 1, 6)]
    [InlineData(4, 2, 4, -2)]
    public void SubtractTerms_ShouldThrowError_OnUnlikeTerms(
        double term1Coeff, int term1Expo,
        double term2Coeff, int term2Expo)
    {
        Term term1 = new Term(term1Coeff, term1Expo);
        Term term2 = new Term(term2Coeff, term2Expo);

        Assert.Throws<InvalidOperationException>(() => term1 - term2);
    }

    // --- Subtraction (operator -) ---
    [Theory]
    [InlineData(12, 2, 7, 2, 5, 2)]
    [InlineData(10, -1, 3, -1, 7, -1)]
    [InlineData(5, 3, 0, 3, 5, 3)]
    [InlineData(0, 3, 5, 3, -5, 3)]
    [InlineData(-4, 6, 10, 6, -14, 6)]
    [InlineData(10, 6, -4, 6, 14, 6)]
    [InlineData(-2.5, 4, 10.5, 4, -13, 4)]
    [InlineData(2.5, 4, -10.5, 4, 13, 4)]
    [InlineData(1.25, -2, 2.75, -2, -1.5, -2)]
    [InlineData(-1.25, -2, -2.75, -2, 1.5, -2)]
    [InlineData(1000, 1, -1, 1, 1001, 1)]
    [InlineData(0.3, 8, 0.2, 8, 0.1, 8)]
    [InlineData(-0.1, 8, 0.2, 8, -0.3, 8)]
    public void SubtractTerms_ShouldOutputCorrectResult(
        double term1Coeff, int term1Expo,
        double term2Coeff, int term2Expo,
        double expectedCoeff, int expectedExpo)
    {
        Term term1 = new Term(term1Coeff, term1Expo);
        Term term2 = new Term(term2Coeff, term2Expo);
        Term expectedTerm = new Term(expectedCoeff, expectedExpo);

        var resultTerm = term1 - term2;

        Assert.True(expectedTerm.IsEqualTerm(resultTerm));
    }

    // --- Multiplication (operator * Term*Term) ---
    [Theory]
    [InlineData(5, 2, 7, 2, 35, 4)]
    [InlineData(7, -1, 3, -1, 21, -2)]
    [InlineData(2, 3, 4, 5, 8, 8)]
    [InlineData(-2, 3, 4, 5, -8, 8)]
    [InlineData(2, 3, -4, 5, -8, 8)]
    [InlineData(-2, 3, -4, 5, 8, 8)]
    [InlineData(0, 2, 5, 4, 0, 6)]
    [InlineData(5, 4, 0, 2, 0, 6)]
    [InlineData(0.5, 1, 0.25, 3, 0.125, 4)]
    [InlineData(1.25, -2, 2, 4, 2.5, 2)]
    [InlineData(10, 0, 3, 7, 30, 7)]
    [InlineData(3, -5, 2, 5, 6, 0)]
    [InlineData(1000, 1, -0.001, 2, -1, 3)]
    public void MultiplyTerms_ShouldOutputCorrectResult(
        double term1Coeff, int term1Expo,
        double term2Coeff, int term2Expo,
        double expectedCoeff, int expectedExpo)
    {
        Term term1 = new Term(term1Coeff, term1Expo);
        Term term2 = new Term(term2Coeff, term2Expo);
        Term expectedTerm = new Term(expectedCoeff, expectedExpo);

        var resultTerm = term1 * term2;

        Assert.True(expectedTerm.IsEqualTerm(resultTerm));
    }

    [Theory]
    [InlineData(2, 3, 1)]
    [InlineData(1.5, -2, 3)]
    [InlineData(5, 4, 2)]
    [InlineData(-3, 2, 2)]
    public void MultiplyTerms_ShouldThrow_OnDifferentVariables(
        double coeff1, double coeff2, int power2)
    {
        var t1 = new Term(coeff1, 1); // variable "x"
        var t2 = new Term(coeff2, power2);

        Assert.Throws<InvalidOperationException>(() => { var r = t1 * t2; });
        Assert.Throws<InvalidOperationException>(() => { var r = t2 * t1; });
    }

    // --- Scalar Multiply (operator * Term * int ) ---
    [Theory]
    [InlineData(5, 2, 3, 15, 2)]
    [InlineData(0, 3, 10, 0, 3)]
    [InlineData(-2, 4, 5, -10, 4)]
    [InlineData(1.5, 1, 2, 3.0, 1)]
    [InlineData(-1.5, 1, -2, 3.0, 1)]
    [InlineData(2.5, 0, 4, 10, 0)]
    [InlineData(3, -2, 3, 9, -2)]
    [InlineData(7, 5, 0, 0, 5)]
    [InlineData(0.1, 8, 10, 1.0, 8)]
    [InlineData(-0.2, 6, -5, 1.0, 6)]
    public void ScalarMultiply_ShouldOutputCorrectResult(double termCoefficient, int termExponent, int constant, double expectedCoeff, int expectedExpo)
    {
        Term term = new Term(termCoefficient, termExponent);
        
        var resultTerm = term * constant;
        var expectedTerm = new Term(expectedCoeff, expectedExpo);

        Assert.True(resultTerm.IsEqualTerm(expectedTerm));
    }

    // --- Division (operator /) ---
    [Theory]
    [InlineData(12, 2, 6, 2, 2, 0)]
    [InlineData(7, -1, 3.5, -1, 2, 0)]
    [InlineData(10, 5, 2, 5, 5, 0)]
    [InlineData(9, 4, 3, 4, 3, 0)]
    [InlineData(-8, 3, 2, 3, -4, 0)]
    [InlineData(5, 6, 2, 6, 2.5, 0)]
    [InlineData(100, 10, 2, 10, 50, 0)]
    [InlineData(0.25, 4, 0.5, 4, 0.5, 0)]
    [InlineData(1.5, 2, 0.5, 2, 3.0, 0)]
    [InlineData(1000, 1, 0.5, 1, 2000, 0)]
    public void DivideTerms_ShouldOutputCorrectResult_ForLikeTerms(
        double term1Coeff, int term1Expo,
        double term2Coeff, int term2Expo,
        double expectedCoeff, int expectedExpo)
    {
        var term1 = new Term(term1Coeff, term1Expo);
        var term2 = new Term(term2Coeff, term2Expo);
        var expected = new Term(expectedCoeff, expectedExpo);

        var result = term1 / term2;

        Assert.True(expected.IsEqualTerm(result));
    }

    [Theory]
    // Unlike terms should throw when dividing
    [InlineData(5, 2, 4, 3)]
    [InlineData(3, 1, 3, 2)]
    [InlineData(2, 3, 2, 4)]
    [InlineData(1, 0, 1, 1)]
    [InlineData(9, 5, 1, 6)]
    [InlineData(-2, 3, 4, 1)]
    [InlineData(7, -1, 1, -2)]
    [InlineData(2.2, 2, 3.3, 1)]
    [InlineData(5, 7, 1, 0)]
    [InlineData(3, -3, 2, -1)]
    public void DivideTerms_ShouldThrowOnUnlikeTerms(double c1, int p1, double c2, int p2)
    {
        var term1 = new Term(c1, p1);
        var term2 = new Term(c2, p2);

        Assert.Throws<InvalidOperationException>(() => { var r = term1 / term2; });
    }

    [Fact]
    public void DivideByZeroCoefficient_ShouldProduceInfinityCoefficient()
    {
        // dividing like terms where divisor has coefficient zero produces Infinity for coefficient
        var t1 = new Term(1.0, 2);
        var t2 = new Term(0.0, 2);

        var result = t1 / t2;

        Assert.True(double.IsInfinity(result.Coefficient));
        Assert.Equal(0, result.Power); // power 2 - 2 => 0
    }

    // --- Null operand checks (ArgumentNullException) ---
    [Fact]
    public void Add_ShouldThrowArgumentNullException_WhenLeftIsNull()
    {
        Term left = null;
        var right = new Term(1, 1);

        Assert.Throws<ArgumentNullException>(() => { var r = left + right; });
    }

    [Fact]
    public void Add_ShouldThrowArgumentNullException_WhenRightIsNull()
    {
        var left = new Term(1, 1);
        Term right = null;

        Assert.Throws<ArgumentNullException>(() => { var r = left + right; });
    }

    [Fact]
    public void Subtract_ShouldThrowArgumentNullException_WhenEitherIsNull()
    {
        Term left = null;
        var right = new Term(1, 1);
        Assert.Throws<ArgumentNullException>(() => { var r = left - right; });

        left = new Term(1, 1);
        right = null;
        Assert.Throws<ArgumentNullException>(() => { var r = left - right; });
    }

    [Fact]
    public void Multiply_ShouldThrowArgumentNullException_WhenEitherIsNull()
    {
        Term left = null;
        var right = new Term(1, 1);
        Assert.Throws<ArgumentNullException>(() => { var r = left * right; });

        left = new Term(1, 1);
        right = null;
        Assert.Throws<ArgumentNullException>(() => { var r = left * right; });
    }

    [Fact]
    public void Divide_ShouldThrowArgumentNullException_WhenEitherIsNull()
    {
        Term left = null;
        var right = new Term(1, 1);
        Assert.Throws<ArgumentNullException>(() => { var r = left / right; });

        left = new Term(1, 1);
        right = null;
        Assert.Throws<ArgumentNullException>(() => { var r = left / right; });
    }
}