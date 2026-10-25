using Core.Explanations.Models.Abstractions;
using Core.Explanations.Models.Components;
using Core.Explanations.Models.Enums;
using Core.Explanations.Models.Results;
using Core.Geometry.Abstractions;
using Core.Measurement.Units.Geometry.Area;
using Core.Measurement.Units.Geometry.Length;

namespace Core.Geometry.TwoDimensional;

public class Rectangle : Shape2D
{
    public override string Name => "Rectangle";
    public override string DisplayName => "Rectangle";
    public override string Description => "A rectangle is a two-dimensional shape with four sides and four right angles. " +
                                          "It has opposite sides that are equal in length, and its area can be calculated by multiplying its length by its width.";

    public Length Length { get; }
    public Length Width { get; }

    public Rectangle(Length length, Length width)
    {
        Length = length;
        Width = width;

        if (!Validate())
            throw new ArgumentException("Invalid dimensions for a rectangle. Length and Width must be positive values.");
    }

    public override CalculationResult<Area> CalculateArea()
    {
        Area area = new Area(Length.InMetres * Width.InMetres, AreaUnit.SquareMeter);

        List<ICalculationItem> flow = new List<ICalculationItem>
        {
            new CalculationInput("Length", Length, Length.Unit.ToString(), "l"),
            new CalculationInput("Width", Width, Width.Unit.ToString(), "w"),
            new CalculationStep("Formula", formula: "Area = Length × Width"),
            new CalculationStep("Unit Standardisation", note: $"Length = {Length.InMetres} m, Width = {Width.InMetres} m"),
            new CalculationStep("Substitution", substitution: $"Area = {Length.InMetres} m × {Width.InMetres} m"),
            new CalculationStep("Calculation", result: $"Area = {area.Value} {area.Unit}")
        };

        return new CalculationResult<Area>(
            CalculationType.Area,
            area,
            area.Unit.ToString(),
            flow,
            $"The area of the rectangle is {area.Value} {area.Unit}."
        );
    }

    public override CalculationResult<Length> CalculatePerimeter()
    {
        Length perimeter = (Length + Width) * 2;

        List<ICalculationItem> flow = new List<ICalculationItem>
        {
            new CalculationInput("Length", Length, Length.Unit.ToString(), "l"),
            new CalculationInput("Width", Width, Width.Unit.ToString(), "w"),
            new CalculationStep("Formula", formula: "Perimeter = 2 × (Length + Width)"),
            new CalculationStep("Substitution", substitution: $"Perimeter = 2 × ({Length.Value} {Length.Unit} + {Width.Value} {Width.Unit})"),
            new CalculationStep("Calculation", result: $"Perimeter = {perimeter.Value} {perimeter.Unit}")
        };

        return new CalculationResult<Length>(
            CalculationType.Perimeter,
            perimeter,
            perimeter.Unit.ToString(),
            flow,
            $"The perimeter of the rectangle is {perimeter.Value} {perimeter.Unit}."
        );
    }

    public override bool Validate()
    {
        return Length != null && Width != null && Length.Value > 0 && Width.Value > 0;
    }
}