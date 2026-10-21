using MathsEngine.Core.Explanations.Models.Abstractions;
using MathsEngine.Core.Explanations.Models.Enums;

namespace MathsEngine.Core.Explanations.Models.Results;

public class CalculationResult<T>
{
    public CalculationType CalculationType { get; set; }
    public T Value { get; set; }
    public string Unit { get; set; }
    public int? DisplayedPrecision { get; set; }
    public IEnumerable<ICalculationItem> CalculationFlow { get; set; }
    public string? Summary {get; set; }

    public CalculationResult() { }
    public CalculationResult (CalculationType type, T value, string unit, IEnumerable<ICalculationItem> calculationFlow, string summary, int displayedPrecision = 2)
    {
        CalculationType =  type;
        Value = value;
        Unit = unit;
        DisplayedPrecision = displayedPrecision;
        CalculationFlow = calculationFlow;
        Summary = summary;
    }
}