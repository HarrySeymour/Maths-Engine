using Core.Utils.Exceptions;
using Core.Modules.Statistics.Dispersion;

namespace Core.Modules.Statistics.Dispersion
{
    public class FrequencyTableCalculator : IStandardDeviation
    {
        private readonly List<double> _values;
        private readonly List<int> _frequencies;
        private readonly int _totalFrequency;

        public double Mean { get; private set; }
        public double Variance { get; private set; }
        public double StandardDeviation { get; private set; }

        public FrequencyTableCalculator(List<double> values, List<int> frequencies)
        {
            if (values == null || frequencies == null)
                throw new NullInputException();
            if (values.Count != frequencies.Count)
                throw new ListsNotSameSizeException();
            if (values.Count == 0)
                throw new EmptyDataSetException();
            if (frequencies.Any(f => f < 0))
                throw new InvalidFrequencyException();

            _values = values;
            _frequencies = frequencies;
            _totalFrequency = _frequencies.Sum();
        }

        public void Run()
        {
            CalculateMean();
            CalculateVarianceAndStdDeviation();
        }

        private void CalculateMean()
        {
            if (_totalFrequency == 0)
            {
                Mean = 0;
                return;
            }
            double sumOfFx = 0;
            for (int i = 0; i < _values.Count; i++)
            {
                sumOfFx += _values[i] * _frequencies[i];
            }
            Mean = sumOfFx / _totalFrequency;
        }

        private void CalculateVarianceAndStdDeviation()
        {
            if (_totalFrequency == 0)
            {
                Variance = 0;
                StandardDeviation = 0;
                return;
            }
            double sumOfFxSquared = 0;
            for (int i = 0; i < _values.Count; i++)
            {
                sumOfFxSquared += (Math.Pow(_values[i], 2) * _frequencies[i]);
            }
            Variance = (sumOfFxSquared / _totalFrequency) - Math.Pow(Mean, 2);
            StandardDeviation = Math.Sqrt(Variance);
        }

        public void DisplayData()
        {
            Console.WriteLine($"\nMean: {Mean:F2}");
            Console.WriteLine($"Variance: {Variance:F2}");
            Console.WriteLine($"Standard Deviation: {StandardDeviation:F2}");
        }
    }
}