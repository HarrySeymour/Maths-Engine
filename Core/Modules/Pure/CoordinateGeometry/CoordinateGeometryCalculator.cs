namespace Core.Modules.Pure.CoordinateGeometry;

public class CoordinateGeometryCalculator
{
    public static double CalculateLengthOfStraightLine(Coordinate a, Coordinate b)
    {
        return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
    }

    public static Coordinate CalculateMidpointOfStraightLine(Coordinate a, Coordinate b)
    {
        return new Coordinate((a.X + b.X) / 2, (a.Y + b.Y) / 2);
    }

    /// <summary>
    /// Calculates the gradient of the line passing through two coordinates.
    /// </summary>
    /// <param name="a">The first coordinate.</param>
    /// <param name="b">The second coordinate.</param>
    /// <returns>The gradient of the line.</returns>
    public static double CalculateGradientBetweenTwoCoordinates(Coordinate a, Coordinate b)
    {
        // Refactored to use the StraightLine class logic
        return StraightLine.FromTwoCoordinates(a, b).Gradient;
    }

    /// <summary>
    /// Finds the equation of a line from its gradient and a single point on the line.
    /// </summary>
    /// <param name="gradient">The gradient of the line.</param>
    /// <param name="point">A coordinate that lies on the line.</param>
    /// <returns>A StraightLine record representing the equation.</returns>
    public static StraightLine FindEquationFromGradientAndCoordinate(double gradient, Coordinate point)
    {
        // Calculate y-intercept c using c = y - mx
        var yIntercept = point.Y - gradient * point.X;
        return new StraightLine(gradient, yIntercept);
    }

    /// <summary>
    /// Finds the equation of a line that passes through two given points.
    /// </summary>
    /// <param name="a">The first coordinate.</param>
    /// <param name="b">The second coordinate.</param>
    /// <returns>A StraightLine record representing the equation.</returns>
    public static StraightLine FindEquationFromTwoCoordinates(Coordinate a, Coordinate b)
    {
        return StraightLine.FromTwoCoordinates(a, b);
    }
}