using Core.Explanations.Models.Abstractions;
using Core.Measurement.Units.Geometry.Area;
using AreaMeasurement = Core.Measurement.Units.Geometry.Area.Area;

namespace Core.Measurement.Units.Geometry.Length;

public class Length : IMathematicalValue, IMeasurement, IEquatable<Length>, IComparable<Length>
{
    public double Value { get; }
    public LengthUnit Unit { get; }

    public Length(double value, LengthUnit unit)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(nameof(value), "Length value must be greater than zero.");
        
        Value = value;
        Unit = unit;
    }

    public double InMetres => Value * Unit.ScaleFactor;

    public Length ConvertTo(LengthUnit targetUnit)
    {
        double newValue = UnitConverter.Convert(Value, Unit, targetUnit);
        return new Length(newValue, targetUnit);
    }

    public static Length operator +(Length left, Length right)
    {
        double rightValueInLeftUnit = right.InMetres / left.Unit.ScaleFactor;
        return new Length(left.Value + rightValueInLeftUnit, left.Unit);
    }

    public static Length operator -(Length left, Length right)
    {
        double rightValueInLeftUnit = right.InMetres / left.Unit.ScaleFactor;
        return new Length(left.Value - rightValueInLeftUnit, left.Unit);
    }

    public static AreaMeasurement operator *(Length left, Length right)
    {
        double squareMetres = left.InMetres * right.InMetres;
        return new AreaMeasurement(squareMetres, AreaUnit.SquareMeter);
    }
    public static Length operator *(Length length, double scalar) => new Length(length.Value * scalar, length.Unit);
    public static Length operator *(double scalar, Length length) => length * scalar;
    public static Length operator /(Length length, double scalar) => new Length(length.Value / scalar, length.Unit);

    public static bool operator ==(Length? left, Length? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return left.InMetres == right.InMetres;
    }

    public static bool operator !=(Length? left, Length? right) => !(left == right);

    public static bool operator <(Length left, Length right) => left.InMetres < right.InMetres;
    public static bool operator >(Length left, Length right) => left.InMetres > right.InMetres;
    public static bool operator <=(Length left, Length right) => left.InMetres <= right.InMetres;
    public static bool operator >=(Length left, Length right) => left.InMetres >= right.InMetres;

    public bool Equals(Length? other)
    {
        if (other is null) return false;
        return InMetres.Equals(other.InMetres);
    }

    public override bool Equals(object? obj) => obj is Length other && Equals(other);

    public override int GetHashCode() => InMetres.GetHashCode();

    public int CompareTo(Length? other)
    {
        if (other is null) return 1;
        return InMetres.CompareTo(other.InMetres);
    }

    public override string ToString() => $"{Value} {Unit.Symbol}";
}