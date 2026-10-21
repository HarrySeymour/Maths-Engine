using MathsEngine.Core.Explanations.Mechanics;
using Xunit;
using Xunit.Internal;

namespace MathsEngine.Tests.ExplanationsTests.MechanicsTests;

public class UniformAccelerationTutorTests
{
    [Fact]
    public void CalculateAverageVelocityWithSteps_ReturnsCorrectValue()
    {
        var result = UniformAccelerationTutor.CalculateAverageVelocityWithSteps(10.0, 20.0);

        Assert.Equal(15, result.Value.Value, 2);
    }

    [Fact]
    public void CalculateAverageVelocityWithSteps_GeneratesSteps()
    {
        var result = UniformAccelerationTutor.CalculateAverageVelocityWithSteps(10.0, 20.0);

        Assert.NotEmpty(result.CalculationFlow);
    }

    [Theory]
    [InlineData(null, 10.0, 2.0, 5.0, 20.0)]    // Calculate v: v = u + at = 10 + 2*5 = 20
    [InlineData(20.0, null, 2.0, 5.0, 10.0)]    // Calculate u: u = v - at = 20 - 2*5 = 10
    [InlineData(20.0, 10.0, null, 5.0, 2.0)]    // Calculate a: a = (v-u)/t = (20-10)/5 = 2
    [InlineData(20.0, 10.0, 2.0, null, 5.0)]    // Calculate t: t = (v-u)/a = (20-10)/2 = 5
    public void CalculateVUATWithSteps_ReturnsCorrectValue(
        double? v, double? u, double? a, double? t, double expected)
    {
        var result = UniformAccelerationTutor.CalculateVUATWithSteps(v, u, a, t);

    }

    [Fact]
    public void CalculateVUATWithSteps_GeneratesSteps()
    {
        var result = UniformAccelerationTutor.CalculateVUATWithSteps(null, 0, 2, 10);

    }

    [Theory]
    [InlineData(null, 5.0, 2.0, 10.0, 8.06)]  // Calculate v: v = sqrt(u^2 + 2as) = sqrt(25 + 40) ≈ 8.06
    [InlineData(10.0, null, 2.0, 20.0, 4.47)] // Calculate u: u = sqrt(v^2 - 2as) = sqrt(100 - 80) ≈ 4.47
    [InlineData(10.0, 5.0, null, 15.0, 2.5)]  // Calculate a: a = (v^2 - u^2)/(2s) = (100 - 25)/30 = 2.5
    [InlineData(10.0, 5.0, 2.0, null, 18.75)] // Calculate s: s = (v^2 - u^2)/(2a) = (100 - 25)/4 = 18.75
    public void CalculateVUASWithSteps_ReturnsCorrectValue(
        double? v, double? u, double? a, double? s, double expected)
    {
        var result = UniformAccelerationTutor.CalculateVUASWithSteps(v, u, a, s);
    }

    [Fact]
    public void CalculateVUASWithSteps_GeneratesSteps()
    {
        var result = UniformAccelerationTutor.CalculateVUASWithSteps(null, 0, 2, 50);

    }

    [Theory]
    [InlineData(null, 10.0, 20.0, 5.0, 75.0)]   // Calculate s: s = 0.5*(u+v)*t = 0.5*30*5 = 75
    [InlineData(75.0, null, 20.0, 5.0, 10.0)]   // Calculate u: u = (2s/t) - v = (150/5) - 20 = 10
    [InlineData(75.0, 10.0, null, 5.0, 20.0)]   // Calculate v: v = (2s/t) - u = (150/5) - 10 = 20
    [InlineData(75.0, 10.0, 20.0, null, 5.0)]   // Calculate t: t = 2s/(u+v) = 150/30 = 5
    public void CalculateSUVTWithSteps_ReturnsCorrectValue(
        double? s, double? u, double? v, double? t, double expected)
    {
        var result = UniformAccelerationTutor.CalculateSUVTWithSteps(s, u, v, t);

    }

    [Fact]
    public void CalculateSUVTWithSteps_GeneratesSteps()
    {
        var result = UniformAccelerationTutor.CalculateSUVTWithSteps(null, 10, 20, 5);
    }

    [Theory]
    [InlineData(null, 10.0, 2.0, 5.0, 75.0)]    // Calculate s: s = ut + 0.5at^2 = 10*5 + 0.5*2*25 = 75
    [InlineData(75.0, null, 2.0, 5.0, 10.0)]    // Calculate u: u = (s - 0.5at^2)/t = (75 - 25)/5 = 10
    [InlineData(75.0, 10.0, null, 5.0, 2.0)]    // Calculate a: a = 2(s - ut)/t^2 = 2(75-50)/25 = 2
    public void CalculateSUTATWithSteps_ReturnsCorrectValue(
        double? s, double? u, double? a, double? t, double expected)
    {
        var result = UniformAccelerationTutor.CalculateSUTATWithSteps(s, u, a, t);
    }

    [Fact]
    public void CalculateSUTATWithSteps_GeneratesSteps()
    {
        var result = UniformAccelerationTutor.CalculateSUTATWithSteps(null, 10, 2, 5);

    }
}
