using System.Text;
using Core.Explanations.Models.Abstractions;

namespace Core.Explanations.Models.Components;

public class CalculationStep : ICalculationItem
{
    private string Title { get; set; }
    private string? Formula { get; set; }
    private string? Substitution { get; set; }
    private string? Result { get; set; }
    private string? Note { get; set; }

    public CalculationStep(string title, string? formula = null, string? substitution = null, string? result = null, string? note = null)
    {
        Title = title;
        Formula = formula;
        Substitution = substitution;
        Result = result;
        Note = note;
    }

    public string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(Title);
        if (!string.IsNullOrEmpty(Formula))
        {
            stringBuilder.AppendLine(Formula);
        }
        if (!string.IsNullOrEmpty(Substitution))
        {
            stringBuilder.AppendLine(Substitution);
        }
        if (!string.IsNullOrEmpty(Result))
        {
            stringBuilder.AppendLine(Result);
        }
        if (!string.IsNullOrEmpty(Note))
        {
            stringBuilder.AppendLine(Note);
        }
        return stringBuilder.ToString();
    }
}