using MathsEngine.Core.Explanations.Models.Base;
using MathsEngine.Modules.Pure.CoordinateGeometry;

namespace MathsEngine.Core.Explanations.Pure.CoordinateGeometry;

public static class CoordinateGeometryTutor
{
    public static ScalarCalculationResult CalculateLengthOfStraightLineWithSteps(Coordinate a, Coordinate b)
    {
        var steps = new List<string>();

        steps.Add("Step 1: Identify the coordinates");
        steps.Add($"  Point A = {a}");
        steps.Add($"  Point B = {b}");
        steps.Add("");

        steps.Add("Step 2: State the distance formula");
        steps.Add("  Formula: d = √((x₂ - x₁)² + (y₂ - y₁)²)");
        steps.Add($"  d = √(({b.X} - {a.X})² + ({b.Y} - {a.Y})²)");
        steps.Add("");

        steps.Add("Step 3: Calculate the differences in X and Y");
        double dx = b.X - a.X;
        double dy = b.Y - a.Y;
        steps.Add($"  Δx (change in x) = {b.X} - {a.X} = {dx}");
        steps.Add($"  Δy (change in y) = {b.Y} - {a.Y} = {dy}");
        steps.Add("");

        steps.Add("Step 4: Square the differences");
        double dxSquared = Math.Pow(dx, 2);
        double dySquared = Math.Pow(dy, 2);
        steps.Add($"  (Δx)² = {dx}² = {dxSquared:F2}");
        steps.Add($"  (Δy)² = {dy}² = {dySquared:F2}");
        steps.Add("");

        steps.Add("Step 5: Sum the squares");
        double sumOfSquares = dxSquared + dySquared;
        steps.Add($"  d² = {dxSquared:F2} + {dySquared:F2} = {sumOfSquares:F2}");
        steps.Add("");

        steps.Add("Step 6: Take the square root");
        double length = CoordinateGeometryCalculator.CalculateLengthOfStraightLine(a, b);
        steps.Add($"  d = √{sumOfSquares:F2} = {length:F2}");
        steps.Add("");

        steps.Add("Final Answer:");
        steps.Add($"  The length of the line is {length:F2} units.");

        return new ScalarCalculationResult(length, steps);
    }

    public static CoordinateCalculationResult CalculateMidpointOfStraightLineWithSteps(Coordinate a, Coordinate b)
    {
        var steps = new List<string>();

        steps.Add("Step 1: Identify the coordinates");
        steps.Add($"  Point A = {a}");
        steps.Add($"  Point B = {b}");
        steps.Add("");

        steps.Add("Step 2: State the midpoint formula");
        steps.Add("  Formula: M = ((x₁ + x₂)/2, (y₁ + y₂)/2)");
        steps.Add($"  M = (({a.X} + {b.X})/2, ({a.Y} + {b.Y})/2)");
        steps.Add("");

        steps.Add("Step 3: Calculate the sum of X and Y coordinates");
        double sumX = a.X + b.X;
        double sumY = a.Y + b.Y;
        steps.Add($"  Sum of X = {a.X} + {b.X} = {sumX}");
        steps.Add($"  Sum of Y = {a.Y} + {b.Y} = {sumY}");
        steps.Add("");

        steps.Add("Step 4: Divide the sums by 2");
        var midpoint = CoordinateGeometryCalculator.CalculateMidpointOfStraightLine(a, b);
        steps.Add($"  Midpoint X = {sumX} / 2 = {midpoint.X}");
        steps.Add($"  Midpoint Y = {sumY} / 2 = {midpoint.Y}");
        steps.Add("");

        steps.Add("Final Answer:");
        steps.Add($"  The midpoint is {midpoint}.");

        return new CoordinateCalculationResult(midpoint, steps);
    }

    public static StraightLineCalculationResult FindEquationFromTwoCoordinatesWithSteps(Coordinate a, Coordinate b)
    {
        var steps = new List<string>();

        steps.Add("Step 1: Identify the coordinates");
        steps.Add($"  Point A = {a}");
        steps.Add($"  Point B = {b}");
        steps.Add("");

        steps.Add("Step 2: Calculate the gradient (m)");
        steps.Add("  Formula: m = (y₂ - y₁) / (x₂ - x₁)");
        double dx = b.X - a.X;
        double dy = b.Y - a.Y;
        steps.Add($"  m = ({b.Y} - {a.Y}) / ({b.X} - {a.X}) = {dy} / {dx}");
        double gradient = CoordinateGeometryCalculator.CalculateGradientBetweenTwoCoordinates(a, b);
        steps.Add($"  m = {gradient:F2}");
        steps.Add("");

        steps.Add("Step 3: Use a point and the gradient to find the y-intercept (c)");
        steps.Add("  Formula: y = mx + c  =>  c = y - mx");
        steps.Add($"  Using point A {a}:");
        double yIntercept = a.Y - gradient * a.X;
        steps.Add($"  c = {a.Y} - ({gradient:F2} * {a.X}) = {yIntercept:F2}");
        steps.Add("");

        var line = new StraightLine(gradient, yIntercept);
        steps.Add("Step 4: Write the final equation");
        steps.Add("  Equation: y = mx + c");
        steps.Add($"  y = {gradient:F2}x + {yIntercept:F2}");
        steps.Add("");

        steps.Add("Final Answer:");
        steps.Add($"  The equation of the line is {line}.");

        return new StraightLineCalculationResult(line, steps);
    }

    public static StraightLineCalculationResult FindEquationFromGradientAndCoordinateWithSteps(double gradient, Coordinate point)
    {
        var steps = new List<string>();

        steps.Add("Step 1: Identify the given gradient and coordinate");
        steps.Add($"  Gradient (m) = {gradient}");
        steps.Add($"  Point = {point}");
        steps.Add("");

        steps.Add("Step 2: Use the point and gradient to find the y-intercept (c)");
        steps.Add("  Formula: y = mx + c  =>  c = y - mx");
        steps.Add($"  Using point {point}:");
        double yIntercept = point.Y - gradient * point.X;
        steps.Add($"  c = {point.Y} - ({gradient:F2} * {point.X}) = {yIntercept:F2}");
        steps.Add("");

        var line = new StraightLine(gradient, yIntercept);
        steps.Add("Step 3: Write the final equation");
        steps.Add("  Equation: y = mx + c");
        steps.Add($"  y = {gradient:F2}x + {yIntercept:F2}");
        steps.Add("");

        steps.Add("Final Answer:");
        steps.Add($"  The equation of the line is {line}.");

        return new StraightLineCalculationResult(line, steps);
    }
}