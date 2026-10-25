using Core.Modules.Statistics.BivariateAnalysis;

namespace Tests.StatisticsTest.BivariateAnalysisTests;

public class BivariateAnalysisTestData
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[]
            {
                new List<int> { 10, 20, 30, 40, 50 },
                new List<int> { 1, 2, 3, 4, 5 },
                0.0,
                1.0,
                Correlation.PerfectPositive
            },
            new object[]
            {
                new List<int> { 10, 20, 30, 40, 50 },
                new List<int> { 5, 4, 3, 2, 1 },
                40.0,
                -1.0,
                Correlation.PerfectNegative
            },
            new object[]
            {
                new List<int> { 1, 2, 3, 4, 5 },
                new List<int> { 3, 1, 5, 2, 4 },
                10.0,
                0.0,
                Correlation.Invalid
            },
            new object[]
            {
                new List<int> { 10, 15, 15, 20, 25 },
                new List<int> { 5, 8, 10, 10, 12 },
                4.5,
                0.55,
                Correlation.StrongPositive
            },
            new object[]
            {
                new List<int> { 75, 80, 93, 65, 87, 71, 98, 68, 84, 77 },
                new List<int> { 82, 78, 86, 72, 91, 80, 95, 75, 89, 74 },
                34.0,
                0.794,
                Correlation.StrongPositive
            },
            new object[]
            {
                new List<double> { 10, 20, 30, 40, 50 },
                new List<double> { 1, 2, 3, 4, 5 },
                0.0,
                1.0,
                Correlation.PerfectPositive
            },
            new object[]
            {
                new List<double> { 10, 20, 30, 40, 50 },
                new List<double> { 5, 4, 3, 2, 1 },
                40.0,
                -1.0,
                Correlation.PerfectNegative
            },
            new object[]
            {
                new List<double> { 1, 2, 3, 4, 5 },
                new List<double> { 3, 1, 5, 2, 4 },
                10.0,
                0.0,
                Correlation.Invalid
            },
            new object[]
            {
                new List<double> { 10, 15, 15, 20, 25 },
                new List<double> { 5, 8, 10, 10, 12 },
                4.5,
                0.55,
                Correlation.StrongPositive
            },
            new object[]
            {
                new List<double> { 75, 80, 93, 65, 87, 71, 98, 68, 84, 77 },
                new List<double> { 82, 78, 86, 72, 91, 80, 95, 75, 89, 74 },
                34.0,
                0.794,
                Correlation.StrongPositive
            },
            new object[]
            {
                new List<double> { -2, -1, 0, 1, 2 },
                new List<double> { 4, 1, 0, 1, 4 },
                20.0,
                0.0,
                Correlation.Invalid
            },
            new object[]
            {
                new List<double> { 10, 20, 30, 40, 50 },
                new List<double> { 50, 30, 40, 20, 10 },
                16.0,
                -0.90,
                Correlation.StrongNegative
            },
            new object[]
            {
                new List<double> { 10, 20 },
                new List<double> { 5, 10 },
                0.0,
                1.0,
                Correlation.PerfectPositive
            },
            new object[]
            {
                new List<double> { 1000, 2000, 3000, 4000, 5000 },
                new List<double> { 100, 200, 300, 400, 500 },
                0.0,
                1.0,
                Correlation.PerfectPositive
            },
            new object[]
            {
                new List<double> { 1.5, 2.5, 3.5, 4.5 },
                new List<double> { 2.2, 3.1, 4.3, 5.0 },
                0.1,
                0.995,
                Correlation.StrongPositive
            },
            new object[]
            {
                new List<double> { 1, 2, 3, 4, 5 },
                new List<double> { 5, 5, 5, 5, 5 },
                10.0,
                0.0,
                Correlation.Invalid
            }
        };
}