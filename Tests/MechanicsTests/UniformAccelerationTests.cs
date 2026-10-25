using Core.Utils.Exceptions;
using Core.Modules.Mechanics.UniformAcceleration;
using Xunit;

namespace Tests.MechanicsTests
{
    public class UniformAccelerationCalculatorTests
    {
        // --- v = u + at ---

        [Theory]
        [InlineData(null, 10, 2, 5, 20)]    // Find v
        [InlineData(null, 30, -5, 4, 10)]   // Find v (deceleration)
        [InlineData(20, null, 2, 5, 10)]    // Find u
        [InlineData(20, 10, null, 5, 2)]    // Find a
        [InlineData(20, 10, 2, null, 5)]    // Find t
        public void CalculateVUAT_ValidInputs_ReturnsExpectedValue(
            double? v, double? u, double? a, double? t, double expected)
        {
            var result = UniformAccelerationCalculator.CalculateVUAT(v, u, a, t);
            Assert.Equal(expected, result.Value, 3);
        }

        // --- s = 0.5 * (u + v) * t ---

        [Theory]
        [InlineData(null, 10, 20, 5, 75)]   // Find s
        [InlineData(75, null, 20, 5, 10)]   // Find u
        [InlineData(75, 10, null, 5, 20)]   // Find v
        [InlineData(75, 10, 20, null, 5)]   // Find t
        public void CalculateSUVT_ValidInputs_ReturnsExpectedValue(
            double? s, double? u, double? v, double? t, double expected)
        {
            var result = UniformAccelerationCalculator.CalculateSUVT(s, u, v, t);
            Assert.Equal(expected, result.Value, 3);
        }

        [Fact]
        public void CalculateSUVT_ZeroSumVelocity_ThrowsDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => UniformAccelerationCalculator.CalculateSUVT(10, 10, -10, null));
        }

        // --- v^2 = u^2 + 2as ---

        [Theory]
        [InlineData(null, 5, 2, 10, 8.062)] // Find v (sqrt(65))
        [InlineData(20, null, 2, 75, 10)]   // Find u
        [InlineData(20, 10, null, 75, 2)]   // Find a
        [InlineData(20, 10, 2, null, 75)]   // Find s
        public void CalculateVUAS_ValidInputs_ReturnsExpectedValue(
            double? v, double? u, double? a, double? s, double expected)
        {
            var result = UniformAccelerationCalculator.CalculateVUAS(v, u, a, s);
            Assert.Equal(expected, result.Value, 3);
        }

        // --- s = ut + 1/2at^2 ---

        [Theory]
        [InlineData(null, 10, 2, 5, 75)]    // Find s
        [InlineData(null, 0, 10, 3, 44.1)]  // Find s (free fall from rest)
        [InlineData(75, null, 2, 5, 10)]   // Find u
        [InlineData(75, 10, null, 5, 2)]    // Find a
        public void CalculateSUTAT_ValidInputs_ReturnsExpectedValue(
            double? s, double? u, double? a, double? t, double expected)
        {
            var result = UniformAccelerationCalculator.CalculateSUTAT(s, u, a, t);
            Assert.Equal(expected, result.Value, 3);
        }

        // --- Average Velocity ---

        [Theory]
        [InlineData(10, 20, 15)]
        [InlineData(-10, -30, -20)]
        [InlineData(0, 50, 25)]
        public void CalculateAverageVelocity_ValidInputs_ReturnsCorrectAverage(
            double u, double v, double expected)
        {
            var result = UniformAccelerationCalculator.CalculateAverageVelocity(u, v);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateAverageVelocity_NullInput_ThrowsNullInputException()
        {
            Assert.Throws<NullInputException>(() => UniformAccelerationCalculator.CalculateAverageVelocity(null, 20));
        }
    }
}