using MathsEngine.Core.Explanations.Models.Base;

namespace MathsEngine.Core.Explanations.Pure.PythagorasTheorem
{
    /// <summary>
    /// Provides step-by-step explanations for Pythagoras theorem calculations.
    /// </summary>
    public static class PythagorasTheoremTutor
    {
        public static ScalarCalculationResult CalculateHypotenuseWithSteps(double? sideA, double? sideB)
        {
            // Validate inputs early to provide better error messages
            if (sideA is null || sideB is null)
                throw new Utils.Exceptions.NullInputException();

            var steps = new List<string>();

            // Step 1: Identify known values
            steps.Add("Step 1: Identify known values");
            steps.Add($"  Side A = {sideA}");
            steps.Add($"  Side B = {sideB}");
            steps.Add("");

            // Step 2: State the Pythagorean theorem
            steps.Add("Step 2: Apply Pythagorean Theorem");
            steps.Add("  Formula: c² = a² + b²");
            steps.Add($"  c² = {sideA}² + {sideB}²");
            steps.Add("");

            // Step 3: Square the sides
            steps.Add("Step 3: Calculate squares");
            double aSquared = Math.Pow(sideA.Value, 2);
            double bSquared = Math.Pow(sideB.Value, 2);
            steps.Add($"  {sideA}² = {aSquared:F2}");
            steps.Add($"  {sideB}² = {bSquared:F2}");
            steps.Add("");

            // Step 4: Add the squares
            steps.Add("Step 4: Add the squares");
            double sum = aSquared + bSquared;
            steps.Add($"  c² = {aSquared:F2} + {bSquared:F2} = {sum:F2}");
            steps.Add("");

            // Step 5: Take square root
            steps.Add("Step 5: Take the square root");
            double value = MathsEngine.Core.Modules.Pure.PythagorasTheorem.PythagorasCalculator.CalculateHypotenuse(sideA, sideB);
            steps.Add($"  c = √{sum:F2} = {value:F2}");
            steps.Add("");

            // Final answer
            steps.Add("Final Answer:");
            steps.Add($"  The hypotenuse is {value:F2} units");

            return new ScalarCalculationResult(value, steps);
        }

        public static ScalarCalculationResult CalculateOtherSideWithSteps(double? hypotenuse, double? knownSide)
        {
            // Validate inputs early to provide better error messages
            if (hypotenuse is null || knownSide is null)
                throw new Utils.Exceptions.NullInputException();

            var steps = new List<string>();

            // Step 1: Identify known values
            steps.Add("Step 1: Identify known values");
            steps.Add($"  Hypotenuse (c) = {hypotenuse}");
            steps.Add($"  Known Side (a) = {knownSide}");
            steps.Add("");

            // Step 2: Rearrange formula
            steps.Add("Step 2: Rearrange Pythagorean Theorem");
            steps.Add("  Formula: c² = a² + b²");
            steps.Add("  Rearranged: b² = c² - a²");
            steps.Add($"  b² = {hypotenuse}² - {knownSide}²");
            steps.Add("");

            // Step 3: Square the values
            steps.Add("Step 3: Calculate squares");
            double hSquared = Math.Pow(hypotenuse.Value, 2);
            double aSquared = Math.Pow(knownSide.Value, 2);
            steps.Add($"  {hypotenuse}² = {hSquared:F2}");
            steps.Add($"  {knownSide}² = {aSquared:F2}");
            steps.Add("");

            // Step 4: Subtract
            steps.Add("Step 4: Subtract the squares");
            double difference = hSquared - aSquared;
            steps.Add($"  b² = {hSquared:F2} - {aSquared:F2} = {difference:F2}");
            steps.Add("");

            // Step 5: Take square root
            steps.Add("Step 5: Take the square root");
            double value = MathsEngine.Core.Modules.Pure.PythagorasTheorem.PythagorasCalculator.CalculateOtherSide(hypotenuse, knownSide);
            steps.Add($"  b = √{difference:F2} = {value:F2}");
            steps.Add("");

            // Final answer
            steps.Add("Final Answer:");
            steps.Add($"  The other side is {value:F2} units");

            return new ScalarCalculationResult(value, steps);
        }
    }
}
