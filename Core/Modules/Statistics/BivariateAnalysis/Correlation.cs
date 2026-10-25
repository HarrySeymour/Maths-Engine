namespace Core.Modules.Statistics.BivariateAnalysis
{
    public enum Correlation
    {
        PerfectPositive,
        StrongPositive,
        WeakPositive,
        NoCorrelation,
        WeakNegative,
        StrongNegative,
        PerfectNegative,
        Invalid
    }
    /// <summary>
    /// Provides an extensions method to display the correlations in a user-friendly manner.
    /// </summary>
    internal static class CorrelationExtensions
    {
        internal static string displayString(Correlation correlation)
        {
            switch (correlation)
            {
                case Correlation.PerfectPositive:
                    return "Perfect Positive correlation";
                case Correlation.StrongPositive:
                    return "Strong Positive Correlation";
                case Correlation.WeakPositive:
                    return "Weak Positive Correlation";
                case Correlation.NoCorrelation:
                    return "No Correlation";
                case Correlation.WeakNegative:
                    return "Weak Negative Correlation";
                case Correlation.StrongNegative:
                    return "Strong Negative Correlation";
                case Correlation.PerfectNegative:
                    return "Perfect Negative Correlation";
                default:
                    return "Invalid Correlation";
            }
        }
        internal static Correlation getCorrelation(double correlationValue)
        {
            if(!(correlationValue > 1.0) && !(correlationValue < 0.0))
                if (correlationValue == 1) return Correlation.PerfectPositive;
                if (correlationValue >= 0.7) return Correlation.StrongPositive;
                if (correlationValue > 0) return Correlation.WeakPositive;
                if (correlationValue == 0) return Correlation.NoCorrelation;
                if (correlationValue == -1) return Correlation.PerfectNegative;
                if (correlationValue <= -0.7) return Correlation.StrongNegative;
                if (correlationValue < 0) return Correlation.WeakNegative;

            // Default case for any value outside the -1 to 1 range, though this shouldn't be hit
            // with a valid correlation coefficient.
            return Correlation.Invalid;
        }
    }
}
