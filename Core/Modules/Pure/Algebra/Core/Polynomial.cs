using System.Text;

namespace Core.Modules.Pure.Algebra.Core;

public class Polynomial
{
    public List<Term> Terms { get; }
    public int Degree => Terms.Count > 0 ? Terms[0].Degree() : 0;
    public int TermCount => Terms.Count;

    public Polynomial(IEnumerable<Term> terms)
    {
        if (terms is null) throw new ArgumentNullException(nameof(terms));
        Terms = new List<Term>(terms);
        SimplifyAndSort();
    }
    public Polynomial(string expression)
    {
        if (expression is null) throw new ArgumentNullException(nameof(expression));
        Terms = PolynomialParser.ParsePolynomial(expression);
        SimplifyAndSort();
    }

    private void SimplifyAndSort()
    {
        // Combine like terms
        Dictionary<int, double> map = new Dictionary<int, double>();
        foreach (Term term in Terms)
        {
            if (map.ContainsKey(term.Degree()))
                map[term.Degree()] += term.Coefficient;
            else
                map[term.Degree()] = term.Coefficient;
        }

        Terms.Clear();
        foreach (var pair in map)
        {
            if (pair.Value != 0)
                Terms.Add(new Term(pair.Value, pair.Key));
        }

        // Sort terms in descending order by degree
        Terms.Sort((t1, t2) => t2.Degree().CompareTo(t1.Degree()));
    }
    public double Evaluate(double value)
    {
        double total = 0;
        foreach (Term term in Terms)
            total += term.Evaluate(value);
        return total;
    }
    
    public bool IsLikePolynomial(Polynomial other)
    {
        if (other is null) throw new ArgumentNullException(nameof(other));
        if (Terms.Count != other.Terms.Count) return false;

        for (int i = 0; i < TermCount; i++)
        {
            if (!Terms[i].IsLikeTerm(other.Terms[i]))
                return false;
        }
        return true;
    }
    public static bool IsLikePolynomial(Polynomial left, Polynomial right)
    {
        if (left is null || right is null) throw new ArgumentNullException();
        if (left.Terms.Count != right.Terms.Count) return false;
        
        for (int i = 0; i < left.TermCount; i++)
        {
            if (!left.Terms[i].IsLikeTerm(right.Terms[i]))
                return false;
        }
        return true;
    }
    
    public static Polynomial operator +(Polynomial a, Polynomial b)
    {
        if (a is null || b is null) throw new ArgumentNullException();

        List<Term> combined = new List<Term>(a.Terms);
        combined.AddRange(b.Terms);
        return new Polynomial(combined);
    }
    public static Polynomial operator -(Polynomial a, Polynomial b)
    {
        if (a is null || b is null) throw new ArgumentNullException();

        List<Term> modifiedB = new List<Term>();
        foreach (var term in b.Terms)
        {
            modifiedB.Add(new Term(-term.Coefficient, term.Degree()));
        }

        List<Term> combined = new List<Term>(a.Terms);
        combined.AddRange(modifiedB);
        return new Polynomial(combined);
    }
    public static Polynomial operator *(Polynomial a, Polynomial b)
    {
        if (a is null || b is null) throw new ArgumentNullException();

        List<Term> resultTerms = new List<Term>();
        foreach (var termA in a.Terms)
        {
            foreach (var termB in b.Terms)
            {
                resultTerms.Add(termA * termB);
            }
        }

        return new Polynomial(resultTerms);
    }
    public static Polynomial operator *(Polynomial polynomial, int constant)
    {
        if (polynomial is null) throw new ArgumentNullException(nameof(polynomial));

        List<Term> multipliedTerms = new List<Term>();
        foreach (var term in polynomial.Terms)
        {
            multipliedTerms.Add(term * constant);
        }

        return new Polynomial(multipliedTerms);
    }

    public override string ToString()
    {
        if (Terms.Count == 0) return "0";

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < Terms.Count; i++)
        {
            Term term = Terms[i];

            if (term.Coefficient == 0) continue;

            if (i > 0)
            {
                sb.Append(term.Coefficient > 0 ? " + " : " - ");
                sb.Append(Term.FormatTermForDisplay(new Term(Math.Abs(term.Coefficient), term.Degree()), false));
            }
            else
            {
                sb.Append(Term.FormatTermForDisplay(term, true));
            }
        }

        return sb.ToString();
    }
}