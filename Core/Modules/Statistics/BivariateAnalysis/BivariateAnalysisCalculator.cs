using Core.Utils.Exceptions;

namespace Core.Modules.Statistics.BivariateAnalysis
{
    /// <summary>
    /// Performs a complete bivariate analysis for a given set of paired scores.
    /// This class is instantiated for a single calculation and holds its own state.
    /// </summary>
    public class BivariateAnalysisCalculator
    {
        private readonly List<double> _scores1;
        private readonly List<double> _scores2;

        public Correlation Correlation { get; private set; }
        public string CorrelationString;

        public List<double> Ranks1 { get; private set; }
        public List<double> Ranks2 { get; private set; }
        public List<double> Difference { get; private set; }
        public List<double> DifferenceSquared { get; private set; }
        public double SumDifferenceSquared { get; private set; }
        public double CorrelationCoefficient { get; private set; }

        /// <summary>
        /// Initializes a new instance of the calculator with two sets of scores.
        /// </summary>
        public BivariateAnalysisCalculator(List<double> scores1, List<double> scores2)
        {
            if (scores1 == null || scores2 == null)
                throw new NullInputException();

            if (scores1.Count != scores2.Count)
                throw new ListsNotSameSizeException();

            if (scores1.Count < 2)
                throw new InsufficientDataException();

            _scores1 = scores1;
            _scores2 = scores2;
        }

        /// <summary>
        /// Runs the full sequence of calculations.
        /// </summary>
        public void Run()
        {
            Ranks1 = CalculateRanksFor(_scores1);
            Ranks2 = CalculateRanksFor(_scores2);
            Difference = CalculateDifference();
            DifferenceSquared = CalculateDifferenceSquared();
            CorrelationCoefficient = CalculateCorrelationValue();
            Correlation = GetCorrelation();
            CorrelationString = GetCorrelationString();
        }

        /// <summary>
        /// Ranks a list of numbers from highest to lowest
        /// </summary>
        /// <param name="scores"> The list of values to be ranked</param>
        /// <returns></returns>
        private List<double> CalculateRanksFor(List<double> scores)
        {
            var sorted = new List<double>(scores);
            sorted.Sort();
            sorted.Reverse();

            var ranks = new double[scores.Count];
            int rank = 1;

            for (int i = 0; i < sorted.Count; i++)
            {
                double score = sorted[i];
                var tiedIndexes = new List<int>();
                for (int j = 0; j < scores.Count; j++)
                {
                    if (scores[j] == score && ranks[j] == 0)
                        tiedIndexes.Add(j);
                }

                if (tiedIndexes.Count > 0)
                {
                    double averageRank = 0;
                    for (int k = 0; k < tiedIndexes.Count; k++)
                        averageRank += rank + k;
                    averageRank /= tiedIndexes.Count;

                    foreach (int index in tiedIndexes)
                        ranks[index] = averageRank;
                }
                rank += tiedIndexes.Count;
            }
            return ranks.ToList();
        }

        /// <summary>
        /// Calculates the difference between the ranks of the two data sets for each index
        /// </summary>
        /// <returns> The list of differences. </returns>
        private List<double> CalculateDifference()
        {
            var differences = new List<double>();
            for (int i = 0; i < Ranks1.Count; i++)
            {
                differences.Add(Ranks1[i] - Ranks2[i]);
            }
            return differences;
        }

        private List<double> CalculateDifferenceSquared()
        {
            var diffsSquared = new List<double>();
            double sum = 0;
            foreach (var val in Difference)
            {
                double squared = Math.Pow(val, 2);
                diffsSquared.Add(squared);
                sum += squared;
            }
            SumDifferenceSquared = sum;
            return diffsSquared;
        }

        /// <summary>
        /// Calculates the decimal value for the correlation between the two data sets
        /// </summary>
        /// <returns></returns>
        private double CalculateCorrelationValue()
        {
            double topLine = SumDifferenceSquared * 6;
            double bottomLine = _scores1.Count * (Math.Pow(_scores1.Count, 2) - 1);

            // This check is safe now because the constructor ensures Count is >= 2
            return 1 - (topLine / bottomLine);
        }

        private Correlation GetCorrelation() => CorrelationExtensions.getCorrelation(CorrelationCoefficient);

        private string GetCorrelationString() => CorrelationExtensions.displayString(Correlation);
    }
}