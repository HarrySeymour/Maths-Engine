using Core.Explanations.Mechanics;
using Xunit;
using Core.Utils.Exceptions;

namespace Tests.ExplanationsTests.MechanicsTests;

public class NewtonsLawsTutorTests
{
    [Theory]
    [InlineData(null, 10.0, 5.0, 50.0)]      // Calculate Force
    [InlineData(100.0, null, 5.0, 20.0)]     // Calculate Mass
    [InlineData(50.0, 10.0, null, 5.0)]      // Calculate Acceleration
    public void CalculateFmaWithSteps_ReturnsCorrectValue(
        double? f, double? m, double? a, double expected)
    {
        var result = NewtonsLawsTutor.CalculateFmaWithSteps(f, m, a);

        Assert.Equal(expected, result.Value, 2);
    }

    [Fact]
    public void CalculateFmaWithSteps_CalculateForce_GeneratesSteps()
    {
        var result = NewtonsLawsTutor.CalculateFmaWithSteps(null, 10.0, 5.0);

        Assert.NotEmpty(result.Steps);
        Assert.Contains(result.Steps, s => s.Contains("Step 1"));
        Assert.Contains(result.Steps, s => s.Contains("Newton's Second Law"));
        Assert.Contains(result.Steps, s => s.Contains("F = ma"));
        Assert.Contains(result.Steps, s => s.Contains("Final Answer"));
    }

    [Fact]
    public void CalculateFmaWithSteps_CalculateMass_GeneratesSteps()
    {
        var result = NewtonsLawsTutor.CalculateFmaWithSteps(100.0, null, 5.0);

        Assert.NotEmpty(result.Steps);
        string stepsText = result.GetStepsAsString();
        Assert.Contains("Mass (m)", stepsText);
        Assert.Contains("m = F / a", stepsText);
    }

    [Fact]
    public void CalculateFmaWithSteps_CalculateAcceleration_GeneratesSteps()
    {
        var result = NewtonsLawsTutor.CalculateFmaWithSteps(50.0, 10.0, null);

        Assert.NotEmpty(result.Steps);
        string stepsText = result.GetStepsAsString();
        Assert.Contains("Acceleration (a)", stepsText);
        Assert.Contains("a = F / m", stepsText);
    }

    [Fact]
    public void CalculateFmaWithSteps_WithAllValues_ThrowsException()
    {
        Assert.Throws<NullInputException>(() =>
            NewtonsLawsTutor.CalculateFmaWithSteps(50.0, 10.0, 5.0));
    }

    [Fact]
    public void CalculateFmaWithSteps_WithMultipleMissing_ThrowsException()
    {
        Assert.Throws<NullInputException>(() =>
            NewtonsLawsTutor.CalculateFmaWithSteps(null, null, 5.0));
    }
}
