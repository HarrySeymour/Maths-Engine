using Core.Modules.Pure.PythagorasTheorem;
using Core.Utils.Exceptions;
using Xunit;

namespace Tests.PureTests.PythagorasTests;

public class CheckValidCalculationTests
{
    [Theory]
    [InlineData(6, 3, 4)]
    [InlineData(10, 5, 5)]
    [InlineData(20, 6, 8)]
    public void CheckValidCalculation_ReturnsFalse_For_InvalidTriangles(
        double hypotenuse,
        double a,
        double b)
    {
        bool result = PythagorasCalculator.CheckValidCalculation(hypotenuse, a, b);

        Assert.False(result);
    }

    [Theory]
    [InlineData(5, 3, 4)]
    [InlineData(13, 5, 12)]
    [InlineData(17, 8, 15)]
    public void CheckValidCalculation_ReturnsTrue_For_ValidTriangles(
        double hypotenuse,
        double a,
        double b)
    {
        bool result = PythagorasCalculator.CheckValidCalculation(hypotenuse, a, b);

        Assert.True(result);
    }

    [Theory]
    [InlineData(1, 3, 10)]
    [InlineData(5, 10, 8)]
    [InlineData(1, 3, 4)]
    public void CheckValidCalculation_HypotenuseNotLongest_Throw(
        double hypotenuse,
        double a,
        double b)
    {
        Assert.Throws<HypotenuseNotLongestSideException>(() =>
            PythagorasCalculator.CheckValidCalculation(hypotenuse, a, b));
    }

    [Theory]
    [InlineData(-5, 3, -7)]
    [InlineData(5, -3, 10)]
    [InlineData(0, 3, -1)]
    public void CheckValidCalculation_NonPositiveSide_Throw(
        double hypotenuse,
        double a,
        double b)
    {
        Assert.Throws<NegativeSideLengthException>(() =>
            PythagorasCalculator.CheckValidCalculation(hypotenuse, a, b));
    }
}