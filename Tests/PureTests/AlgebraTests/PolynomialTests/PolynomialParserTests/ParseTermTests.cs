using Core.Modules.Pure.Algebra.Core;
using Xunit;

namespace Tests.PureTests.AlgebraTests.PolynomialTests.PolynomialParserTests;

public class ParseTermTests
{
    [Theory]
    [MemberData(nameof(PolynomialParserTestData.ValidTermCases), MemberType = typeof(PolynomialParserTestData))]
    public void ParseTerm_ValidInput_ReturnsTerm(string input, double expectedCoeff, int expectedPower)
    {
        Term term = PolynomialParser.ParseTerm(input);

        Assert.Equal(expectedCoeff, term.Coefficient);
        Assert.Equal(expectedPower, term.Power);
    }

    [Theory]
    [MemberData(nameof(PolynomialParserTestData.ImplicitOneTermCases), MemberType = typeof(PolynomialParserTestData))]
    public void ParseTerm_ImplicitCoefficientOne_ParsesCorrectly(string input)
    {
        var exception = Record.Exception(() => PolynomialParser.ParseTerm(input));
        
        Assert.Null(exception);
    }

    [Theory]
    [MemberData(nameof(PolynomialParserTestData.NegativeOneTermCases), MemberType = typeof(PolynomialParserTestData))]
    public void ParseTerm_ImplicitCoefficientNegativeOne_ParsesCorrectly(string input)
    {
        var exception = Record.Exception(() => PolynomialParser.ParseTerm(input));
        
        Assert.Null(exception);
    }

    [Theory]
    [MemberData(nameof(PolynomialParserTestData.ConstantTermCases), MemberType = typeof(PolynomialParserTestData))]
    public void ParseTerm_ConstantOnly_ParsesWithPowerZero(string input)
    {
        var exception = Record.Exception(() => PolynomialParser.ParseTerm(input));
        
        Assert.Null(exception);
    }

    [Theory]
    [MemberData(nameof(PolynomialParserTestData.InvalidTermCases), MemberType = typeof(PolynomialParserTestData))]
    public void ParseTerm_InvalidFormat_ThrowsException(string input)
    {
        var exception = Record.Exception(() => PolynomialParser.ParseTerm(input));
        
        Assert.NotNull(exception);
    }
}