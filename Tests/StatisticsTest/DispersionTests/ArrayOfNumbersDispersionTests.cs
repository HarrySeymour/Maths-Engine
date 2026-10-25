using Core.Modules.Statistics.Dispersion;
using Core.Utils.Exceptions;
using Xunit;

namespace Tests.StatisticsTest.DispersionTests
{
    public class ArrayOfNumbersDispersionTests
    {
        [Fact]
        public void Constructor_NullList_ThrowsNullInputException()
        {
            Assert.Throws<NullInputException>(() => new ArrayOfNumbersCalculator(null));
        }

        [Fact]
        public void Constructor_EmptyList_ThrowsNullInputException()
        {
            var values = new List<double>();
            Assert.Throws<NullInputException>(() => new ArrayOfNumbersCalculator(values));
        }

        [Theory]
        [MemberData(nameof(DispersionTestData))]
        public void Run_CalculatesCorrectDispersionResults(
            List<double> values,
            double expectedMean,
            double expectedVariance,
            double expectedStandardDeviation)
        {
            // Arrange
            var calculator = new ArrayOfNumbersCalculator(values);

            // Act
            calculator.Run();

            // Assert
            Assert.Equal(expectedMean, calculator.Mean, 3);
            Assert.Equal(expectedVariance, calculator.Variance, 3);
            Assert.Equal(expectedStandardDeviation, calculator.StandardDeviation, 3);
        }

        public static IEnumerable<object[]> DispersionTestData =>
            new List<object[]>
            {
                new object[]
                {
                    new List<double> { 1, 2, 3, 4, 5 },
                    3.0,
                    2.0,
                    Math.Sqrt(2.0)
                },
                new object[]
                {
                    new List<double> { 1.5, 2.5, 3.5, 4.5, 5.5 },
                    3.5,
                    2.0,
                    Math.Sqrt(2.0)
                },
                new object[]
                {
                    new List<double> { 5, 5, 5, 5, 5 },
                    5.0,
                    0.0,
                    0.0
                },
                new object[]
                {
                    new List<double> { 600, 470, 170, 430, 300 },
                    394.0,
                    21704.0,
                    147.323
                },
                new object[]
                {
                    new List<double> { 42 },
                    42.0,
                    0.0,
                    0.0
                },
                new object[]
                {
                    new List<double> { -10, -5, 0, 5, 10 },
                    0.0,
                    50.0,
                    7.071
                },
                new object[]
                {
                    new List<double> { -2.5, -1.5, -0.5 },
                    -1.5,
                    0.667,
                    0.816
                },
                new object[]
                {
                    new List<double> { 1000000, 1000002, 1000004 },
                    1000002.0,
                    2.667,
                    1.633
                }
            };
    }
}
