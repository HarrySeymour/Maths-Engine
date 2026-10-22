using MathsEngine.Core.Explanations.Models.Base;
using MathsEngine.Core.Utils.Exceptions;
using MathsEngine.Core.Modules.Mechanics.Dynamics;

namespace MathsEngine.Core.Explanations.Mechanics
{
    /// <summary>
    /// Provides step-by-step explanations for Newton's Laws calculations.
    /// </summary>
    public static class NewtonsLawsTutor
    {
        public static ScalarCalculationResult CalculateFmaWithSteps(double? f, double? m, double? a)
        {
            // Validate inputs early
            int missingCount =
                (f is null ? 1 : 0) +
                (m is null ? 1 : 0) +
                (a is null ? 1 : 0);

            if (missingCount != 1)
                throw new NullInputException("Must be ONE missing value to perform the calculation");

            var steps = new List<string>();

            // Step 1: Identify known and unknown values
            steps.Add("Step 1: Identify known and unknown values");
            steps.Add($"  Force (F) = {(f.HasValue ? f.Value.ToString("F2") : "UNKNOWN")}");
            steps.Add($"  Mass (m) = {(m.HasValue ? m.Value.ToString("F2") : "UNKNOWN")}");
            steps.Add($"  Acceleration (a) = {(a.HasValue ? a.Value.ToString("F2") : "UNKNOWN")}");
            steps.Add("");

            // Step 2: State Newton's Second Law
            steps.Add("Step 2: Apply Newton's Second Law");
            steps.Add("  Formula: F = ma");
            steps.Add("");

            double value;
            string calculationVariable;

            if (f is null)
            {
                // Calculate Force
                calculationVariable = "Force (F)";
                steps.Add("Step 3: Rearrange formula to solve for Force");
                steps.Add("  F = m × a");
                steps.Add($"  F = {m.Value:F2} × {a.Value:F2}");
                steps.Add("");

                value = NewtonsLawsCalculator.CalculateFma(f, m, a).Value;

                steps.Add("Step 4: Calculate the result");
                steps.Add($"  F = {value:F2} N");
                steps.Add("");
            }
            else if (m is null)
            {
                // Calculate Mass
                calculationVariable = "Mass (m)";
                steps.Add("Step 3: Rearrange formula to solve for Mass");
                steps.Add("  m = F / a");
                steps.Add($"  m = {f.Value:F2} / {a.Value:F2}");
                steps.Add("");

                value = NewtonsLawsCalculator.CalculateFma(f, m, a).Value;

                steps.Add("Step 4: Calculate the result");
                steps.Add($"  m = {value:F2} kg");
                steps.Add("");
            }
            else
            {
                // Calculate Acceleration
                calculationVariable = "Acceleration (a)";
                steps.Add("Step 3: Rearrange formula to solve for Acceleration");
                steps.Add("  a = F / m");
                steps.Add($"  a = {f.Value:F2} / {m.Value:F2}");
                steps.Add("");

                value = NewtonsLawsCalculator.CalculateFma(f, m, a).Value;

                steps.Add("Step 4: Calculate the result");
                steps.Add($"  a = {value:F2} m/s²");
                steps.Add("");
            }

            // Final answer
            steps.Add("Final Answer:");
            steps.Add($"  {calculationVariable} = {value:F2}");

            return new ScalarCalculationResult(value, steps);
        }
    }
}
