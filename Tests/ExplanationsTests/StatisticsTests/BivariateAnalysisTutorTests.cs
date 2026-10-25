using Xunit;
using Core.Explanations.Statistics;

namespace Tests.ExplanationsTests.StatisticsTests;

public class BivariateAnalysisTutorTests
{
    [Fact]
    public void CalculateSpearmanRankWithSteps_PerfectPositiveCorrelation_ReturnsOne()
    {
        var scores1 = new List<double> { 10, 20, 30, 40, 50 };
        var scores2 = new List<double> { 15, 25, 35, 45, 55 };

        var result = BivariateAnalysisTutor.CalculateSpearmanRankWithSteps(scores1, scores2);

        Assert.Equal(1.0, result.Correlation, 2);
    }

    [Fact]
    public void CalculateSpearmanRankWithSteps_PerfectNegativeCorrelation_ReturnsNegativeOne()
    {
        var scores1 = new List<double> { 10, 20, 30, 40, 50 };
        var scores2 = new List<double> { 50, 40, 30, 20, 10 };

        var result = BivariateAnalysisTutor.CalculateSpearmanRankWithSteps(scores1, scores2);

        Assert.Equal(-1.0, result.Correlation, 2);
    }

    [Fact]
    public void CalculateSpearmanRankWithSteps_GeneratesSteps()
    {
        var scores1 = new List<double> { 10, 20, 30 };
        var scores2 = new List<double> { 15, 25, 35 };

        var result = BivariateAnalysisTutor.CalculateSpearmanRankWithSteps(scores1, scores2);

        Assert.NotEmpty(result.Steps);
        string stepsText = result.Steps;
        Assert.Contains("Step 1", stepsText);
        Assert.Contains("Rank", stepsText);
        Assert.Contains("difference", stepsText, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("Spearman", stepsText);
    }

    [Fact]
    public void CalculateSpearmanRankWithSteps_IncludesRankingDetails()
    {
        var scores1 = new List<double> { 5, 10, 15 };
        var scores2 = new List<double> { 8, 12, 16 };

        var result = BivariateAnalysisTutor.CalculateSpearmanRankWithSteps(scores1, scores2);

        string stepsText = result.Steps;
        Assert.Contains("Ranks for Data Set 1", stepsText);
        Assert.Contains("Ranks for Data Set 2", stepsText);
    }

    [Fact]
    public void CalculateSpearmanRankWithSteps_ShowsDifferenceCalculations()
    {
        var scores1 = new List<double> { 1, 2, 3 };
        var scores2 = new List<double> { 3, 2, 1 };

        var result = BivariateAnalysisTutor.CalculateSpearmanRankWithSteps(scores1, scores2);

        string stepsText = result.Steps;
        Assert.Contains("difference in ranks", stepsText, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("d²", stepsText);
    }

    [Fact]
    public void CalculateSpearmanRankWithSteps_IncludesFormula()
    {
        var scores1 = new List<double> { 10, 20, 30 };
        var scores2 = new List<double> { 12, 22, 32 };

        var result = BivariateAnalysisTutor.CalculateSpearmanRankWithSteps(scores1, scores2);

        string stepsText = result.Steps;
        Assert.Contains("rs = 1 -", stepsText);
        Assert.Contains("6Σd²", stepsText);
    }

    [Fact]
    public void CalculateSpearmanRankWithSteps_IncludesInterpretation()
    {
        var scores1 = new List<double> { 10, 20, 30, 40 };
        var scores2 = new List<double> { 15, 25, 35, 45 };

        var result = BivariateAnalysisTutor.CalculateSpearmanRankWithSteps(scores1, scores2);

        string stepsText = result.Steps;
        Assert.Contains("Interpret", stepsText);
        Assert.Contains("correlation", stepsText, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void CalculateSpearmanRankWithSteps_WeakCorrelation()
    {
        var scores1 = new List<double> { 1, 2, 3, 4, 5 };
        var scores2 = new List<double> { 3, 1, 5, 2, 4 };

        var result = BivariateAnalysisTutor.CalculateSpearmanRankWithSteps(scores1, scores2);

        Assert.InRange(result.Correlation, -1.0, 1.0);
        Assert.NotEmpty(result.Steps);
    }
}
