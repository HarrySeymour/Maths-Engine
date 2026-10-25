using Core.Explanations.Models.Abstractions;
using Core.Measurement.Units.Geometry.Length;
using Core.Measurement.Units.Geometry.Volume;
using LengthMeasurement = Core.Measurement.Units.Geometry.Length.Length;
using VolumeMeasurement = Core.Measurement.Units.Geometry.Volume.Volume;

namespace Core.Measurement.Units.Geometry.Area;

public class Area : IMathematicalValue, IMeasurement, IEquatable<Area>, IComparable<Area>
{
    public double Value { get; }
    public AreaUnit Unit { get; }

    public Area(double value, AreaUnit unit)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(nameof(value), "Area value must be greater than zero.");
        
        Value = value;
        Unit = unit;
    }

    public double InSquareMetres => Value * Unit.ScaleFactor;

    public Area ConvertTo(AreaUnit targetUnit)
    {
        double newValue = UnitConverter.Convert(Value, Unit, targetUnit);
        return new Area(newValue, targetUnit);
    }

    public static Area operator +(Area left, Area Right)
    {
        double rightValueInLeftUnit = Right.InSquareMetres / left.Unit.ScaleFactor;
        return new Area(left.Value + rightValueInLeftUnit, left.Unit);
    }

    public static Area operator -(Area left, Area Right)
    {
        double rightValueInLeftUnit = Right.InSquareMetres / left.Unit.ScaleFactor;
        return new Area(left.Value - rightValueInLeftUnit, left.Unit);
    }

    public static VolumeMeasurement operator *(Area area, LengthMeasurement length)
    {
        double cubicMetres = area.InSquareMetres * length.InMetres;
        return new VolumeMeasurement(cubicMetres, VolumeUnit.CubicMetres);
    }
    public static VolumeMeasurement operator *(LengthMeasurement length, Area area) => area * length;
    public static LengthMeasurement operator /(Area area, LengthMeasurement length)
    {
        double metres = area.InSquareMetres / length.InMetres;
        return new LengthMeasurement(metres, LengthUnit.Meter);
    }
    public static Area operator *(Area area, double scalar) => new Area(area.Value * scalar, area.Unit);
    public static Area operator *(double scalar, Area area) => area * scalar;
    public static Area operator /(Area area, double scalar) => new Area(area.Value / scalar, area.Unit);

    public static bool operator ==(Area? left, Area? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return left.InSquareMetres == right.InSquareMetres;
    }

    public static bool operator !=(Area? left, Area? right) => !(left == right);

    public static bool operator <(Area left, Area right) => left.InSquareMetres < right.InSquareMetres;
    public static bool operator >(Area left, Area right) => left.InSquareMetres > right.InSquareMetres;
    public static bool operator <=(Area left, Area right) => left.InSquareMetres <= right.InSquareMetres;
    public static bool operator >=(Area left, Area right) => left.InSquareMetres >= right.InSquareMetres;

    public bool Equals(Area? other)
    {
        if (other is null) return false;
        return InSquareMetres.Equals(other.InSquareMetres);
    }

    public override bool Equals(object? obj) => obj is Area other && Equals(other);

    public override int GetHashCode() => InSquareMetres.GetHashCode();

    public int CompareTo(Area? other)
    {
        if (other is null) return 1;
        return InSquareMetres.CompareTo(other.InSquareMetres);
    }

    public override string ToString() => $"{Value} {Unit.Symbol}";
}