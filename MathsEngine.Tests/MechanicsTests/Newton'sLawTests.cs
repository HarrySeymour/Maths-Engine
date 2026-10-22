using MathsEngine.Core.Modules.Mechanics.Dynamics;
using MathsEngine.Core.Utils.Exceptions;
using Xunit;

namespace MathsEngine.Tests.MechanicsTests
{
    public class NewtonsLawTests
    {
        // --- CalculateFma Tests ---

        [Theory]
        [InlineData(null, 10, 5, 50)]     // Find F
        [InlineData(null, 2.5, 4.0, 10)]  // Find F (decimal)
        [InlineData(null, 0.5, 10, 4.9)] // Find F (gravity)
        [InlineData(100, null, 10, 10)]   // Find m
        [InlineData(-50, null, -5, 10)]   // Find m (negative values)
        [InlineData(100, 20, null, 5)]    // Find a
        [InlineData(-100, 20, null, -5)]  // Find a (deceleration)
        [InlineData(0, 15, null, 0)]      // Find a (zero force)
        public void CalculateFma_ValidInputs_ReturnsExpectedValue(
            double? force,
            double? mass,
            double? acceleration,
            double expected)
        {
            var result = NewtonsLawsCalculator.CalculateFma(force, mass, acceleration);
            Assert.Equal(expected, result.Value, 3);
        }

        [Theory]
        [InlineData(100, 10, 10)]  // All three values provided
        [InlineData(100, null, null)] // Only one value provided
        [InlineData(null, null, 5)]   // Only one value provided
        public void CalculateFma_InvalidParameterCount_ThrowsNullValuesException(
            double? force,
            double? mass,
            double? acceleration)
        {
            Assert.Throws<NullValuesException>(() => NewtonsLawsCalculator.CalculateFma(force, mass, acceleration));
        }

        [Theory]
        [InlineData(100, null, 0)] // Finding mass when acceleration is 0
        [InlineData(100, 0, null)] // Finding acceleration when mass is 0
        public void CalculateFma_DivisionByZero_ThrowsDivideByZeroException(
            double? force,
            double? mass,
            double? acceleration)
        {
            Assert.Throws<DivideByZeroException>(() => NewtonsLawsCalculator.CalculateFma(force, mass, acceleration));
        }

        // --- CheckValidCalculation Tests ---

        [Theory]
        [InlineData(100, 10, 10, true)]  // 100 == 10 * 10
        [InlineData(50, 5, 10, true)]    // 50 == 5 * 10
        [InlineData(100, 10, 5, false)]  // Incorrect calculation
        [InlineData(0, 10, 0, true)]     // Zero force
        public void CheckValidCalculation_EvaluatesCorrectly(
            double force,
            double mass,
            double acceleration,
            bool expected)
        {
            var result = NewtonsLawsCalculator.CheckValidCalculation(force, mass, acceleration);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(100, 10, null)]
        [InlineData(100, null, 5)]
        [InlineData(null, 10, 5)]
        public void CheckValidCalculation_MissingValue_ThrowsNullValuesException(
            double? force,
            double? mass,
            double? acceleration)
        {
            Assert.Throws<NullValuesException>(() => NewtonsLawsCalculator.CheckValidCalculation(force, mass, acceleration));
        }
    }
}