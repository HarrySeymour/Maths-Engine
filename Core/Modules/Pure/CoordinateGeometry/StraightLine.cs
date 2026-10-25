namespace Core.Modules.Pure.CoordinateGeometry;

/// <summary>
/// Represents a straight line in a 2D space, defined by the equation y = mx + c
/// </summary>
/// <param name="Gradient">The gradient (m) of the line.</param>
/// <param name="YIntercept">The y-intercept (c) of the line.</param>
public record StraightLine(double Gradient, double YIntercept)
{
    /// <summary>
    /// Creates a new StraightLine instance from two coordinates.
    /// </summary>
    /// <param name="a">The first coordinate.</param>
    /// <param name="b">The second coordinate.</param>
    /// <returns>A new StraightLine record.</returns>
    public static StraightLine FromTwoCoordinates(Coordinate a, Coordinate b)
    {
        // Handle vertical line
        if (a.X == b.X)
        {
            // For a vertical line the gradient is infinite
            return new StraightLine(double.PositiveInfinity, a.X);
        }

        var gradient = (b.Y - a.Y) / (b.X - a.X);
        var yIntercept = a.Y - gradient * a.X;
        return new StraightLine(gradient, yIntercept);
    }

    /// <summary>
    /// Returns a string representation of the line's equation.
    /// </summary>
    public override string ToString()
    {
        // Handle vertical line
        if (double.IsPositiveInfinity(Gradient))
            return $"x = {YIntercept}";

        var gradientString = Gradient switch
        {
            1 => "x",
            -1 => "-x",
            _ => $"{Gradient}"
        };

        var interceptString = YIntercept switch
        {
            0 => "",
            > 0 => $" + {YIntercept}",
            < 0 => $" - {Math.Abs(YIntercept)}"
        };

        return $"y = {gradientString}{interceptString}";
    }
}