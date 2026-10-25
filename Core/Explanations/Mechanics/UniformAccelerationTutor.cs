using Core.Explanations.Models.Abstractions;
using Core.Explanations.Models.Components;
using Core.Explanations.Models.Enums;
using Core.Explanations.Models.Results;
using Core.Measurement.Units.Mechanics.Acceleration;
using Core.Measurement.Units.Mechanics.Displacement;
using Core.Measurement.Units.Mechanics.Time;
using Core.Measurement.Units.Mechanics.Velocity;
using Core.Modules.Mechanics.UniformAcceleration;

namespace Core.Explanations.Mechanics
{
    /// <summary>
    /// Provides step-by-step explanations for Uniform Acceleration (UVATS) calculations.
    /// </summary>
    public static class UniformAccelerationTutor
    {
        public static CalculationResult<Velocity> CalculateAverageVelocityWithSteps(double? initialVelocity, double? finalVelocity)
        {
            if (initialVelocity is null || finalVelocity is null)
                throw new InvalidOperationException("Initial and final velocity must have a value.");

            CalculationInput initialVelocityInput = new CalculationInput("Initial Velocity (u)", new Velocity(initialVelocity.Value, VelocityUnit.MetersPerSecond));
            CalculationInput finalVelocityInput = new CalculationInput("Final Velocity (v)", new Velocity(finalVelocity.Value, VelocityUnit.MetersPerSecond));

            CalculationStep applyFormulaStep = new CalculationStep("Apply the average velocity formula",
                "Average velocity = (u + v) / 2",
                $"  Average velocity = ({initialVelocity.Value:F2} + {finalVelocity.Value:F2}) / 2");

            double averageVelocity =
                UniformAccelerationCalculator.CalculateAverageVelocity(initialVelocity, finalVelocity);

            CalculationStep calculateAverageVelocityStep =
                new CalculationStep("Calculate the sum", result: $"Average Velocity = {averageVelocity:F2}");

            return new CalculationResult<Velocity>(
                CalculationType.Velocity,
                new Velocity(averageVelocity, VelocityUnit.MetersPerSecond), 
                "m/s",
                new List<ICalculationItem>
                {
                    initialVelocityInput, 
                    finalVelocityInput, 
                    applyFormulaStep,
                    calculateAverageVelocityStep
                }, "", 2);
        }

        public static CalculationResult<IMathematicalValue> CalculateVUATWithSteps(double? v, double? u, double? a, double? t)
        {
            int missingCount =
                (v is null ? 1 : 0) +
                (u is null ? 1 : 0) +
                (a is null ? 1 : 0) +
                (t is null ? 1 : 0);

            if (missingCount > 1)
                throw new InvalidOperationException("Exactly one parameter must be null to be calculated.");

            List<ICalculationItem> calculationSteps = new List<ICalculationItem>
            {
                new CalculationInput("Initial Velocity (u)", new Velocity(u.Value, VelocityUnit.MetersPerSecond)),
                new CalculationInput("Final Velocity (v)", new Velocity(v.Value, VelocityUnit.MetersPerSecond)),
                new CalculationInput("Acceleration (a)", new Acceleration(a.Value, AccelerationUnit.MetersPerSecondSquared)),
                new CalculationInput("Time (t)", new Time(t.Value, TimeUnit.Second)),
                new CalculationStep("State the equation", "v = u + at")
            };

            double value;

            if (v is null)
            {
                value = UniformAccelerationCalculator.CalculateVUAT(v, u, a, t).Value;

                calculationSteps.Add(new CalculationStep("Calculating Final Velocity (v)", "v = u + at", 
                        $"v = {u.Value:F2} + {a.Value * t.Value:F2}", $"v = {value:F2} m/s"));

                return new CalculationResult<IMathematicalValue>(
                    CalculationType.Velocity,
                    new Velocity(value, VelocityUnit.MetersPerSecond),
                    "m/s",
                    calculationSteps,
                    "", 2);
            }
            if (u is null)
            {
                value = UniformAccelerationCalculator.CalculateVUAT(v, u, a, t).Value;

                calculationSteps.Add(new CalculationStep("Calculating Initial Velocity (u)", "Rearrange for u = v - at",
                        $"  u = {v.Value:F2} - {a.Value * t.Value:F2}", $"u = {value:F2} m/s"));

                return new CalculationResult<IMathematicalValue>(
                    CalculationType.Velocity,
                    new Velocity(value, VelocityUnit.MetersPerSecond),
                    "m/s",
                    calculationSteps,
                    "", 2);
            }
            if (a is null)
            {
                value = UniformAccelerationCalculator.CalculateVUAT(v, u, a, t).Value;

                calculationSteps.Add(new CalculationStep("Calculating Acceleration (a)", "Rearrange for a = (v-u) / t", 
                    $"  a = ({v.Value:F2} - {u.Value:F2}) / {t.Value:F2}", $"a = {value:F2} m/s²"));

                return new CalculationResult<IMathematicalValue>(
                    CalculationType.Acceleration,
                    new Acceleration(value, AccelerationUnit.MetersPerSecondSquared),
                    "m/s^2",
                    calculationSteps,
                    "", 2);
            }
            if (t is null)
            {
                value = UniformAccelerationCalculator.CalculateVUAT(v, u, a, t).Value;

                calculationSteps.Add(new CalculationStep("Calculating Time (t)", "Rearrange for t = (v - u) / a",
                    $"  t = ({v.Value:F2} - {u.Value:F2}) / {a.Value:F2}", $"t = {value:F2} s"));

                return new CalculationResult<IMathematicalValue>(
                    CalculationType.Time,
                    new Time(value, TimeUnit.Second),
                    "s",
                    calculationSteps,
                    "", 2);
            }

            return new CalculationResult<IMathematicalValue>();
        }

        public static CalculationResult<IMathematicalValue> CalculateVUASWithSteps(double? v, double? u, double? a, double? s)
        {
            int missingCount =
                (v is null ? 1 : 0) +
                (u is null ? 1 : 0) +
                (a is null ? 1 : 0) +
                (s is null ? 1 : 0);

            if (missingCount > 1)
                throw new InvalidOperationException("Exactly one parameter must be null to be calculated.");

            List<ICalculationItem> calculationSteps = new List<ICalculationItem>
            {
                new CalculationInput("Initial Velocity (u)", new Velocity(u.Value, VelocityUnit.MetersPerSecond)),
                new CalculationInput("Final Velocity (v)", new Velocity(v.Value, VelocityUnit.MetersPerSecond)),
                new CalculationInput("Acceleration (a)", new Acceleration(a.Value, AccelerationUnit.MetersPerSecondSquared)),
                new CalculationInput("Displacement (s)", new Displacement(s.Value, DisplacementUnit.Meter)),
                new CalculationStep("State the equation", "v² = u² + 2as")
            };

            double value;

            if (v is null)
            {
                value = UniformAccelerationCalculator.CalculateVUAS(v, u, a, s).Value;

                calculationSteps.Add(new CalculationStep("Calculating Final Velocity (v)", "v = √(u² + 2as)",
                    $"v² = {Math.Pow(u.Value, 2):F2} + {2 * a.Value * s.Value:F2}", $"  v = {value:F2} m/s"));

                return new CalculationResult<IMathematicalValue>(
                    CalculationType.Velocity,
                    new Velocity(value, VelocityUnit.MetersPerSecond),
                    "m/s",
                    calculationSteps,
                    "", 2);
            }
            if (u is null)
            {
                value = UniformAccelerationCalculator.CalculateVUAS(v, u, a, s).Value;

                calculationSteps.Add(new CalculationStep("Calculating Initial Velocity (u)", "u = √(v² - 2as)",
                    $"u² = {Math.Pow(v.Value, 2):F2} - {2 * a.Value * s.Value:F2}", $"  u = {value:F2} m/s"));

                return new CalculationResult<IMathematicalValue>(
                    CalculationType.Velocity,
                    new Velocity(value, VelocityUnit.MetersPerSecond),
                    "m/s",
                    calculationSteps,
                    "", 2);
            }
            if (a is null)
            {
                value = UniformAccelerationCalculator.CalculateVUAS(v, u, a, s).Value;

                calculationSteps.Add(new CalculationStep("Calculating Acceleration (a)", "a = (v² - u²) / 2s",
                    $"a = ({Math.Pow(v.Value, 2):F2} - {Math.Pow(u.Value, 2):F2}) / {2 * s.Value:F2}", $"  a = {value:F2} m/s²"));

                return new CalculationResult<IMathematicalValue>(
                    CalculationType.Acceleration,
                    new Acceleration(value, AccelerationUnit.MetersPerSecondSquared),
                    "m/s^2",
                    calculationSteps,
                    "", 2);
            }
            if (s is null)
            {
                value = UniformAccelerationCalculator.CalculateVUAS(v, u, a, s).Value;

                calculationSteps.Add(new CalculationStep("Calculating Displacement (s)", "s = (v² - u²) / 2a",
                    $"s = ({Math.Pow(v.Value, 2):F2} - {Math.Pow(u.Value, 2):F2}) / {2 * a.Value:F2}", $"  s = {value:F2} m"));

                return new CalculationResult<IMathematicalValue>(
                    CalculationType.Displacement,
                    new Displacement(value, DisplacementUnit.Meter),
                    "m",
                    calculationSteps,
                    "", 2);
            }

            return new CalculationResult<IMathematicalValue>();
        }

        public static CalculationResult<IMathematicalValue> CalculateSUVTWithSteps(double? s, double? u, double? v, double? t)
        {
            int missingCount =
                (s is null ? 1 : 0) +
                (u is null ? 1 : 0) +
                (v is null ? 1 : 0) +
                (t is null ? 1 : 0);

            if (missingCount > 1)
                throw new InvalidOperationException("Exactly one parameter must be null to be calculated.");

            List<ICalculationItem> calculationSteps = new List<ICalculationItem>
            {
                new CalculationInput("Displacement (s)", new Displacement(s.Value, DisplacementUnit.Meter)),
                new CalculationInput("Initial Velocity (u)", new Velocity(u.Value, VelocityUnit.MetersPerSecond)),
                new CalculationInput("Final Velocity (v)", new Velocity(v.Value, VelocityUnit.MetersPerSecond)),
                new CalculationInput("Time (t)", new Time(t.Value, TimeUnit.Second)),
                new CalculationStep("State the equation", "s = 0.5 × (u + v) × t")
            };

            double value;

            if (s is null)
            {
                value = UniformAccelerationCalculator.CalculateSUVT(s, u, v, t).Value;

                calculationSteps.Add(new CalculationStep("Calculating Displacement (s)", "s = 0.5 × (u + v) × t",
                    $"s = 0.5 × ({u.Value:F2} + {v.Value:F2}) × {t.Value:F2}", $"  s = {value:F2} m"));

                return new CalculationResult<IMathematicalValue>(
                    CalculationType.Displacement,
                    new Displacement(value, DisplacementUnit.Meter),
                    "m",
                    calculationSteps,
                    "", 2);
            }
            if (u is null)
            {
                value = UniformAccelerationCalculator.CalculateSUVT(s, u, v, t).Value;

                calculationSteps.Add(new CalculationStep("Calculating Initial Velocity (u)", "u = (2s / t) - v",
                    $"u = (2 × {s.Value:F2} / {t.Value:F2}) - {v.Value:F2}", $"  u = {value:F2} m/s"));

                return new CalculationResult<IMathematicalValue>(
                    CalculationType.Velocity,
                    new Velocity(value, VelocityUnit.MetersPerSecond),
                    "m/s",
                    calculationSteps,
                    "", 2);
            }
            if (v is null)
            {
                value = UniformAccelerationCalculator.CalculateSUVT(s, u, v, t).Value;

                calculationSteps.Add(new CalculationStep("Calculating Final Velocity (v)", "v = (2s / t) - u",
                    $"v = (2 × {s.Value:F2} / {t.Value:F2}) - {u.Value:F2}", $"  v = {value:F2} m/s"));

                return new CalculationResult<IMathematicalValue>(
                    CalculationType.Velocity,
                    new Velocity(value, VelocityUnit.MetersPerSecond),
                    "m/s",
                    calculationSteps,
                    "", 2);
            }
            if (t is null)
            {
                value = UniformAccelerationCalculator.CalculateSUVT(s, u, v, t).Value;

                calculationSteps.Add(new CalculationStep("Calculating Time (t)", "t = 2s / (u + v)",
                    $"t = (2 × {s.Value:F2}) / ({u.Value:F2} + {v.Value:F2})", $"  t = {value:F2} s"));

                return new CalculationResult<IMathematicalValue>(
                    CalculationType.Time,
                    new Time(value, TimeUnit.Second),
                    "s",
                    calculationSteps,
                    "", 2);
            }

            return new CalculationResult<IMathematicalValue>();
        }

        public static CalculationResult<IMathematicalValue> CalculateSUTATWithSteps(double? s, double? u, double? a, double? t)
        {
            int missingCount =
                (s is null ? 1 : 0) +
                (u is null ? 1 : 0) +
                (a is null ? 1 : 0) +
                (t is null ? 1 : 0);

            if (missingCount > 1)
                throw new InvalidOperationException("Exactly one parameter must be null to be calculated.");

            List<ICalculationItem> calculationSteps = new List<ICalculationItem>
            {
                new CalculationInput("Displacement (s)", new Displacement(s.Value, DisplacementUnit.Meter)),
                new CalculationInput("Initial Velocity (u)", new Velocity(u.Value, VelocityUnit.MetersPerSecond)),
                new CalculationInput("Acceleration (a)", new Acceleration(a.Value, AccelerationUnit.MetersPerSecondSquared)),
                new CalculationInput("Time (t)", new Time(t.Value, TimeUnit.Second)),
                new CalculationStep("State the equation", "s = ut + 0.5at²")
            };

            double value;

            if (s is null)
            {
                value = UniformAccelerationCalculator.CalculateSUTAT(s, u, a, t).Value;

                calculationSteps.Add(new CalculationStep("Calculating Displacement (s)", "s = ut + 0.5at²",
                    $"s = ({u.Value:F2} × {t.Value:F2}) + (0.5 × {a.Value:F2} × {t.Value:F2}²)", $"  s = {value:F2} m"));

                return new CalculationResult<IMathematicalValue>(
                    CalculationType.Displacement,
                    new Displacement(value, DisplacementUnit.Meter),
                    "m",
                    calculationSteps,
                    "", 2);
            }
            if (u is null)
            {
                value = UniformAccelerationCalculator.CalculateSUTAT(s, u, a, t).Value;

                calculationSteps.Add(new CalculationStep("Calculating Initial Velocity (u)", "u = (s - 0.5at²) / t",
                    $"u = ({s.Value:F2} - (0.5 × {a.Value:F2} × {t.Value:F2}²)) / {t.Value:F2}", $"  u = {value:F2} m/s"));

                return new CalculationResult<IMathematicalValue>(
                    CalculationType.Velocity,
                    new Velocity(value, VelocityUnit.MetersPerSecond),
                    "m/s",
                    calculationSteps,
                    "", 2);
            }
            if (a is null)
            {
                value = UniformAccelerationCalculator.CalculateSUTAT(s, u, a, t).Value;

                calculationSteps.Add(new CalculationStep("Calculating Acceleration (a)", "a = 2(s - ut) / t²",
                    $"a = 2 × ({s.Value:F2} - ({u.Value:F2} × {t.Value:F2})) / {t.Value:F2}²", $"  a = {value:F2} m/s²"));

                return new CalculationResult<IMathematicalValue>(
                    CalculationType.Acceleration,
                    new Acceleration(value, AccelerationUnit.MetersPerSecondSquared),
                    "m/s^2",
                    calculationSteps,
                    "", 2);
            }
            if (t is null)
            {
                value = UniformAccelerationCalculator.CalculateSUTAT(s, u, a, t).Value;

                calculationSteps.Add(new CalculationStep("Calculating Time (t)", "Solve quadratic equation 0.5at² + ut - s = 0",
                    "Using quadratic formula: t = (-b ± √(b² - 4ac)) / 2a", $"  t = {value:F2} s"));

                return new CalculationResult<IMathematicalValue>(
                    CalculationType.Time,
                    new Time(value, TimeUnit.Second),
                    "s",
                    calculationSteps,
                    "", 2);
            }

            return new CalculationResult<IMathematicalValue>();
        }
    }
}
