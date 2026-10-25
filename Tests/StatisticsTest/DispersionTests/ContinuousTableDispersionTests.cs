using Core.Modules.Statistics.Dispersion;
using Core.Utils.Exceptions;
using Xunit;

namespace Tests.StatisticsTest.DispersionTests
{
    public class ContinuousTableDispersionTests
    {
        [Fact]
        public void Constructor_NullLists_ThrowsNullInputException()
        {
            Assert.Throws<NullInputException>(() => new ContinuousTableCalculator(null, new List<int>()));
            Assert.Throws<NullInputException>(() => new ContinuousTableCalculator(new List<string>(), null));
        }

        [Fact]
        public void Constructor_MismatchedLists_ThrowsListsNotSameSizeException()
        {
            var intervals = new List<string> { "10-20", "20-30" };
            var frequencies = new List<int> { 1 };
            Assert.Throws<ListsNotSameSizeException>(() => new ContinuousTableCalculator(intervals, frequencies));
        }

        [Fact]
        public void Constructor_EmptyLists_ThrowsEmptyDataSetException()
        {
            var intervals = new List<string>();
            var frequencies = new List<int>();
            Assert.Throws<EmptyDataSetException>(() => new ContinuousTableCalculator(intervals, frequencies));
        }

        [Fact]
        public void Constructor_NegativeFrequency_ThrowsInvalidFrequencyException()
        {
            var intervals = new List<string> { "10-20", "20-30" };
            var frequencies = new List<int> { 5, -1 };
            Assert.Throws<InvalidFrequencyException>(() => new ContinuousTableCalculator(intervals, frequencies));
        }

        [Fact]
        public void Run_InvalidIntervalFormat_ThrowsInvalidClassIntervalFormatException()
        {
            var intervals = new List<string> { "10-20", "30_40" }; // Invalid format
            var frequencies = new List<int> { 5, 5 };
            var calculator = new ContinuousTableCalculator(intervals, frequencies);
            Assert.Throws<InvalidClassIntervalFormatException>(() => calculator.Run());
        }

        [Theory]
        [MemberData(nameof(DispersionTestData))]
        public void Run_CalculatesCorrectDispersionResults(
            List<string> intervals,
            List<int> frequencies,
            double expectedMean,
            double expectedVariance,
            double expectedStandardDeviation)
        {
            var calculator = new ContinuousTableCalculator(intervals, frequencies);

            calculator.Run();

            Assert.Equal(expectedMean, calculator.Mean, 1); // Rounded to 1 decimal place for this test
            Assert.Equal(expectedVariance, calculator.Variance, 0); // Rounded to integer for this test
            Assert.Equal(expectedStandardDeviation, calculator.StandardDeviation, 1); // Rounded to 1 decimal place for this test
        }

        [Fact]
        public void Run_ZeroTotalFrequency_ThrowsInvalidFrequencyException()
        {
            var intervals = new List<string> { "10-20", "20-30" };
            var frequencies = new List<int> { 0, 0 };
            var calculator = new ContinuousTableCalculator(intervals, frequencies);

            Assert.Throws<InvalidFrequencyException>(() => calculator.Run());
        }

        public static IEnumerable<object[]> DispersionTestData =>
            new List<object[]>
            {
                new object[]
                {
                    new List<string> { "10-20", "20-30", "30-50", "50-90" },
                    new List<int> { 9, 11, 13, 7 },
                    36.0,
                    304.0,
                    17.4
                },
                new object[]
                {
                    new List<string> { "0-10", "10-20", "20-30" },
                    new List<int> { 5, 5, 5 },
                    15.0,
                    66.7,
                    8.2
                },
                new object[]
                {
                    new List<string> { "0-100" },
                    new List<int> { 10 },
                    50.0,
                    833.3,
                    28.9
                },
                new object[]
                {
                    new List<string> { "0-5", "5-10", "10-15", "15-20" },
                    new List<int> { 10, 0, 0, 10 },
                    10.0,
                    70.8,
                    8.4
                },
                new object[]
                {
                    new List<string> { "10.5-20.5", "20.5-30.5" },
                    new List<int> { 4, 6 },
                    21.5,
                    24.0,
                    4.9
                }
            };
    }
}