using Core.Modules.Pure.Trigonometry;
using Xunit;
using Core.Utils.Exceptions;

namespace Tests.PureTests.TrigonometryTests;

public class CalculateMissingSideTests
{
    /*
     * VALUE TESTS
     */

    [Theory]
    [InlineData(10, 30, SideType.Adjacent, SideType.Opposite, 5.77)]
    [InlineData(10, 30, SideType.Adjacent, SideType.Hypotenuse, 11.55)]
    [InlineData(10, 45, SideType.Opposite, SideType.Adjacent, 10.0)]
    [InlineData(10, 45, SideType.Opposite, SideType.Hypotenuse, 14.14)]
    [InlineData(20, 60, SideType.Hypotenuse, SideType.Opposite, 17.32)]
    [InlineData(20, 60, SideType.Hypotenuse, SideType.Adjacent, 10.0)]
    public void CalculateMissingSide_WithValidInputs_ReturnsCorrectResult(
        double knownSideLength,
        double angle,
        SideType knownSideType,
        SideType sideToFind,
        double expected)
    {
        var result = TrigonometryCalculator.CalculateMissingSide(knownSideLength, angle, knownSideType, sideToFind);
        Assert.Equal(expected, result, 2);
    }

    /*
     *  EXCEPTION TESTS
     */

    [Theory]
    [InlineData(-3.0, 50.0, SideType.Adjacent, SideType.Hypotenuse)]
    [InlineData(0, 50.0, SideType.Hypotenuse, SideType.Adjacent)]
    public void NegativeSideException_Throw(
        double knownSideLength,
        double angle,
        SideType knownSideType,
        SideType sideToFind)
    {
        Assert.Throws<NegativeSideLengthException>(() =>
            TrigonometryCalculator.CalculateMissingSide(knownSideLength, angle, knownSideType, sideToFind));
    }

    [Theory]
    [InlineData(7, 0.0, SideType.Adjacent, SideType.Hypotenuse)]
    [InlineData(7, -1.5, SideType.Adjacent, SideType.Hypotenuse)]
    [InlineData(7, 90.0, SideType.Adjacent, SideType.Hypotenuse)]
    [InlineData(7, 100.0, SideType.Adjacent, SideType.Hypotenuse)]
    public void AcuteAngleException_Throw(
        double knownSideLength,
        double angle,
        SideType knownSideType,
        SideType sideToFind)
    {
        Assert.Throws<AcuteAngleException>(() =>
            TrigonometryCalculator.CalculateMissingSide(knownSideLength, angle, knownSideType, sideToFind));
    }

    [Theory]
    [InlineData(7, 45, SideType.Hypotenuse, SideType.Hypotenuse)]
    [InlineData(7, 45, SideType.Adjacent, SideType.Adjacent)]
    [InlineData(7, 45, SideType.Opposite, SideType.Opposite)]
    public void DuplicateSideException_Throw(
        double knownSideLength,
        double angle,
        SideType knownSideType,
        SideType sideToFind)
    {
        Assert.Throws<DuplicateSideException>(() =>
            TrigonometryCalculator.CalculateMissingSide(knownSideLength, angle, knownSideType, sideToFind));
    }
}