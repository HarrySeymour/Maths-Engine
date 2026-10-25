namespace MathsEngine.Core.Modules.Pure.Algebra.Core;

public sealed class Term(double coefficient, int power)
{
    public double Coefficient { get; set; } = coefficient;
    public int Power { get; set; } = power;
    public int Degree() => Power;

    public static bool IsLikeTerm(Term term1, Term term2)
    {
        if (term1 is null || term2 is null) return false;
        return term1.Power == term2.Power;
    }
    public bool IsLikeTerm(Term other)
    {
        if (other is null) throw new ArgumentNullException(nameof(other));
        return Power == other.Power;
    }
    public bool IsValidVariable(string variable) => variable.Length == 1;
    public bool IsEqualTerm(Term other)
    {
        if (Coefficient == other.Coefficient && Power == other.Power) 
            return true;
        return false;
    }
    
    public static Term operator + (Term term1, Term term2)
    {
        if (term1 is null || term2 is null) throw new ArgumentNullException();
        if (!IsLikeTerm(term1, term2))
            throw new InvalidOperationException("Cannot add unlike terms.");

        return new Term(term1.Coefficient + term2.Coefficient, term1.Power);
    }
    public static Term operator - (Term term1, Term term2)
    {
        if (term1 is null || term2 is null) throw new ArgumentNullException();
        if (!IsLikeTerm(term1, term2))
            throw new InvalidOperationException("Cannot subtract unlike terms.");

        return new Term(term1.Coefficient - term2.Coefficient, term1.Power);
    }
    public static Term operator * (Term term1, Term term2)
    {
        if (term1 is null || term2 is null) throw new ArgumentNullException();

        return new Term(
            term1.Coefficient * term2.Coefficient,
            term1.Power + term2.Power
        );
    }
    public static Term operator * (Term term, int constant) => new Term(term.Coefficient * constant, term.Power);
    public static Term operator / (Term term1, Term term2)
    {
        if (term1 is null || term2 is null) throw new ArgumentNullException();
        if (term2.Coefficient == 0)
            throw new DivideByZeroException("Cannot divide by a term with a zero coefficient.");

        return new Term(term1.Coefficient / term2.Coefficient, term1.Power - term2.Power);
    }

    public double Evaluate(double variable)
    {
        if (variable == 0 && Power < 0)
            throw new DivideByZeroException("Cannot evaluate negative powers at x = 0.");

        return Coefficient * Math.Pow(variable, Power);
    }

    public static string FormatTermForDisplay(Term term, bool isFirst)
    {
        double coeff = Math.Abs(term.Coefficient);

        if (coeff == 0) return "";

        string coeffPart = "";
        if (term.Power == 0)
            coeffPart = coeff.ToString();
        else if (coeff != 1)
            coeffPart = coeff.ToString();

        string powerPart = "";
        if (term.Power == 0)
            powerPart = "";
        else if (term.Power == 1)
            powerPart = "x";
        else
            powerPart = $"x^{term.Power}";

        return $"{coeffPart}{powerPart}";
    }
    public override string ToString()
    {
        if (Coefficient == 0) return "0";

        // Constant
        if (Power == 0)
            return Coefficient.ToString();

        string coeffPart;

        if (Coefficient == 1)
            coeffPart = "";
        else if (Coefficient == -1)
            coeffPart = "-";
        else
            coeffPart = Coefficient.ToString();

        string powerPart;

        if (Power == 1)
            powerPart = $"x";
        else
            powerPart = $"x^{Power}";

        return $"{coeffPart}{powerPart}";
    }
}