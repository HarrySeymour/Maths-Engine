namespace Core.Modules.Pure.Algebra.Core;

public static class PolynomialParser
{
    public static List<Term> ParsePolynomial(string expression)
    {
        if (expression == null) throw new ArgumentNullException();

        expression = expression.Replace(" ", "");
        
        if (expression.Length == 0) return new List<Term>();
        
        if (expression[0] != '+' && expression[0] != '-')
            expression = "+" + expression;

        List<Term> terms = new List<Term>();
        int start = 0;

        for (int i = 1; i < expression.Length; i++)
        {
            if (expression[i] == '+' || expression[i] == '-')
            {
                string chunk = expression.Substring(start, i - start);
                terms.Add(ParseTerm(chunk));
                start = i;
            }
        }
        
        string lastChunk = expression.Substring(start);
        terms.Add(ParseTerm(lastChunk));
        
        return terms;
    }
    
    public static Term ParseTerm(string term)
    {
        int sign = term[0] == '-' ? -1 : 1;
        string body = term.Substring(1);

        if (body.Contains("x"))
        {
            string[] parts = body.Split('x');
            string coeffPart = parts[0];
            string powerPart = parts.Length > 1 ? parts[1] : "";

            double coeff = 0;
            
            if (string.IsNullOrEmpty(coeffPart))
                coeff = 1;
            else 
                coeff = double.Parse(coeffPart);
            
            coeff *= sign;

            int power = 0;
            if (string.IsNullOrEmpty(powerPart))
                power = 1;
            else if (powerPart.StartsWith("^"))
                power = int.Parse(powerPart.Substring(1));
            else
                power = 1;
            
            return new Term(coeff, power);
        }
        else
        {
            double coeff = double.Parse(body) * sign;
            return new Term(coeff, 0);
        }
    }
}