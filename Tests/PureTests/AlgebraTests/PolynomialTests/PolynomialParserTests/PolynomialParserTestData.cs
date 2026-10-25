using Core.Modules.Pure.Algebra.Core;

namespace Tests.PureTests.AlgebraTests.PolynomialTests.PolynomialParserTests;

public static class PolynomialParserTestData
{

    public static IEnumerable<object[]> ValidTermCases =>
    [
        new object[] { "3x^2", 3d, 2 },
        new object[] { "-3x^2", -3d, 2 },
        new object[] { "+3x^2", 3d, 2 },
        new object[] { "x", 1d, 1 },
        new object[] { "-x", -1d, 1 },
        new object[] { "+x", 1d, 1 },
        new object[] { "5", 5d, 0 },
        new object[] { "-5", -5d, 0 },
        new object[] { "+5", 5d, 0 },
        new object[] { "0.5x^3", 0.5d, 3 },
        new object[] { "-0.5x^3", -0.5d, 3 },
        new object[] { "x^10", 1d, 10 },
        new object[] { "-x^7", -1d, 7 },
        new object[] { "2x", 2d, 1 },
        new object[] { "-2x", -2d, 1 },
        new object[] { "0x^2", 0d, 2 },
        new object[] { "1x^1", 1d, 1 },
        new object[] { "-1x^1", -1d, 1 },
        new object[] { "42x^0", 42d, 0 },
        new object[] { "7x^-1", 7d, -1 },
        new object[] { "-4x^-2", -4d, -2 },
        new object[] { "3.14159x^2", 3.14159d, 2 },
        new object[] { "-2.71828x", -2.71828d, 1 },
        new object[] { "100x^25", 100d, 25 },
        new object[] { "-9x^100", -9d, 100 }
    ];

    public static IEnumerable<object[]> ImplicitOneTermCases =>
    [
        new object[] { "+x" },
        new object[] { "x" },
        new object[] { "1x" },
        new object[] { "+1x" },
        new object[] { "x^1" },
        new object[] { "1x^1" },
        new object[] { "+x^1" },
        new object[] { "0x" },
        new object[] { "0x^3" },
        new object[] { "-1x" }
    ];

    public static IEnumerable<object[]> NegativeOneTermCases =>
    [
        new object[] { "-x" },
        new object[] { "-1x" },
        new object[] { "-x^1" },
        new object[] { "-1x^1" },
        new object[] { "-0x" },
        new object[] { "-0x^3" },
        new object[] { "-x^10" },
        new object[] { "-1x^10" },
        new object[] { "-x^-2" },
        new object[] { "-1x^-2" }
    ];

    public static IEnumerable<object[]> ConstantTermCases =>
    [
        new object[] { "5" },
        new object[] { "-5" },
        new object[] { "+5" },
        new object[] { "0" },
        new object[] { "0.25" },
        new object[] { "-0.25" },
        new object[] { "100" },
        new object[] { "-100" },
        new object[] { "3.14159" },
        new object[] { "-2.71828" },
        new object[] { "42" },
        new object[] { "-999" }
    ];

    public static IEnumerable<object[]> InvalidTermCases =>
    [
        new object[] { "" },
        new object[] { "+" },
        new object[] { "-" },
        new object[] { "x^" },
        new object[] { "2x^" },
        new object[] { "x^^2" },
        new object[] { "2xx" },
        new object[] { "abc" },
        new object[] { "2x2" },
        new object[] { "x^2^3" },
        new object[] { "5y^2" }
    ];

    // ----------------------------
    // ParsePolynomial test data
    // ----------------------------

    public static IEnumerable<object[]> ValidPolynomialCases =>
    [
        new object[]
        {
            "2x^2 + 5x - 4",
            new Polynomial(new List<Term>
            {
                new Term(2, 2),
                new Term(5, 1),
                new Term(-4, 0)
            })
        },
        new object[]
        {
            "x^3 - 2x^2 + x - 1",
            new Polynomial(new List<Term>
            {
                new Term(1, 3),
                new Term(-2, 2),
                new Term(1, 1),
                new Term(-1, 0)
            })
        },
        new object[]
        {
            "-3x^2 + 7x",
            new Polynomial(new List<Term>
            {
                new Term(-3, 2),
                new Term(7, 1)
            })
        },
        new object[]
        {
            "x",
            new Polynomial(new List<Term>
            {
                new Term(1, 1)
            })
        },
        new object[]
        {
            "-x",
            new Polynomial(new List<Term>
            {
                new Term(-1, 1)
            })
        },
        new object[]
        {
            "5",
            new Polynomial(new List<Term>
            {
                new Term(5, 0)
            })
        },
        new object[]
        {
            "-8",
            new Polynomial(new List<Term>
            {
                new Term(-8, 0)
            })
        },
        new object[]
        {
            "x^5 + x^4 + x^3 + x^2 + x + 1",
            new Polynomial(new List<Term>
            {
                new Term(1, 5),
                new Term(1, 4),
                new Term(1, 3),
                new Term(1, 2),
                new Term(1, 1),
                new Term(1, 0)
            })
        },
        new object[]
        {
            "10x^2",
            new Polynomial(new List<Term>
            {
                new Term(10, 2)
            })
        },
        new object[]
        {
            "-x^3",
            new Polynomial(new List<Term>
            {
                new Term(-1, 3)
            })
        },
        new object[]
        {
            "0.5x^2 - 0.25x + 1.5",
            new Polynomial(new List<Term>
            {
                new Term(0.5, 2),
                new Term(-0.25, 1),
                new Term(1.5, 0)
            })
        },
        new object[]
        {
            "100x^4 - 50x^2 + 25",
            new Polynomial(new List<Term>
            {
                new Term(100, 4),
                new Term(-50, 2),
                new Term(25, 0)
            })
        },
        new object[]
        {
            "-2x - 3",
            new Polynomial(new List<Term>
            {
                new Term(-2, 1),
                new Term(-3, 0)
            })
        },
        new object[]
        {
            "x^2 + x^2",
            new Polynomial(new List<Term>
            {
                new Term(2, 2)
            })
        },
        new object[]
        {
            "3x + 2x - 5x",
            new Polynomial(new List<Term>())
        },
        new object[]
        {
            "x^-1",
            new Polynomial(new List<Term>
            {
                new Term(1, -1)
            })
        },
        new object[]
        {
            "-x^-2",
            new Polynomial(new List<Term>
            {
                new Term(-1, -2)
            })
        },
        new object[]
        {
            "3x^-4 + 2",
            new Polynomial(new List<Term>
            {
                new Term(3, -4),
                new Term(2, 0)
            })
        },
        new object[]
        {
            "5x^2 - x^-3",
            new Polynomial(new List<Term>
            {
                new Term(5, 2),
                new Term(-1, -3)
            })
        },
        new object[]
        {
            "-2x^-10 + 7x",
            new Polynomial(new List<Term>
            {
                new Term(-2, -10),
                new Term(7, 1)
            })
        }
    ];

    public static IEnumerable<object[]> NegativeExponentPolynomialCases =>
    [
        new object[] { "x^-1" },
        new object[] { "-x^-2" },
        new object[] { "3x^-4 + 2" },
        new object[] { "5x^2 - x^-3" },
        new object[] { "-2x^-10 + 7x" }
    ];

    public static IEnumerable<object[]> MalformedPolynomialCases =>
    [
        new object[] { "2x^" },
        new object[] { "x^^2" },
        new object[] { "2x2" },
        new object[] { "5y^2" },
        new object[] { "++3x" },
        new object[] { "--3x" },
        new object[] { "x^2^3" },
        new object[] { "2x^-" },
        new object[] { "-" },
        new object[] { "+" }
    ];

    public static IEnumerable<object[]> DecimalPolynomialCases =>
    [
        new object[] { "0.5x^2 - 0.25x + 1.5" },
        new object[] { "-1.25x^3 + 2.5x - 0.75" },
        new object[] { "10.0x^4 - 5.5x^2 + 0.125" },
        new object[] { "-0.1x + 0.2" },
        new object[] { "3.1415x^2 - 2.718x + 1.414" }
    ];

    public static IEnumerable<object[]> LargeExponentPolynomialCases =>
    [
        new object[] { "x^10" },
        new object[] { "2x^25 + 1" },
        new object[] { "-x^100" },
        new object[] { "5x^999 - 3" },
        new object[] { "1x^1000 + 2x" }
    ];
}