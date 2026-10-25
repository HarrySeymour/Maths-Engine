using Core.Modules.Pure.Algebra.Core;

namespace Core.Modules.Pure.Algebra.Quadratics;

public static class QuadraticSolver
{
    public static QuadraticResult Solve(Quadratic quadratic)
    {
        if (quadratic is null) throw new ArgumentNullException(nameof(quadratic));

        double a = 0, b = 0, c = 0;

        foreach (Term term in quadratic.Terms)
        {
            if (term.Degree() == 2)
                a = term.Coefficient;
            else if (term.Degree() == 1)
                b = term.Coefficient;
            else if (term.Degree() == 0)
                c = term.Coefficient;

            double discriminant = (b * b) - (4 * a * c);

            if (discriminant > 0)
            {
                double sqrtDiscriminant = Math.Sqrt(discriminant);
                double root1 = (-b + sqrtDiscriminant) / (2 * a);
                double root2 = (-b - sqrtDiscriminant) / (2 * a);

                string exact = FormatSurd(a, b, discriminant, false);

                return new QuadraticResult(QuadraticRootType.TwoRealRoots, discriminant, root1, root2, exact);
            }
            else if (Math.Abs(discriminant) < 1e-10)
            {
                double root = -b / (2 * a);
                string exact = FormatSurd(a, b, 0, true);
                return new QuadraticResult(QuadraticRootType.OneRepeatedRoot, discriminant, root, root, exact);
            }
            else
            {
                return new QuadraticResult(QuadraticRootType.NoRealRoots, discriminant, null, null, "No real roots");
            }
        }
        
        return new QuadraticResult(QuadraticRootType.NoRealRoots, 0, null, null, "No real roots");
    }

private static string FormatSurd(double a, double b, double discriminant, bool isRepeated)
    {
        if (discriminant == 0) return $"x = {-b} / {2 * a}";
        
        return isRepeated ? $"x = ({-b} ± √{discriminant}) / {2 * a}" : $"x = ({-b} ± √{discriminant}) / {2 * a}";
    }
}