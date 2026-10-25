using Core.Modules.Pure.Algebra.Core;

namespace Core.Modules.Pure.Algebra.Expansion;

public static class ExpansionCalculator
{
    /// <summary>
    /// Expands a raw algebraic string expression, e.g. "3x(2x + 1)" or "(x + 1)(x - 2)(x + 3)".
    /// </summary>
    public static Polynomial Expand(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression)) throw new ArgumentNullException(nameof(expression));

        return ExpansionParser.Parse(expression);
    }

    /// <summary>
    /// Expands two polynomial objects by multiplying them together.
    /// </summary>
    public static Polynomial Expand(Polynomial left, Polynomial right)
    {
        if (left is null) throw new ArgumentNullException(nameof(left));
        if (right is null) throw new ArgumentNullException(nameof(right));
        
        return left * right;
    }

    /// <summary>
    /// Expands a list of polynomial factors by multiplying them sequentially.
    /// </summary>
    public static Polynomial Expand(IEnumerable<Polynomial> factors)
    {
        if (factors is null) throw new ArgumentNullException(nameof(factors));

        Polynomial result = null;

        foreach (var factor in factors)
        {
            if (factor is null) continue;

            if (result is null)
            {
                result = factor;
            }
            else
            {
                result *= factor;
            }
        }

        return result ?? new Polynomial("0");
    }
}