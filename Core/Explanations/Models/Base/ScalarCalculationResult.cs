namespace Core.Explanations.Models.Base;

public class ScalarCalculationResult : BaseCalculationResult
{
    public double Value { get; }

    public ScalarCalculationResult(double value, List<string> steps) : base(steps)
    {
        Value = value;
    }
}