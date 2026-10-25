using Core.Explanations.Models.Results;
using Core.Measurement.Units.Geometry.Area;
using Core.Measurement.Units.Geometry.Volume;

namespace Core.Geometry.Abstractions;

public abstract class Shape3D : Shape
{
    public abstract CalculationResult<Volume> CalculateVolume();

    public abstract CalculationResult<Area> CalculateSurfaceArea();
}