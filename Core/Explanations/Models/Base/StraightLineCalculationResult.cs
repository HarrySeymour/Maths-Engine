using Core.Modules.Pure.CoordinateGeometry;

namespace Core.Explanations.Models.Base;

public class StraightLineCalculationResult : BaseCalculationResult
{
    public StraightLine StraightLineValue { get; }

    public StraightLineCalculationResult(StraightLine straightLine, List<string> steps) : base(steps)
    {
        StraightLineValue = straightLine;
    }
}