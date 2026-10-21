using MathsEngine.Core.Utils.Exceptions;
using MathsEngine.Modules.Statistics.Dispersion;

namespace MathsEngine.Core.Modules.Statistics.Dispersion
{
    public class ArrayOfNumbersCalculator : IStandardDeviation
    {
        private readonly List<double> _originalValues;
        private readonly List<double> _sortedValues;
        private readonly int _numValues;

        public IReadOnlyList<double> OriginalValues => _originalValues.AsReadOnly();
        public IReadOnlyList<double> SortedValues => _sortedValues.AsReadOnly();
        public double Mean { get; private set; }
        public double Median { get; private set; }
        public IReadOnlyList<double> Mode { get; private set; } = [];
        public double Range { get; private set; }
        public double Q1 { get; private set; }
        public double Q3 { get; private set; }
        public double Iqr { get; private set; }
        public double Variance { get; private set; }
        public double StandardDeviation { get; private set; }

        public ArrayOfNumbersCalculator(List<double> originalValues)
        {
            if (originalValues == null)
                throw new NullInputException();

            if (originalValues.Count == 0)
                throw new EmptyDataSetException();

            _originalValues = originalValues;
            _sortedValues = new List<double>(originalValues);
            _sortedValues.Sort();
            _numValues = _sortedValues.Count();
        }
        public void Run()
        {
            CalculateAverages();
            CalculateVarianceAndStdDeviation();
        }
        private void CalculateAverages()
        {
            AverageCalculator<double> averageCalculator = new AverageCalculator<double>();

            Mean = averageCalculator.CalculateMean(_originalValues);
            Median = averageCalculator.CalculateMedian(_originalValues);
            Mode = averageCalculator.CalculateMode(_originalValues);
            Range = averageCalculator.CalculateRange(_originalValues);

            var quartiles = averageCalculator.GetInterQuartileRange(_originalValues);
            Q1 = quartiles[0];
            Q3 = quartiles[1];
            Iqr = quartiles[2];
        }
        private void CalculateVarianceAndStdDeviation()
        {
            double sumOfSquaredDistances = 0;
            for (int i = 0; i < _numValues; i++)
            {
                double distance = _originalValues[i] - Mean;
                sumOfSquaredDistances += distance * distance;
            }

            Variance = sumOfSquaredDistances / _numValues;
            StandardDeviation = Math.Sqrt(Variance);
        }
    }
}