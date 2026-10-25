using Core.Modules.Pure.Algebra.Core;
using Xunit;

namespace Tests.PureTests.AlgebraTests.PolynomialTests.PolynomialParserTests;

public class ParsePolynomialTests
{
    [Fact]
    public void ParsePolynomial_NullInput_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => PolynomialParser.ParsePolynomial(null));
    }

    [Fact]
    public void ParsePolynomial_EmptyInput_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => PolynomialParser.ParsePolynomial(""));
    }

    [Theory]
    [MemberData(nameof(PolynomialParserTestData.ValidPolynomialCases), MemberType = typeof(PolynomialParserTestData))]
    public void ParsePolynomial_ValidInput_ReturnsPolynomial(string expression, Polynomial expectedPolynomial)
    {
        var actualPolynomial = PolynomialParser.ParsePolynomial(expression);
        Assert.True(Polynomial.IsLikePolynomial(new Polynomial(actualPolynomial), expectedPolynomial));
    }

    [Theory]
    [MemberData(nameof(PolynomialParserTestData.NegativeExponentPolynomialCases), MemberType = typeof(PolynomialParserTestData))]
    public void ParsePolynomial_NegativeExponents_ParsesCorrectly(string expression)
    {
        var exception = Record.Exception(() => new Polynomial(PolynomialParser.ParsePolynomial(expression)));

        Assert.Null(exception);
    }

    [Theory]
    [MemberData(nameof(PolynomialParserTestData.MalformedPolynomialCases), MemberType = typeof(PolynomialParserTestData))]
    public void ParsePolynomial_MalformedExpression_ThrowsException(string expression)
    {
        var exception = Record.Exception(() => new Polynomial(PolynomialParser.ParsePolynomial(expression)));
        
        Assert.NotNull(exception);
    }

    [Theory]
    [MemberData(nameof(PolynomialParserTestData.DecimalPolynomialCases), MemberType = typeof(PolynomialParserTestData))]
    public void ParsePolynomial_DecimalCoefficients_ParsesCorrectly(string expression)
    {
        var exception = Record.Exception(() => new Polynomial(PolynomialParser.ParsePolynomial(expression)));
        
        Assert.Null(exception);
    }

    [Theory]
    [MemberData(nameof(PolynomialParserTestData.LargeExponentPolynomialCases), MemberType = typeof(PolynomialParserTestData))]
    public void ParsePolynomial_LargeExponents_ParsesCorrectly(string expression)
    {
        var exception = Record.Exception(() => new Polynomial(PolynomialParser.ParsePolynomial(expression)));
        
        Assert.Null(exception);
    }
}