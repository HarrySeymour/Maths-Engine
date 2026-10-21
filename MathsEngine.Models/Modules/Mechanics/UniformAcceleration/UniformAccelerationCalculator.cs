namespace MathsEngine.Core.Modules.Mechanics.UniformAcceleration;

/// <summary>
/// Provides methods for calculations involving uniform acceleration, commonly known as the SUVAT equations.
/// </summary>
public static class UniformAccelerationCalculator
{
    /// <summary>
    /// Calculates the average velocity given an initial and final velocity.
    /// </summary>
    /// <param name="initialVelocity">The initial velocity (u).</param>
    /// <param name="finalVelocity">The final velocity (v).</param>
    /// <returns>The average velocity.</returns>
    /// <exception cref="InvalidOperationException">Thrown when either initial or final velocity is null.</exception>
    public static double CalculateAverageVelocity(double? initialVelocity, double? finalVelocity)
    {
        if (initialVelocity is null || finalVelocity is null)
            throw new InvalidOperationException("Initial and final velocity must have a value.");

        return (initialVelocity.Value + finalVelocity.Value) / 2;
    }

    /// <summary>
    /// Solves the equation of motion v = u + at for the single unknown variable.
    /// </summary>
    /// <param name="v">Final velocity. Can be null if it's the value to be calculated.</param>
    /// <param name="u">Initial velocity. Can be null if it's the value to be calculated.</param>
    /// <param name="a">Acceleration. Can be null if it's the value to be calculated.</param>
    /// <param name="t">Time. Can be null if it's the value to be calculated.</param>
    /// <returns>The calculated value of the missing variable, or null if all variables are provided.</returns>
    /// <exception cref="InvalidOperationException">Thrown if more than one input is null.</exception>
    /// <exception cref="DivideByZeroException">Thrown if a division by zero occurs during calculation.</exception>
    public static double? CalculateVUAT(double? v, double? u, double? a, double? t)
    {
        int missingCount =
            (v is null ? 1 : 0) +
            (u is null ? 1 : 0) +
            (a is null ? 1 : 0) +
            (t is null ? 1 : 0);

        if (missingCount > 1)
            throw new InvalidOperationException("Exactly one parameter must be null to be calculated.");

        if (v is null) // v = u + at 
            return u.Value + a.Value * t.Value;

        if (u is null) // u = v - at
            return v.Value - a.Value * t.Value;

        if (a is null) // a = (v - u) / t
        {
            if (t.Value == 0)
                throw new DivideByZeroException("Time (t) cannot be zero when calculating acceleration.");
            return (v.Value - u.Value) / t.Value;
        }

        if (t is null) // t = (v - u) / a
        {
            if (a.Value == 0)
                throw new DivideByZeroException("Acceleration (a) cannot be zero when calculating time.");
            return (v.Value - u.Value) / a.Value;
        }

        return null;
    }

    /// <summary>
    /// Solves the equation of motion v^2 = u^2 + 2as for the single unknown variable.
    /// </summary>
    /// <param name="v">Final velocity. Can be null if it's the value to be calculated.</param>
    /// <param name="u">Initial velocity. Can be null if it's the value to be calculated.</param>
    /// <param name="a">Acceleration. Can be null if it's the value to be calculated.</param>
    /// <param name="s">Displacement. Can be null if it's the value to be calculated.</param>
    /// <returns>The calculated value of the missing variable, or null if all variables are provided.</returns>
    /// <exception cref="InvalidOperationException">Thrown if more than one input is null.</exception>
    /// <exception cref="DivideByZeroException">Thrown if a division by zero occurs during calculation.</exception>
    public static double? CalculateVUAS(double? v, double? u, double? a, double? s)
    {
        int missingCount =
            (v is null ? 1 : 0) +
            (u is null ? 1 : 0) +
            (a is null ? 1 : 0) +
            (s is null ? 1 : 0);

        if (missingCount > 1)
            throw new InvalidOperationException("Exactly one parameter must be null to be calculated.");

        if (v is null) // v^2 = u^2 + 2as
            return Math.Sqrt(Math.Pow(u.Value, 2) + 2 * a.Value * s.Value);
        if (u is null) // u^2 = v^2 - 2as
            return Math.Sqrt(Math.Pow(v.Value, 2) - 2 * a.Value * s.Value);
        if (a is null) // a = (v^2 - u^2) / 2s
        {
            if (s.Value == 0)
                throw new DivideByZeroException("Displacement (s) cannot be zero when calculating acceleration.");
            return (Math.Pow(v.Value, 2) - Math.Pow(u.Value, 2)) / (2 * s.Value);
        }
        if (s is null) // s = (v^2 - u^2) / 2a
        {
            if (a.Value == 0)
                throw new DivideByZeroException("Acceleration (a) cannot be zero when calculating displacement.");
            return (Math.Pow(v.Value, 2) - Math.Pow(u.Value, 2)) / (2 * a.Value);
        }

        return null;
    }

    /// <summary>
    /// Solves the equation of motion s = 0.5 * (u + v) * t for the single unknown variable.
    /// </summary>
    /// <param name="s">Displacement. Can be null if it's the value to be calculated.</param>
    /// <param name="u">Initial velocity. Can be null if it's the value to be calculated.</param>
    /// <param name="v">Final velocity. Can be null if it's the value to be calculated.</param>
    /// <param name="t">Time. Can be null if it's the value to be calculated.</param>
    /// <returns>The calculated value of the missing variable, or null if all variables are provided.</returns>
    /// <exception cref="InvalidOperationException">Thrown if more than one input is null.</exception>
    /// <exception cref="DivideByZeroException">Thrown if a division by zero occurs during calculation.</exception>
    public static double? CalculateSUVT(double? s, double? u, double? v, double? t)
    {
        int missingCount =
            (s is null ? 1 : 0) +
            (u is null ? 1 : 0) +
            (v is null ? 1 : 0) +
            (t is null ? 1 : 0);

        if (missingCount > 1)
            throw new InvalidOperationException("Exactly one parameter must be null to be calculated.");

        if (s is null) // s = 0.5 * (u + v) * t
            return (u.Value + v.Value) * t.Value / 2;
        if (u is null) // u = (2s / t) - v
        {
            if (t.Value == 0)
                throw new DivideByZeroException("Time (t) cannot be zero when calculating initial velocity.");
            return (2 * s.Value / t.Value) - v.Value;
        }
        if (v is null) // v = (2s / t) - u
        {
            if (t.Value == 0)
                throw new DivideByZeroException("Time (t) cannot be zero when calculating final velocity.");
            return (2 * s.Value / t.Value) - u.Value;
        }
        if (t is null) // t = 2s / (u + v)
        {
            double velocitySum = u.Value + v.Value;
            if (velocitySum == 0)
                throw new DivideByZeroException("Sum of initial and final velocities (u + v) cannot be zero.");
            return (2 * s.Value) / velocitySum;
        }

        return null;
    }

    /// <summary>
    /// Solves the equation of motion s = ut + 0.5at^2 for the single unknown variable.
    /// </summary>
    /// <param name="s">Displacement. Can be null if it's the value to be calculated.</param>
    /// <param name="u">Initial velocity. Can be null if it's the value to be calculated.</param>
    /// <param name="a">Acceleration. Can be null if it's the value to be calculated.</param>
    /// <param name="t">Time. Can be null if it's the value to be calculated.</param>
    /// <returns>The calculated value of the missing variable, or null if all variables are provided. When calculating time (t), returns the positive, non-zero solution.</returns>
    /// <exception cref="InvalidOperationException">Thrown if more than one input is null, or if no real solution exists for time (t).</exception>
    /// <exception cref="DivideByZeroException">Thrown if a division by zero occurs during calculation.</exception>
    public static double? CalculateSUTAT(double? s, double? u, double? a, double? t)
    {
        int missingCount =
            (s is null ? 1 : 0) +
            (u is null ? 1 : 0) +
            (a is null ? 1 : 0) +
            (t is null ? 1 : 0);

        if (missingCount > 1)
            throw new InvalidOperationException("Exactly one parameter must be null to be calculated.");

        if (s is null) // s = ut + 0.5at^2
        {
            return u.Value * t.Value + 0.5 * a.Value * Math.Pow(t.Value, 2);
        }
        if (u is null) // u = (s - 0.5at^2) / t
        {
            if (t.Value == 0)
                throw new DivideByZeroException("Time (t) cannot be zero.");
            return (s.Value - 0.5 * a.Value * Math.Pow(t.Value, 2)) / t.Value;
        }
        if (a is null) // a = 2(s - ut) / t^2
        {
            if (t.Value == 0)
                throw new DivideByZeroException("Time (t) cannot be zero.");
            return 2 * (s.Value - u.Value * t.Value) / Math.Pow(t.Value, 2);
        }
        if (t is null) // 0.5at^2 + ut - s = 0
        {
            double acceleration = a.Value;
            double initialVelocity = u.Value;
            double displacement = s.Value;

            if (acceleration == 0)
            {
                if (initialVelocity == 0)
                    throw new InvalidOperationException("Both acceleration and initial velocity cannot be zero.");
                return displacement / initialVelocity;
            }

            // Solve using the quadratic formula: t = (-b ± sqrt(b^2 - 4ac)) / 2a
            double discriminant = Math.Pow(initialVelocity, 2) - 4 * (0.5 * acceleration) * (-displacement);
            if (discriminant < 0)
                throw new InvalidOperationException("No real solution for time (t) exists with these values.");

            double t1 = (-initialVelocity + Math.Sqrt(discriminant)) / (2 * 0.5 * acceleration);
            double t2 = (-initialVelocity - Math.Sqrt(discriminant)) / (2 * 0.5 * acceleration);

            // Return the positive, non-zero solution if one exists
            if (t1 > 0) return Convert.ToDouble(t1);
            if (t2 > 0) return Convert.ToDouble(t2);
            return null; // Or handle cases where time is zero or negative
        }

        return null;
    }
}

