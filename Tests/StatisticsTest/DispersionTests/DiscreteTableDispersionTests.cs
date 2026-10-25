using Core.Modules.Statistics.Dispersion;
using Core.Utils.Exceptions;
using Xunit;

namespace Tests.StatisticsTest.DispersionTests
{
    public class DiscreteTableDispersionTests
    {
        [Fact]
        public void Constructor_NullLists_ThrowsNullInputException()
        {
            Assert.Throws<NullInputException>(() => new FrequencyTableCalculator(null, new List<int>()));
            Assert.Throws<NullInputException>(() => new FrequencyTableCalculator(new List<double>(), null));
        }

        [Fact]
        public void Constructor_MismatchedLists_ThrowsListsNotSameSizeException()
        {
            var values = new List<double> { 1, 2 };
            var frequencies = new List<int> { 1 };
            Assert.Throws<ListsNotSameSizeException>(() => new FrequencyTableCalculator(values, frequencies));
        }

        [Fact]
        public void Constructor_EmptyLists_ThrowsEmptyDataSetException()
        {
            var values = new List<double>();
            var frequencies = new List<int>();
            Assert.Throws<EmptyDataSetException>(() => new FrequencyTableCalculator(values, frequencies));
        }

        [Fact]
        public void Constructor_NegativeFrequency_ThrowsInvalidFrequencyException()
        {
            var values = new List<double> { 1, 2 };
            var frequencies = new List<int> { 5, -1 };
            Assert.Throws<InvalidFrequencyException>(() => new FrequencyTableCalculator(values, frequencies));
        }

        [Theory]
        [MemberData(nameof(DispersionTestData))]
        public void Run_CalculatesCorrectDispersionResults(
            List<double> values,
            List<int> frequencies,
            double expectedMean,
            double expectedVariance,
            double expectedStandardDeviation)
        {
            var calculator = new FrequencyTableCalculator(values, frequencies);

            calculator.Run();

            Assert.Equal(expectedMean, calculator.Mean, 3);
            Assert.Equal(expectedVariance, calculator.Variance, 3);
            Assert.Equal(expectedStandardDeviation, calculator.StandardDeviation, 3);
        }

        [Fact]
        public void Run_ZeroTotalFrequency_ThrowsInvalidFrequencyException()
        {
            var values = new List<double> { 1, 2, 3 };
            var frequencies = new List<int> { 0, 0, 0 };
            var calculator = new FrequencyTableCalculator(values, frequencies);

            Assert.Throws<InvalidFrequencyException>(() => calculator.Run());
        }

        public static IEnumerable<object[]> DispersionTestData =>
            new List<object[]>
            {
                new object[]
                {
                    new List<double> { 0, 1, 2, 3, 4 },
                    new List<int> { 1, 9, 12, 5, 3 },
                    1.967,
                    0.999,
                    0.999
                },
                new object[]
                {
                    new List<double> { 11, 12, 13, 14, 15, 16 },
                    new List<int> { 1, 5, 10, 11, 7, 4 },
                    13.65,
                    1.528,
                    1.236
                },
                new object[]
                {
                    new List<double> { 10 },
                    new List<int> { 5 },
                    10.0,
                    0.0,
                    0.0
                },
                new object[]
                {
                    new List<double> { -5, -2, 0, 2, 5 },
                    new List<int> { 2, 4, 10, 4, 2 },
                    0.0,
                    5.909,
                    2.431
                },
                new object[]
                {
                    new List<double> { 1.5, 2.5, 3.5 },
                    new List<int> { 10, 20, 10 },
                    2.5,
                    0.5,
                    0.707
                },
                new object[]
                {
                    new List<double> { 10, 20, 30 },
                    new List<int> { 100, 0, 100 },
                    20.0,
                    100.0,
                    10.0
                }
            };
    }
}