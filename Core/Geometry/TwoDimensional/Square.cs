using Core.Explanations.Models.Abstractions;
using Core.Explanations.Models.Components;
using Core.Explanations.Models.Enums;
using Core.Explanations.Models.Results;
using Core.Measurement.Units.Geometry.Area;
using Core.Measurement.Units.Geometry.Length;

namespace Core.Geometry.TwoDimensional;

public class Square : Rectangle
{
    public override string Name => "Square";
    public override string DisplayName => "Square";
    public override string Description => "A square is a two-dimensional shape with four equal sides and four right angles. " +
                                          "It is a special case of a rectangle where all sides are of equal length.";

    public Length SideLength => Length;

    public Square(Length sideLength) : base(sideLength, sideLength)
    {
    }

    public override CalculationResult<Area> CalculateArea()
    {
        Area area = new Area(SideLength.InMetres * SideLength.InMetres, AreaUnit.SquareMeter);

        List<ICalculationItem> flow = new List<ICalculationItem>
        {
            new CalculationInput("Side Length", SideLength, SideLength.Unit.ToString(), "s"),
            new CalculationStep("Formula", formula: "Area = SideLength²"),
            new CalculationStep("Unit Standardisation", note: $"Side Length = {SideLength.InMetres} m"),
            new CalculationStep("Substitution", substitution: $"Area = {SideLength.InMetres} m × {SideLength.InMetres} m"),
            new CalculationStep("Calculation", result: $"Area = {area.Value} {area.Unit}")
        };

        return new CalculationResult<Area>(
            CalculationType.Area,
            area,
            area.Unit.ToString(),
            flow,
            $"The area of the square is {area.Value} {area.Unit}."
        );
    }

    public override CalculationResult<Length> CalculatePerimeter()
    {
        Length perimeter = SideLength * 4;

        List<ICalculationItem> flow = new List<ICalculationItem>
        {
            new CalculationInput("Side Length", SideLength, SideLength.Unit.ToString(), "s"),
            new CalculationStep("Formula", formula: "Perimeter = 4 × SideLength"),
            new CalculationStep("Substitution", substitution: $"Perimeter = 4 × {SideLength.Value} {SideLength.Unit}"),
            new CalculationStep("Calculation", result: $"Perimeter = {perimeter.Value} {perimeter.Unit}")
        };

        return new CalculationResult<Length>(
            CalculationType.Perimeter,
            perimeter,
            perimeter.Unit.ToString(),
            flow,
            $"The perimeter of the square is {perimeter.Value} {perimeter.Unit}."
        );
    }

    public override bool Validate()
    {
        return SideLength != null && SideLength.Value > 0;
    }
}