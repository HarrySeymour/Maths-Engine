using Core.Modules.Pure.PythagorasTheorem;
using Core.Utils.Exceptions;
using Xunit;

namespace Tests.PureTests.PythagorasTests;

public class CalculateOtherSideTests
{
    [Theory]
    [InlineData(-5, 3)]
    [InlineData(5, -3)]
    [InlineData(0, 3)]
    public void CalculateOtherSide_NonPositiveSides_Throw(
        double hypotenuse,
        double knownSide)
    {
        Assert.Throws<NegativeSideLengthException>(() =>
            PythagorasCalculator.CalculateOtherSide(hypotenuse, knownSide));
    }

    [Theory]
    [InlineData(1, 3)]
    [InlineData(5, 10)]
    [InlineData(2, 3)]
    public void CalculateOtherSide_HypotenuseNotLongest_Throw(
        double hypotenuse,
        double knownSide)
    {
        Assert.Throws<HypotenuseNotLongestSideException>(() =>
            PythagorasCalculator.CalculateOtherSide(hypotenuse, knownSide));
    }
}