using MathsEngine.Core.Utils.Exceptions;

namespace MathsEngine.Core.Modules.Pure.PythagorasTheorem
{
    /// <summary>
    /// Provides static methods for Pythagoras theorem calculations
    /// </summary>
    public static class PythagorasCalculator
    {
        /// <summary>
        /// Calculates the length of the hypotenuse given side A and B
        /// </summary>
        /// <param name="a">The length of side A.</param>
        /// <param name="b">The length of side B.</param>
        /// <returns></returns>
        public static double CalculateHypotenuse(double? a, double? b)
        {
            int missingCount =
                (a is null ? 1 : 0) +
                (b is null ? 1 : 0);

            if (missingCount != 0)
                throw new NullInputException();

            if (a <= 0 || b <= 0)
                throw new NegativeSideLengthException();

            double aSquared = Math.Pow(Convert.ToDouble(a), 2);
            double bSquared = Math.Pow(Convert.ToDouble(b), 2);

            return Math.Sqrt(aSquared + bSquared);
        }

        /// <summary>
        /// Calculates the length of a missing side given the hypotenuse and a known side
        /// </summary>
        /// <param name="hypotenuse">The length of the hypotenuse.</param>
        /// <param name="knownSide">The length of the known side.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static double CalculateOtherSide(double? hypotenuse, double? knownSide)
        {
            int missingCount =
                (hypotenuse is null ? 1 : 0) +
                (knownSide is null ? 1 : 0);

            if (missingCount != 0)
                throw new ArgumentException();

            if (hypotenuse <= 0 || knownSide <= 0)
                throw new NegativeSideLengthException();

            if (knownSide >= hypotenuse)
                throw new HypotenuseNotLongestSideException();

            double hSquared = Math.Pow(Convert.ToDouble(hypotenuse), 2);
            double aSquared = Math.Pow(Convert.ToDouble(knownSide), 2);

            return Math.Sqrt(hSquared - aSquared);
        }

        /// <summary>
        /// Checks if the values entered are valid in the Pythagoras Theorem
        /// </summary>
        /// <param name="hypotenuse">The length of the hypotenuse.</param>
        /// <param name="a">The length of one of the shorter sides.</param>
        /// <param name="b">The length of the other shorter side.</param>
        /// <returns></returns>
        public static bool CheckValidCalculation(double? hypotenuse, double? a, double? b)
        {
            int missingCount =
                (hypotenuse is null ? 1 : 0) +
                (a is null ? 1 : 0) +
                (b is null ? 1 : 0);

            if (missingCount != 0)
                throw new NullInputException("Must not be any null values to check for a valid triangle");

            if (hypotenuse <= 0 || a <= 0 || b <= 0)
                throw new NegativeSideLengthException();

            if (hypotenuse <= a || hypotenuse <= b)
                throw new HypotenuseNotLongestSideException();

            double A = Convert.ToDouble(a);
            double B = Convert.ToDouble(b);
            double Hypotenuse = Convert.ToDouble(hypotenuse);

            return Math.Abs((A * A + B * B) - (Hypotenuse * Hypotenuse)) < 1e-9;
        }
    }
}