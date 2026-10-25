using Core.Modules.Pure.CoordinateGeometry;

namespace Core.Explanations.Models.Base;

public class CoordinateCalculationResult : BaseCalculationResult
{
    public Coordinate CoordinateValue { get; }

    public CoordinateCalculationResult(Coordinate coordinate, List<string> steps) : base(steps)
    {
        CoordinateValue = coordinate;
    }
}