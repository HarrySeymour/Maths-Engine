using Core.Modules.Statistics.BivariateAnalysis;

namespace Core.Explanations.Statistics
{
    /// <summary>
    /// Provides step-by-step explanations for Spearman's Rank correlation calculations.
    /// </summary>
    public static class BivariateAnalysisTutor
    {
        // Changed the return type from BivariateAnalysisResult to a ValueTuple
        public static (List<double> Ranks1, List<double> Ranks2, List<double> Difference,
                       List<double> DifferenceSquared, double SumDifferenceSquared,
                       double Correlation, string CorrelationInterpretation, string Steps)
            CalculateSpearmanRankWithSteps(List<double> scores1, List<double> scores2)
        {
            var steps = new List<string>();

            steps.Add("Step 1: Identify the paired data sets");
            steps.Add($"  Data Set 1: [{string.Join(", ", scores1)}]");
            steps.Add($"  Data Set 2: [{string.Join(", ", scores2)}]");
            steps.Add($"  Number of pairs (n): {scores1.Count}");
            steps.Add("");

            // Calculate ranks
            steps.Add("Step 2: Rank each data set (highest value gets rank 1)");
            var calculator = new BivariateAnalysisCalculator(scores1, scores2);
            calculator.Run();

            steps.Add("  Ranks for Data Set 1:");
            for (int i = 0; i < scores1.Count; i++)
            {
                steps.Add($"    Value {scores1[i]} → Rank {calculator.Ranks1[i]}");
            }
            steps.Add("");

            steps.Add("  Ranks for Data Set 2:");
            for (int i = 0; i < scores2.Count; i++)
            {
                steps.Add($"    Value {scores2[i]} → Rank {calculator.Ranks2[i]}");
            }
            steps.Add("");

            // Calculate differences
            steps.Add("Step 3: Calculate the difference in ranks (d) for each pair");
            steps.Add("  d = Rank1 - Rank2");
            for (int i = 0; i < calculator.Difference.Count; i++)
            {
                steps.Add($"  Pair {i + 1}: {calculator.Ranks1[i]:F1} - {calculator.Ranks2[i]:F1} = {calculator.Difference[i]:F1}");
            }
            steps.Add("");

            // Square the differences
            steps.Add("Step 4: Square each difference (d²)");
            for (int i = 0; i < calculator.DifferenceSquared.Count; i++)
            {
                steps.Add($"  ({calculator.Difference[i]:F1})² = {calculator.DifferenceSquared[i]:F2}");
            }
            steps.Add("");

            // Sum of squared differences
            steps.Add("Step 5: Calculate Σd² (sum of squared differences)");
            steps.Add($"  Σd² = {string.Join(" + ", calculator.DifferenceSquared.Select(d => d.ToString("F2")))}");
            steps.Add($"  Σd² = {calculator.SumDifferenceSquared:F2}");
            steps.Add("");

            // Calculate Spearman's rank correlation coefficient
            steps.Add("Step 6: Calculate Spearman's Rank Correlation Coefficient (rs)");
            steps.Add("  Formula: rs = 1 - (6Σd²) / (n(n² - 1))");

            int n = scores1.Count;
            double numerator = 6 * calculator.SumDifferenceSquared;
            double denominator = n * (Math.Pow(n, 2) - 1);

            steps.Add($"  rs = 1 - (6 × {calculator.SumDifferenceSquared:F2}) / ({n} × ({n}² - 1))");
            steps.Add($"  rs = 1 - {numerator:F2} / {denominator:F2}");
            steps.Add($"  rs = 1 - {numerator / denominator:F4}");
            steps.Add($"  rs = {calculator.CorrelationCoefficient:F4}");
            steps.Add("");

            // Interpret correlation
            steps.Add("Step 7: Interpret the correlation");
            steps.Add($"  Correlation coefficient: {calculator.CorrelationCoefficient:F4}");
            steps.Add($"  Interpretation: {calculator.CorrelationString}");
            steps.Add("");

            string interpretation = GetCorrelationInterpretation(calculator.CorrelationCoefficient);
            steps.Add("  Correlation strength:");
            steps.Add($"  {interpretation}");
            steps.Add("");

            steps.Add("Final Answer:");
            steps.Add($"  Spearman's Rank Correlation Coefficient = {calculator.CorrelationCoefficient:F4}");
            steps.Add($"  Interpretation: {calculator.CorrelationString}");

            // Join the steps string array together right here
            string formattedSteps = string.Join(Environment.NewLine, steps);

            return (
                calculator.Ranks1,
                calculator.Ranks2,
                calculator.Difference,
                calculator.DifferenceSquared,
                calculator.SumDifferenceSquared,
                calculator.CorrelationCoefficient,
                calculator.CorrelationString,
                formattedSteps
            );
        }

        private static string GetCorrelationInterpretation(double rs)
        {
            double absRs = Math.Abs(rs);
            string direction = rs >= 0 ? "positive" : "negative";

            if (absRs == 1.0)
                return $"Perfect {direction} correlation";
            if (absRs >= 0.8)
                return $"Strong {direction} correlation";
            if (absRs >= 0.6)
                return $"Moderate {direction} correlation";
            if (absRs >= 0.4)
                return $"Weak {direction} correlation";
            if (absRs > 0)
                return $"Very weak {direction} correlation";
            return "No correlation";
        }
    }
}