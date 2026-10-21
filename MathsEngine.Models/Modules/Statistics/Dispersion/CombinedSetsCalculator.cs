using MathsEngine.Core.Utils.Exceptions;
using MathsEngine.Modules.Statistics.Dispersion;

namespace MathsEngine.Core.Modules.Statistics.Dispersion
{
    public class CombinedSetsCalculator : IStandardDeviation
    {
        private readonly int _n1;
        private readonly double _mean1;
        private readonly double _stdDev1;

        private readonly int _n2;
        private readonly double _mean2;
        private readonly double _stdDev2;

        public double Mean { get; private set; }
        public double Variance { get; private set; }
        public double StandardDeviation { get; private set; }

        public CombinedSetsCalculator(int n1, double mean1, double stdDev1, int n2, double mean2, double stdDev2)
        {
            if (n1 <= 0 || n2 <= 0)
                throw new InsufficientDataException();
            if (stdDev1 < 0 || stdDev2 < 0)
                throw new ArgumentException("Standard deviation cannot be negative.");

            _n1 = n1;
            _mean1 = mean1;
            _stdDev1 = stdDev1;

            _n2 = n2;
            _mean2 = mean2;
            _stdDev2 = stdDev2;
        }

        public void Run()
        {
            // Step 1: Calculate the combined mean
            Mean = ((_n1 * _mean1) + (_n2 * _mean2)) / (_n1 + _n2);

            // Step 2: Use the formula Var = (Sum of x^2 / n) - mean^2
            // to find the sum of x^2 for each set.
            // Sum of x^2 = n * (Var + mean^2)
            double variance1 = Math.Pow(_stdDev1, 2);
            double variance2 = Math.Pow(_stdDev2, 2);
            double sumOfXSquared1 = _n1 * (variance1 + Math.Pow(_mean1, 2));
            double sumOfXSquared2 = _n2 * (variance2 + Math.Pow(_mean2, 2));

            // Step 3: Calculate the combined variance
            double combinedSumOfXSquared = sumOfXSquared1 + sumOfXSquared2;
            int combinedN = _n1 + _n2;
            Variance = (combinedSumOfXSquared / combinedN) - Math.Pow(Mean, 2);

            // Step 4: Calculate the combined standard deviation
            StandardDeviation = Math.Sqrt(Variance);
        }

        public void DisplayData()
        {
            Console.WriteLine($"\nCombined Mean: {Mean:F2}");
            Console.WriteLine($"Combined Variance: {Variance:F2}");
            Console.WriteLine($"Combined Standard Deviation: {StandardDeviation:F2}");
        }
    }
}