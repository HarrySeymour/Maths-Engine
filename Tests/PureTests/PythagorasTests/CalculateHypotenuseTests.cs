using Core.Modules.Pure.PythagorasTheorem;
using Core.Utils.Exceptions;
using Xunit;

namespace Tests.PureTests.PythagorasTests;

public class CalculateHypotenuseTests
{
    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(5, 12, 13)]
    [InlineData(8, 15, 17)]
    public void Hypotenuse_Is_Correct_For_Common_Triangles(
        double a,
        double b,
        double expected)
    {
        double result = PythagorasCalculator.CalculateHypotenuse(a, b);

        Assert.Equal(expected, result, precision: 6);
    }

    [Theory]
    [InlineData(-3, 4)]
    [InlineData(3, -4)]
    [InlineData(0, 5)]
    public void CalculateHypotenuse_NonPositiveSides_Throw(
        double a,
        double b)
    {
        Assert.Throws<NegativeSideLengthException>(() =>
            PythagorasCalculator.CalculateHypotenuse(a, b));
    }
}