using Core.Modules.Pure.Algebra.Core;

namespace Core.Modules.Pure.Algebra.Expansion;

public static class ExpansionParser
{
    public static Polynomial Parse(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression)) throw new ArgumentNullException(nameof(expression));

        expression = expression.Trim();

        int currentDepth = 0;
        int startIndex = 0;
        List<string> factors = new List<string>();

        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {
                if (currentDepth == 0)
                {
                    if (i > startIndex)
                    {
                        string leadingText = expression.Substring(startIndex, i - startIndex).Trim();
                        if (leadingText == "-")
                        {
                            factors.Add("-1");
                        }
                        else if (!string.IsNullOrWhiteSpace(leadingText))
                        {

                            factors.Add(leadingText);
                        }
                    }

                    startIndex = i + 1;
                }

                currentDepth++;
            }
            else if (expression[i] == ')')
            {
                currentDepth--;
                
                if (currentDepth == 0)
                {
                    string bracketContent = expression.Substring(startIndex, i - startIndex).Trim();

                    if (!string.IsNullOrWhiteSpace(bracketContent))
                    {
                        factors.Add(bracketContent);
                    }

                    startIndex = i + 1;
                }
            }
        }

        if (startIndex < expression.Length)
        {
            string trailingText = expression.Substring(startIndex).Trim();
            if (!string.IsNullOrWhiteSpace(trailingText))
            {
                factors.Add(trailingText);
            }
        }

        List<Polynomial> polynomialFactors = new List<Polynomial>();

        foreach(string factor in factors)
        {
            polynomialFactors.Add(new Polynomial(factor));
        }

        if (polynomialFactors.Count == 0)
            return new Polynomial("0");

        Polynomial result = polynomialFactors[0];

        for (int i = 1; i < polynomialFactors.Count; i++)
        {
            result *= polynomialFactors[i];
        }

        return result;
    }
}