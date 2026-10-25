using Core.Explanations.Models.Base;
using Core.Modules.Statistics.Dispersion;
using Core.Modules.Statistics.Dispersion;

namespace Core.Explanations.Statistics
{
    /// <summary>
    /// Provides step-by-step explanations for standard deviation and variance calculations.
    /// </summary>
    public static class StandardDeviationTutor
    {
        public static ScalarCalculationResult CalculateStandardDeviationWithSteps(List<double> values)
        {
            var steps = new List<string>();

            steps.Add("Step 1: Identify the data set");
            steps.Add($"  Values: [{string.Join(", ", values)}]");
            steps.Add($"  Number of values (n): {values.Count}");
            steps.Add("");

            // Calculate mean
            steps.Add("Step 2: Calculate the mean (average)");
            steps.Add($"  Mean = Sum of all values / n");
            double sum = values.Sum();
            double mean = sum / values.Count;
            steps.Add($"  Mean = {sum:F2} / {values.Count} = {mean:F2}");
            steps.Add("");

            // Calculate deviations
            steps.Add("Step 3: Calculate the deviation from the mean for each value");
            steps.Add("  Deviation = Value - Mean");
            var deviations = new List<double>();
            foreach (var value in values)
            {
                double deviation = value - mean;
                deviations.Add(deviation);
                steps.Add($"  {value:F2} - {mean:F2} = {deviation:F2}");
            }
            steps.Add("");

            // Square the deviations
            steps.Add("Step 4: Square each deviation");
            var squaredDeviations = new List<double>();
            foreach (var deviation in deviations)
            {
                double squared = deviation * deviation;
                squaredDeviations.Add(squared);
                steps.Add($"  ({deviation:F2})² = {squared:F2}");
            }
            steps.Add("");

            // Calculate variance
            steps.Add("Step 5: Calculate the variance");
            steps.Add("  Variance = Sum of squared deviations / n");
            double sumSquaredDeviations = squaredDeviations.Sum();
            double variance = sumSquaredDeviations / values.Count;
            steps.Add($"  Variance = {sumSquaredDeviations:F2} / {values.Count} = {variance:F2}");
            steps.Add("");

            // Calculate standard deviation
            steps.Add("Step 6: Calculate the standard deviation");
            steps.Add("  Standard Deviation = √Variance");
            
            var calculator = new ArrayOfNumbersCalculator(values);
            calculator.Run();
            double standardDeviation = calculator.StandardDeviation;
            
            steps.Add($"  Standard Deviation = √{variance:F2} = {standardDeviation:F2}");
            steps.Add("");

            steps.Add("Final Answer:");
            steps.Add($"  Mean = {mean:F2}");
            steps.Add($"  Variance = {variance:F2}");
            steps.Add($"  Standard Deviation = {standardDeviation:F2}");

            return new ScalarCalculationResult(standardDeviation, steps);
        }

        public static ScalarCalculationResult CalculateVarianceWithSteps(List<double> values)
        {
            var steps = new List<string>();

            steps.Add("Step 1: Identify the data set");
            steps.Add($"  Values: [{string.Join(", ", values)}]");
            steps.Add($"  Number of values (n): {values.Count}");
            steps.Add("");

            // Calculate mean
            steps.Add("Step 2: Calculate the mean (average)");
            steps.Add($"  Mean = Sum of all values / n");
            double sum = values.Sum();
            double mean = sum / values.Count;
            steps.Add($"  Mean = {sum:F2} / {values.Count} = {mean:F2}");
            steps.Add("");

            // Calculate deviations and squared deviations
            steps.Add("Step 3: Calculate deviations from mean and square them");
            steps.Add("  For each value: (Value - Mean)²");
            var squaredDeviations = new List<double>();
            foreach (var value in values)
            {
                double deviation = value - mean;
                double squared = deviation * deviation;
                squaredDeviations.Add(squared);
                steps.Add($"  ({value:F2} - {mean:F2})² = ({deviation:F2})² = {squared:F2}");
            }
            steps.Add("");

            // Calculate variance
            steps.Add("Step 4: Calculate the variance");
            steps.Add("  Variance = Sum of squared deviations / n");
            double sumSquaredDeviations = squaredDeviations.Sum();
            
            var calculator = new ArrayOfNumbersCalculator(values);
            calculator.Run();
            double variance = calculator.Variance;
            
            steps.Add($"  Variance = {sumSquaredDeviations:F2} / {values.Count} = {variance:F2}");
            steps.Add("");

            steps.Add("Final Answer:");
            steps.Add($"  Variance = {variance:F2}");

            return new ScalarCalculationResult(variance, steps);
        }
    }
}
