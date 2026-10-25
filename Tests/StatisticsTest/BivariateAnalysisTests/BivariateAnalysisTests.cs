using Core.Utils.Exceptions;
using Core.Modules.Statistics.BivariateAnalysis;
using Xunit;

namespace Tests.StatisticsTest.BivariateAnalysisTests
{
    public class BivariateAnalysisTests
    {
        [Fact]
        public void Constructor_NullFirstScoreList_ThrowsNullInputException()
        {
            var scores2 = new List<double> { 1, 2, 3 };
            Assert.Throws<NullInputException>(() => new BivariateAnalysisCalculator(null, scores2));
        }

        [Fact]
        public void Constructor_NullSecondScoreList_ThrowsNullInputException()
        {
            var scores1 = new List<double> { 1, 2, 3 };
            Assert.Throws<NullInputException>(() => new BivariateAnalysisCalculator(scores1, null));
        }

        [Fact]
        public void Constructor_MismatchedListSizes_ThrowsListsNotSameSizeException()
        {
            var scores1 = new List<double> { 1, 2, 3 };
            var scores2 = new List<double> { 1, 2 };
            Assert.Throws<ListsNotSameSizeException>(() => new BivariateAnalysisCalculator(scores1, scores2));
        }

        [Fact]
        public void Constructor_EmptyLists_ThrowsException()
        {
            var scores1 = new List<double>();
            var scores2 = new List<double>();

            Assert.Throws<InsufficientDataException>(() => new BivariateAnalysisCalculator(scores1, scores2));
        }

        [Fact]
        public void Constructor_SingleElementLists_ThrowsException()
        {
            var scores1 = new List<double> { 5.0 };
            var scores2 = new List<double> { 10.0 };

            Assert.Throws<InsufficientDataException>(() => new BivariateAnalysisCalculator(scores1, scores2));
        }

        [Theory]
        [MemberData(nameof(BivariateAnalysisTestData.TestData), MemberType = typeof(BivariateAnalysisTestData))]
        public void Run_CalculatesCorrectBivariateAnalysisResults(
            List<double> scores1,
            List<double> scores2,
            double expectedSumDifferenceSquared,
            double expectedCorrelationCoefficient,
            Correlation expectedCorrelation)
        {
            var calculator = new BivariateAnalysisCalculator(scores1, scores2);

            calculator.Run();

            Assert.Equal(expectedSumDifferenceSquared, calculator.SumDifferenceSquared, 2);
            Assert.Equal(expectedCorrelationCoefficient, calculator.CorrelationCoefficient, 3);
            Assert.Equal(expectedCorrelation, calculator.Correlation);
        }
    }
}