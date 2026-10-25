using Core.Explanations.Pure.CoordinateGeometry;
using Core.Modules.Pure.CoordinateGeometry;
using Xunit;

namespace Tests.ExplanationsTests.PureTests;

public class CoordinateGeometryTutorTests
{
    [Fact]
    public void CalculateLengthOfStraightLineWithSteps_ShouldReturnCorrectValueAndSteps()
    {
        var a = new Coordinate(0, 0);
        var b = new Coordinate(3, 4);
        var result = CoordinateGeometryTutor.CalculateLengthOfStraightLineWithSteps(a, b);

        Assert.Equal(5, result.Value, 5);
        Assert.NotEmpty(result.Steps);
        Assert.Contains("Step 2: State the distance formula", result.Steps);
    }

    [Fact]
    public void CalculateMidpointOfStraightLineWithSteps_ShouldReturnCorrectValueAndSteps()
    {
        var a = new Coordinate(2, 4);
        var b = new Coordinate(6, 8);
        var expected = new Coordinate(4, 6);
        var result = CoordinateGeometryTutor.CalculateMidpointOfStraightLineWithSteps(a, b);

        Assert.Equal(expected, result.CoordinateValue);
        Assert.NotEmpty(result.Steps);
        Assert.Contains("Step 2: State the midpoint formula", result.Steps);
    }

    [Fact]
    public void FindEquationFromTwoCoordinatesWithSteps_ShouldReturnCorrectValueAndSteps()
    {
        var a = new Coordinate(1, 3);
        var b = new Coordinate(3, 7);
        var expected = new StraightLine(2, 1);
        var result = CoordinateGeometryTutor.FindEquationFromTwoCoordinatesWithSteps(a, b);

        Assert.Equal(expected, result.StraightLineValue);
        Assert.NotEmpty(result.Steps);
        Assert.Contains("Step 2: Calculate the gradient (m)", result.Steps);
    }

    [Fact]
    public void FindEquationFromGradientAndCoordinateWithSteps_ShouldReturnCorrectValueAndSteps()
    {
        var gradient = 2;
        var point = new Coordinate(3, 8);
        var expected = new StraightLine(2, 2);
        var result = CoordinateGeometryTutor.FindEquationFromGradientAndCoordinateWithSteps(gradient, point);

        Assert.Equal(expected, result.StraightLineValue);
        Assert.NotEmpty(result.Steps);
        Assert.Contains("Step 2: Use the point and gradient to find the y-intercept (c)", result.Steps);
    }
}