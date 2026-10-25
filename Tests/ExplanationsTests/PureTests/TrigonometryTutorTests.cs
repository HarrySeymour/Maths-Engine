using Core.Explanations.Pure.Trigonometry;
using Xunit;
using Core.Modules.Pure.Trigonometry;

namespace Tests.ExplanationsTests.PureTests;

public class TrigonometryTutorTests
{
    [Theory]
    [InlineData(10, 30, SideType.Adjacent, SideType.Opposite, 5.77)]
    [InlineData(10, 30, SideType.Adjacent, SideType.Hypotenuse, 11.55)]
    [InlineData(10, 45, SideType.Opposite, SideType.Adjacent, 10.0)]
    [InlineData(10, 45, SideType.Opposite, SideType.Hypotenuse, 14.14)]
    [InlineData(20, 60, SideType.Hypotenuse, SideType.Opposite, 17.32)]
    [InlineData(20, 60, SideType.Hypotenuse, SideType.Adjacent, 10.0)]
    public void CalculateMissingSideWithSteps_ReturnsCorrectValue(
        double knownSideLength,
        double angle,
        SideType knownSideType,
        SideType sideToFind,
        double expected)
    {
        var result = TrigonometryTutor.CalculateMissingSideWithSteps(
            knownSideLength, angle, knownSideType, sideToFind);

        Assert.Equal(expected, result.Value, 2);
    }

    [Fact]
    public void CalculateMissingSideWithSteps_GeneratesSteps()
    {
        var result = TrigonometryTutor.CalculateMissingSideWithSteps(
            10, 30, SideType.Adjacent, SideType.Opposite);

        Assert.NotEmpty(result.Steps);
        Assert.Contains(result.Steps, s => s.Contains("Step 1"));
        Assert.Contains(result.Steps, s => s.Contains("Step 2"));
        Assert.Contains(result.Steps, s => s.Contains("Step 3"));
        Assert.Contains(result.Steps, s => s.Contains("Step 4"));
        Assert.Contains(result.Steps, s => s.Contains("Step 5"));
        Assert.Contains(result.Steps, s => s.Contains("Final Answer"));
    }

    [Fact]
    public void CalculateMissingSideWithSteps_IncludesKnownValues()
    {
        var result = TrigonometryTutor.CalculateMissingSideWithSteps(
            10, 30, SideType.Adjacent, SideType.Opposite);

        string stepsText = result.GetStepsAsString();
        Assert.Contains("Adjacent = 10", stepsText);
        Assert.Contains("30°", stepsText);
    }

    [Fact]
    public void CalculateMissingSideWithSteps_IncludesTrigRule()
    {
        var result = TrigonometryTutor.CalculateMissingSideWithSteps(
            10, 30, SideType.Adjacent, SideType.Opposite);

        string stepsText = result.GetStepsAsString();
        Assert.Contains("TOA", stepsText);
        Assert.Contains("tan", stepsText);
    }

    [Fact]
    public void CalculateMissingSideWithSteps_IncludesRadianConversion()
    {
        var result = TrigonometryTutor.CalculateMissingSideWithSteps(
            10, 45, SideType.Opposite, SideType.Adjacent);

        string stepsText = result.GetStepsAsString();
        Assert.Contains("radians", stepsText);
        Assert.Contains("π", stepsText);
    }

    [Theory]
    [InlineData(3, SideType.Opposite, 4, SideType.Adjacent, 36.87)]
    [InlineData(3, SideType.Opposite, 5, SideType.Hypotenuse, 36.87)]
    [InlineData(4, SideType.Adjacent, 5, SideType.Hypotenuse, 36.87)]
    public void CalculateMissingAngleWithSteps_ReturnsCorrectValue(
        double side1Length,
        SideType side1Type,
        double side2Length,
        SideType side2Type,
        double expected)
    {
        var result = TrigonometryTutor.CalculateMissingAngleWithSteps(
            side1Length, side1Type, side2Length, side2Type);

        Assert.Equal(expected, result.Value, 2);
    }

    [Fact]
    public void CalculateMissingAngleWithSteps_GeneratesSteps()
    {
        var result = TrigonometryTutor.CalculateMissingAngleWithSteps(
            3, SideType.Opposite, 4, SideType.Adjacent);

        Assert.NotEmpty(result.Steps);
        Assert.Contains(result.Steps, s => s.Contains("Step 1"));
        Assert.Contains(result.Steps, s => s.Contains("Step 2"));
        Assert.Contains(result.Steps, s => s.Contains("Step 3"));
        Assert.Contains(result.Steps, s => s.Contains("Step 4"));
        Assert.Contains(result.Steps, s => s.Contains("Final Answer"));
    }

    [Fact]
    public void CalculateMissingAngleWithSteps_IncludesKnownSides()
    {
        var result = TrigonometryTutor.CalculateMissingAngleWithSteps(
            3, SideType.Opposite, 4, SideType.Adjacent);

        string stepsText = result.GetStepsAsString();
        Assert.Contains("Opposite = 3", stepsText);
        Assert.Contains("Adjacent = 4", stepsText);
    }

    [Fact]
    public void CalculateMissingAngleWithSteps_IncludesInverseFunction()
    {
        var result = TrigonometryTutor.CalculateMissingAngleWithSteps(
            3, SideType.Opposite, 4, SideType.Adjacent);

        string stepsText = result.GetStepsAsString();
        Assert.Contains("tan⁻¹", stepsText);
    }

    [Fact]
    public void GetStepsAsString_ReturnsFormattedString()
    {
        var result = TrigonometryTutor.CalculateMissingSideWithSteps(
            10, 30, SideType.Adjacent, SideType.Opposite);
        string stepsText = result.GetStepsAsString();

        Assert.NotEmpty(stepsText);
        Assert.Contains("Step 1", stepsText);
        Assert.Contains(Environment.NewLine, stepsText);
    }
}
