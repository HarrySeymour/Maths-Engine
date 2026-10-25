using Core.Explanations.Pure.PythagorasTheorem;
using Xunit;

namespace Tests.ExplanationsTests.PureTests;

public class PythagorasTheoremTutorTests
{
    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(5, 12, 13)]
    [InlineData(8, 15, 17)]
    [InlineData(6, 8, 10)]
    public void CalculateHypotenuseWithSteps_ReturnsCorrectValue(
        double sideA,
        double sideB,
        double expected)
    {
        var result = PythagorasTheoremTutor.CalculateHypotenuseWithSteps(sideA, sideB);

        Assert.Equal(expected, result.Value, 2);
    }

    [Fact]
    public void CalculateHypotenuseWithSteps_GeneratesSteps()
    {
        var result = PythagorasTheoremTutor.CalculateHypotenuseWithSteps(3, 4);

        Assert.NotEmpty(result.Steps);
        Assert.Contains(result.Steps, s => s.Contains("Step 1"));
        Assert.Contains(result.Steps, s => s.Contains("Step 2"));
        Assert.Contains(result.Steps, s => s.Contains("Step 3"));
        Assert.Contains(result.Steps, s => s.Contains("Step 4"));
        Assert.Contains(result.Steps, s => s.Contains("Step 5"));
        Assert.Contains(result.Steps, s => s.Contains("Final Answer"));
    }

    [Fact]
    public void CalculateHypotenuseWithSteps_IncludesKnownValues()
    {
        var result = PythagorasTheoremTutor.CalculateHypotenuseWithSteps(3, 4);

        string stepsText = result.GetStepsAsString();
        Assert.Contains("Side A = 3", stepsText);
        Assert.Contains("Side B = 4", stepsText);
    }

    [Fact]
    public void CalculateHypotenuseWithSteps_IncludesFormula()
    {
        var result = PythagorasTheoremTutor.CalculateHypotenuseWithSteps(3, 4);

        string stepsText = result.GetStepsAsString();
        Assert.Contains("c² = a² + b²", stepsText);
        Assert.Contains("Pythagorean Theorem", stepsText);
    }

    [Fact]
    public void CalculateHypotenuseWithSteps_ShowsSquareCalculations()
    {
        var result = PythagorasTheoremTutor.CalculateHypotenuseWithSteps(3, 4);

        string stepsText = result.GetStepsAsString();
        Assert.Contains("3² = 9", stepsText);
        Assert.Contains("4² = 16", stepsText);
    }

    [Fact]
    public void CalculateHypotenuseWithSteps_ShowsSquareRoot()
    {
        var result = PythagorasTheoremTutor.CalculateHypotenuseWithSteps(3, 4);

        string stepsText = result.GetStepsAsString();
        Assert.Contains("√", stepsText);
    }

    [Theory]
    [InlineData(5, 3, 4)]
    [InlineData(13, 5, 12)]
    [InlineData(17, 8, 15)]
    public void CalculateOtherSideWithSteps_ReturnsCorrectValue(
        double hypotenuse,
        double knownSide,
        double expected)
    {
        var result = PythagorasTheoremTutor.CalculateOtherSideWithSteps(hypotenuse, knownSide);

        Assert.Equal(expected, result.Value, 2);
    }

    [Fact]
    public void CalculateOtherSideWithSteps_GeneratesSteps()
    {
        var result = PythagorasTheoremTutor.CalculateOtherSideWithSteps(5, 3);

        Assert.NotEmpty(result.Steps);
        Assert.Contains(result.Steps, s => s.Contains("Step 1"));
        Assert.Contains(result.Steps, s => s.Contains("Step 2"));
        Assert.Contains(result.Steps, s => s.Contains("Step 3"));
        Assert.Contains(result.Steps, s => s.Contains("Step 4"));
        Assert.Contains(result.Steps, s => s.Contains("Step 5"));
        Assert.Contains(result.Steps, s => s.Contains("Final Answer"));
    }

    [Fact]
    public void CalculateOtherSideWithSteps_IncludesKnownValues()
    {
        var result = PythagorasTheoremTutor.CalculateOtherSideWithSteps(5, 3);

        string stepsText = result.GetStepsAsString();
        Assert.Contains("Hypotenuse (c) = 5", stepsText);
        Assert.Contains("Known Side (a) = 3", stepsText);
    }

    [Fact]
    public void CalculateOtherSideWithSteps_ShowsRearrangedFormula()
    {
        var result = PythagorasTheoremTutor.CalculateOtherSideWithSteps(5, 3);

        string stepsText = result.GetStepsAsString();
        Assert.Contains("b² = c² - a²", stepsText);
        Assert.Contains("Rearrange", stepsText);
    }

    [Fact]
    public void CalculateOtherSideWithSteps_ShowsSubtraction()
    {
        var result = PythagorasTheoremTutor.CalculateOtherSideWithSteps(5, 3);

        string stepsText = result.GetStepsAsString();
        Assert.Contains("25.00 - 9.00 = 16.00", stepsText);
    }

    [Fact]
    public void GetStepsAsString_ReturnsFormattedString()
    {
        var result = PythagorasTheoremTutor.CalculateHypotenuseWithSteps(3, 4);
        string stepsText = result.GetStepsAsString();

        Assert.NotEmpty(stepsText);
        Assert.Contains("Step 1", stepsText);
        Assert.Contains(Environment.NewLine, stepsText);
    }
}
