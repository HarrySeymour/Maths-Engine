using Core.Modules.Pure.Algebra.Core;
using Xunit;

namespace Tests.PureTests.AlgebraTests.TermTests
{
    public class GeneralTermTests
    {
        [Theory]
        [InlineData(2, 3, 2, 16)]        // 2 * 2^3 = 16
        [InlineData(5, 0, 10, 5)]       // constant
        [InlineData(1.5, 2, 4, 24)]
        [InlineData(-2, 3, 3, -54)]
        [InlineData(0, 5, 10, 0)]
        [InlineData(0.5, 4, 2, 8)]
        [InlineData(3, 1, -2, -6)]
        [InlineData(2.5, -1, 4, 0.625)]
        [InlineData(-1.25, -2, 2, -0.3125)]
        [InlineData(10, 2, 0.5, 2.5)]
        public void Evaluate_ShouldReturnCorrectValue(double coeff, int power, double x, double expected)
        {
            var term = new Term(coeff, power);
            var actual = term.Evaluate(x);
            Assert.True(Math.Abs(expected - actual) < 1e-9, $"Expected {expected} but got {actual}");
        }

        [Theory]
        [InlineData(1, -1, 0)]
        [InlineData(2.5, -2, 0)]
        [InlineData(-3, -5, 0)]
        [InlineData(0.1, -1, 0)]
        [InlineData(5, -3, 0)]
        [InlineData(-0.5, -2, 0)]
        [InlineData(10, -4, 0)]
        [InlineData(7, -1, 0)]
        [InlineData(2, -2, 0)]
        [InlineData(3.3, -3, 0)]
        public void Evaluate_NegativePowerAtZero_ShouldThrow(double coeff, int power, double x)
        {
            var term = new Term(coeff, power);
            Assert.Throws<DivideByZeroException>(() => term.Evaluate(x));
        }

        [Theory]
        [InlineData(0, 3, "0")]
        [InlineData(5, 0, "5")]
        [InlineData(-5, 0, "-5")]
        [InlineData(1, 1, "x")]
        [InlineData(-1, 1, "-x")]
        [InlineData(1, 2, "x^2")]
        [InlineData(2, 1, "2x")]
        [InlineData(-3, 3, "-3x^3")]
        [InlineData(0.5, 2, "0.5x^2")]
        [InlineData(-0.25, 1, "-0.25x")]
        public void ToString_ShouldFormatCorrectly(double coeff, int power, string expected)
        {
            var term = new Term(coeff, power);
            Assert.Equal(expected, term.ToString());
        }

        [Theory]
        [InlineData(0, 3, true, "")]
        [InlineData(5, 0, true, "5")]
        [InlineData(1, 1, true, "x")]
        [InlineData(-1, 1, true, "x")]
        [InlineData(2, 1, true, "2x")]
        [InlineData(1, 2, true, "x^2")]
        [InlineData(0.5, 3, true, "0.5x^3")]
        [InlineData(3, 0, true, "3")]
        [InlineData(1, 0, true, "1")]
        [InlineData(4, 5, true, "4x^5")]
        public void FormatTermForDisplay_ShouldFormatWithoutSign(double coeff, int power, bool isFirst, string expected)
        {
            var term = new Term(coeff, power);
            var actual = Term.FormatTermForDisplay(term, isFirst);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 2, 3, 2, true)]
        [InlineData(1, 2, 1, 2, true)]
        [InlineData(5, 0, 2, 0, true)]
        [InlineData(4, 3, 4, 3, true)]
        [InlineData(2, -1, 3, -1, true)]
        [InlineData(1, 1, 1, 2, false)]
        [InlineData(1, 2, 1, 3, false)]
        [InlineData(1, 2, 1, -2, false)]
        [InlineData(1, 2, 1, 0, false)]
        [InlineData(4, 3, 5, 4, false)]
        public void IsLikeTerm_StaticAndInstance_ShouldMatchExpected(double c1, int p1, double c2, int p2, bool expected)
        {
            var t1 = new Term(c1, p1);
            var t2 = new Term(c2, p2);

            Assert.Equal(expected, Term.IsLikeTerm(t1, t2));
            Assert.Equal(expected, t1.IsLikeTerm(t2));
        }

        [Theory]
        [InlineData(1.0, 2, 1.0, 2, true)]
        [InlineData(1.0, 2, 2.0, 2, false)]
        [InlineData(-1.5, 3, -1.5, 3, true)]
        [InlineData(0, 0, 0, 0, true)]
        [InlineData(0, 2, 0, 2, true)]
        [InlineData(1.25, -2, 1.25, -2, true)]
        [InlineData(1.25, -2, -1.25, -2, false)]
        [InlineData(3, 1, 3, 2, false)]
        [InlineData(4, 5, 4, 5, true)]
        [InlineData(0.3333333, 1, 0.3333333, 1, true)]
        public void IsEqualTerm_ShouldReturnExpected(double c1, int p1, double c2, int p2, bool expected)
        {
            var t1 = new Term(c1, p1);
            var t2 = new Term(c2, p2);
            Assert.Equal(expected, t1.IsEqualTerm(t2));
        }
    }
}