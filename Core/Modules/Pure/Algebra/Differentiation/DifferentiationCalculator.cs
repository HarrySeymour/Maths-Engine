using Core.Modules.Pure.Algebra.Core;
using Core.Modules.Pure.CoordinateGeometry;

namespace Core.Modules.Pure.Algebra.Differentiation;

public static class DifferentiationCalculator
{
    public static Polynomial Differentiate(Polynomial polynomial)
    {
        var terms = polynomial.Terms;
        var differentiatedTerms = new List<Term>();

        foreach (Term term in terms)
        {
            differentiatedTerms.Add(new Term(term.Coefficient * term.Degree(), term.Degree() - 1));
        }
        
        return  new Polynomial(differentiatedTerms);
    }
    
    public static double DifferentiateAtPoint(Polynomial polynomial, double x)
    {
        var differentiatedTerms = Differentiate(polynomial).Terms;

        double sum = 0;
        foreach (Term term in differentiatedTerms)
            sum += term.Evaluate(x);
        
        return sum;
    }
    public static double DifferentiateAtPoint(Polynomial polynomial, Coordinate coordinate)
    {
        return DifferentiateAtPoint(polynomial, coordinate.X);
    }

    public static StraightLine GetTangentAtPoint(Polynomial polynomial, Coordinate coordinate)
    {
        return new StraightLine(0, DifferentiateAtPoint(polynomial, coordinate));
    }
    public static StraightLine GetNormalAtPoint(Polynomial polynomial, Coordinate coordinate)
    {
        return new StraightLine(0, DifferentiateAtPoint(polynomial, coordinate));
    }

    public static List<Coordinate> GetTurningPoints(Polynomial polynomial)
    {
        return null;
    }
}