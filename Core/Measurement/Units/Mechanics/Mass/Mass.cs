using Core.Explanations.Models.Abstractions;

namespace Core.Measurement.Units.Mechanics.Mass;

public class Mass : IMathematicalValue, IMeasurement, IEquatable<Mass>, IComparable<Mass>
{
    public double Value { get; }
    public MassUnit Unit { get; }

    public Mass(double value, MassUnit unit)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(nameof(value), "Mass value must be greater than zero.");

        Value = value;
        Unit = unit;
    }

    public double InKilograms => Value * Unit.ScaleFactor;

    public Mass ConvertTo(MassUnit targetUnit)
    {
        double newValue = UnitConverter.Convert(Value, Unit, targetUnit);
        return new Mass(newValue, targetUnit);
    }

    public static Mass operator +(Mass left, Mass right)
    {
        double rightValueInLeftUnit = right.InKilograms / left.Unit.ScaleFactor;
        return new Mass(left.Value + rightValueInLeftUnit, left.Unit);
    }

    public static Mass operator -(Mass left, Mass right)
    {
        double rightValueInLeftUnit = right.InKilograms / left.Unit.ScaleFactor;
        return new Mass(left.Value - rightValueInLeftUnit, left.Unit);
    }

    public static Mass operator *(Mass mass, double scalar) => new Mass(mass.Value * scalar, mass.Unit);
    public static Mass operator *(double scalar, Mass mass) => mass * scalar;
    public static Mass operator /(Mass mass, double scalar) => new Mass(mass.Value / scalar, mass.Unit);

    public static bool operator ==(Mass? left, Mass? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return left.InKilograms == right.InKilograms;
    }

    public static bool operator !=(Mass? left, Mass? right) => !(left == right);

    public static bool operator <(Mass left, Mass right) => left.InKilograms < right.InKilograms;
    public static bool operator >(Mass left, Mass right) => left.InKilograms > right.InKilograms;
    public static bool operator <=(Mass left, Mass right) => left.InKilograms <= right.InKilograms;
    public static bool operator >=(Mass left, Mass right) => left.InKilograms >= right.InKilograms;

    public bool Equals(Mass? other)
    {
        if (other is null) return false;
        return InKilograms.Equals(other.InKilograms);
    }

    public override bool Equals(object? obj) => obj is Mass other && Equals(other);

    public override int GetHashCode() => InKilograms.GetHashCode();

    public int CompareTo(Mass? other)
    {
        if (other is null) return 1;
        return InKilograms.CompareTo(other.InKilograms);
    }

    public override string ToString() => $"{Value} {Unit.Symbol}";
}