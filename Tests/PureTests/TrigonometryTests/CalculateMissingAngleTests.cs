using Core.Modules.Pure.Trigonometry;
using Xunit;
using Core.Utils.Exceptions;

namespace Tests.PureTests.TrigonometryTests;

public class CalculateMissingAngleTests
{
    /*
     * VALUE TESTS
     */
    [Theory]
    // SOH (Sine)
    [InlineData(5, SideType.Opposite, 10, SideType.Hypotenuse, 30)]
    // CAH (Cosine)
    [InlineData(8.66, SideType.Adjacent, 10, SideType.Hypotenuse, 30)]
    // TOA (Tangent)
    [InlineData(5.77, SideType.Opposite, 10, SideType.Adjacent, 30)]
    public void CalculateMissingAngle_WithValidInputs_ReturnsCorrectAngle(double side1Length, SideType side1Type, double side2Length, SideType side2Type, double expectedAngle)
    {
        var result = TrigonometryCalculator.CalculateMissingAngle(side1Length, side1Type, side2Length, side2Type);
        Assert.Equal(expectedAngle, result, 0);
    }

    /*
     *  EXCEPTION TESTS
     */

    [Theory]
    [InlineData(0.0, SideType.Adjacent, 1.0, SideType.Hypotenuse)]
    [InlineData(-1.0, SideType.Adjacent, 1.0, SideType.Hypotenuse)]
    [InlineData(1.0, SideType.Adjacent, 0.0, SideType.Opposite)]
    [InlineData(0.0, SideType.Adjacent, -1.0, SideType.Opposite)]
    public void NegativeSideLengthException_Throw(
        double side1Length,
        SideType side1Type,
        double side2Length,
        SideType side2Type)
    {
        Assert.Throws<NegativeSideLengthException>(() =>
            TrigonometryCalculator.CalculateMissingAngle(side1Length, side1Type, side2Length, side2Type));
    }

    [Theory]
    [InlineData(2.0, SideType.Hypotenuse, 3.0, SideType.Adjacent)]
    [InlineData(4.0, SideType.Opposite, 2.0, SideType.Hypotenuse)]
    public void HypotenuseNotLongestSideException_Throw(
        double side1Length,
        SideType side1Type,
        double side2Length,
        SideType side2Type)
    {
        Assert.Throws<HypotenuseNotLongestSideException>(() =>
            TrigonometryCalculator.CalculateMissingAngle(side1Length, side1Type, side2Length, side2Type));
    }
}