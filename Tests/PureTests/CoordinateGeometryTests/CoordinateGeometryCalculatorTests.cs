using Core.Modules.Pure.CoordinateGeometry;
using Xunit;

namespace Tests.PureTests.CoordinateGeometryTests;

public class CoordinateGeometryCalculatorTests
{
    [Theory]
    [InlineData(0, 0, 3, 4, 5)] // Standard 3-4-5 triangle
    [InlineData(-1, -1, 2, 3, 5)] // Using negative coordinates
    [InlineData(5, 5, 5, 5, 0)] // Zero length
    public void CalculateLengthOfStraightLine_ShouldReturnCorrectLength(double x1, double y1, double x2, double y2, double expected)
    {
        var a = new Coordinate(x1, y1);
        var b = new Coordinate(x2, y2);
        var result = CoordinateGeometryCalculator.CalculateLengthOfStraightLine(a, b);
        Assert.Equal(expected, result, precision: 5);
    }

    [Theory]
    [InlineData(0, 0, 10, 10, 5, 5)]
    [InlineData(-2, -4, 6, 8, 2, 2)]
    [InlineData(5, 3, 5, 3, 5, 3)] // Midpoint of a point is itself
    public void CalculateMidpointOfStraightLine_ShouldReturnCorrectMidpoint(double x1, double y1, double x2, double y2, double expectedX, double expectedY)
    {
        var a = new Coordinate(x1, y1);
        var b = new Coordinate(x2, y2);
        var expected = new Coordinate(expectedX, expectedY);
        var result = CoordinateGeometryCalculator.CalculateMidpointOfStraightLine(a, b);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 0, 1, 1, 1)] // Positive gradient
    [InlineData(0, 0, 1, -1, -1)] // Negative gradient
    [InlineData(0, 0, 5, 0, 0)] // Horizontal line
    [InlineData(0, 0, 0, 5, double.PositiveInfinity)] // Vertical line
    public void CalculateGradientBetweenTwoCoordinates_ShouldReturnCorrectGradient(double x1, double y1, double x2, double y2, double expected)
    {
        var a = new Coordinate(x1, y1);
        var b = new Coordinate(x2, y2);
        var result = CoordinateGeometryCalculator.CalculateGradientBetweenTwoCoordinates(a, b);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void FindEquationFromGradientAndCoordinate_ShouldReturnCorrectEquation()
    {
        var gradient = 2;
        var point = new Coordinate(3, 8); // y = 2x + c => 8 = 2*3 + c => c = 2
        var expected = new StraightLine(2, 2);
        var result = CoordinateGeometryCalculator.FindEquationFromGradientAndCoordinate(gradient, point);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void FindEquationFromTwoCoordinates_ShouldReturnCorrectEquation()
    {
        var a = new Coordinate(1, 3);
        var b = new Coordinate(3, 7); // m = (7-3)/(3-1) = 4/2 = 2.  c = 3 - 2*1 = 1.
        var expected = new StraightLine(2, 1);
        var result = CoordinateGeometryCalculator.FindEquationFromTwoCoordinates(a, b);
        Assert.Equal(expected, result);
    }
}