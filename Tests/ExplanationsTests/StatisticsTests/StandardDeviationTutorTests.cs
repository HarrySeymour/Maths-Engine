using Core.Explanations.Statistics;
using Xunit;

namespace Tests.ExplanationsTests.StatisticsTests;

public class StandardDeviationTutorTests
{
    [Fact]
    public void CalculateStandardDeviationWithSteps_SimpleDataSet_ReturnsCorrectValue()
    {
        var values = new List<double> { 2, 4, 4, 4, 5, 5, 7, 9 };

        var result = StandardDeviationTutor.CalculateStandardDeviationWithSteps(values);

        Assert.Equal(2.0, result.Value, 1); // Standard deviation is 2.0
    }

    [Fact]
    public void CalculateStandardDeviationWithSteps_GeneratesSteps()
    {
        var values = new List<double> { 2, 4, 4, 4, 5, 5, 7, 9 };

        var result = StandardDeviationTutor.CalculateStandardDeviationWithSteps(values);

        Assert.NotEmpty(result.Steps);
        string stepsText = result.GetStepsAsString();
        Assert.Contains("Step 1", stepsText);
        Assert.Contains("mean", stepsText, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("deviation", stepsText, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("variance", stepsText, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("Standard Deviation", stepsText);
    }

    [Fact]
    public void CalculateVarianceWithSteps_SimpleDataSet_ReturnsCorrectValue()
    {
        var values = new List<double> { 2, 4, 4, 4, 5, 5, 7, 9 };

        var result = StandardDeviationTutor.CalculateVarianceWithSteps(values);

        Assert.Equal(4.0, result.Value, 1); // Variance is 4.0
    }
}
