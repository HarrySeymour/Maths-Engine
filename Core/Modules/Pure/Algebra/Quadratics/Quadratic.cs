using Core.Modules.Pure.Algebra.Core;

namespace Core.Modules.Pure.Algebra.Quadratics;

public class Quadratic : Polynomial
{
    public Quadratic(IEnumerable<Term> terms) : base(terms)
    {
        if (Degree > 2)
            throw new ArgumentException("A quadratic polynomial cannot have a degree higher than 2.");
    }
    public Quadratic(string expression) : base(expression)
    {
        if (Degree > 2)
            throw new ArgumentException("A quadratic polynomial cannot have a degree higher than 2.");
    }

    public QuadraticResult Solve()
    {
        return QuadraticSolver.Solve(this);
    }
}