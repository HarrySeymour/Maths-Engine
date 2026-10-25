using Core.Explanations.Models.Abstractions;
using Core.Measurement.Units.Geometry.Length;

namespace Core.Measurement.Units.Mechanics.Displacement;

public class Displacement : IMathematicalValue, IMeasurement, IEquatable<Displacement>, IComparable<Displacement>
{
    public double Value { get; }
    public DisplacementUnit Unit { get; }

    public Displacement(double value, DisplacementUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    public double InMetres => Value * Unit.ScaleFactor;

    public Displacement ConvertTo(DisplacementUnit targetUnit)
    {
        double newValue = UnitConverter.Convert(Value,
            new LengthUnit(Unit.Symbol, Unit.ScaleFactor),
            new LengthUnit(targetUnit.Symbol, targetUnit.ScaleFactor));

        return new Displacement(newValue, targetUnit);
    }

    public static Displacement operator +(Displacement left, Displacement right)
        => new(left.Value + (right.InMetres / left.Unit.ScaleFactor), left.Unit);

    public static Displacement operator -(Displacement left, Displacement right)
        => new(left.Value - (right.InMetres / left.Unit.ScaleFactor), left.Unit);

    public static Displacement operator *(Displacement displacement, double scalar)
        => new(displacement.Value * scalar, displacement.Unit);

    public static Displacement operator *(double scalar, Displacement displacement)
        => displacement * scalar;

    public static Displacement operator /(Displacement displacement, double scalar)
        => new(displacement.Value / scalar, displacement.Unit);

    public static bool operator ==(Displacement? left, Displacement? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return left.InMetres == right.InMetres;
    }

    public static bool operator !=(Displacement? left, Displacement? right) => !(left == right);

    public static bool operator <(Displacement left, Displacement right) => left.InMetres < right.InMetres;
    public static bool operator >(Displacement left, Displacement right) => left.InMetres > right.InMetres;
    public static bool operator <=(Displacement left, Displacement right) => left.InMetres <= right.InMetres;
    public static bool operator >=(Displacement left, Displacement right) => left.InMetres >= right.InMetres;

    public bool Equals(Displacement? other)
        => other is not null && InMetres.Equals(other.InMetres);

    public override bool Equals(object? obj) => obj is Displacement other && Equals(other);

    public override int GetHashCode() => InMetres.GetHashCode();

    public int CompareTo(Displacement? other) => other is null ? 1 : InMetres.CompareTo(other.InMetres);

    public override string ToString() => $"{Value} {Unit.Symbol}";
}