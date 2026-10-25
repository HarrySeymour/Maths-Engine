using Core.Explanations.Models.Results;
using Core.Measurement.Units.Geometry.Area;
using Core.Measurement.Units.Geometry.Length;

namespace Core.Geometry.Abstractions;

public abstract class Shape2D : Shape
{
    public abstract CalculationResult<Area> CalculateArea();

    public abstract CalculationResult<Length> CalculatePerimeter();
}