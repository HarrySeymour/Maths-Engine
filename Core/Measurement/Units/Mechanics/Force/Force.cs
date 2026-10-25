using Core.Explanations.Models.Abstractions;

namespace Core.Measurement.Units.Mechanics.Force;

public class Force : IMathematicalValue, IMeasurement, IEquatable<Force>, IComparable<Force>
{
    public double Value { get; }
    public ForceUnit Unit { get; }

    public Force(double value, ForceUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    public double InNewtons => Value * Unit.ScaleFactor;

    public Force ConvertTo(ForceUnit targetUnit)
    {
        double newValue = UnitConverter.Convert(Value, Unit, targetUnit);
        return new Force(newValue, targetUnit);
    }

    public static Force operator +(Force left, Force right)
    {
        double rightValueInLeftUnit = right.InNewtons / left.Unit.ScaleFactor;
        return new Force(left.Value + rightValueInLeftUnit, left.Unit);
    }

    public static Force operator -(Force left, Force right)
    {
        double rightValueInLeftUnit = right.InNewtons / left.Unit.ScaleFactor;
        return new Force(left.Value - rightValueInLeftUnit, left.Unit);
    }

    public static Force operator *(Force force, double scalar) => new Force(force.Value * scalar, force.Unit);
    public static Force operator *(double scalar, Force force) => force * scalar;
    public static Force operator /(Force force, double scalar) => new Force(force.Value / scalar, force.Unit);

    public static bool operator ==(Force? left, Force? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return left.InNewtons == right.InNewtons;
    }

    public static bool operator !=(Force? left, Force? right) => !(left == right);

    public static bool operator <(Force left, Force right) => left.InNewtons < right.InNewtons;
    public static bool operator >(Force left, Force right) => left.InNewtons > right.InNewtons;
    public static bool operator <=(Force left, Force right) => left.InNewtons <= right.InNewtons;
    public static bool operator >=(Force left, Force right) => left.InNewtons >= right.InNewtons;

    public bool Equals(Force? other)
    {
        if (other is null) return false;
        return InNewtons.Equals(other.InNewtons);
    }

    public override bool Equals(object? obj) => obj is Force other && Equals(other);

    public override int GetHashCode() => InNewtons.GetHashCode();

    public int CompareTo(Force? other)
    {
        if (other is null) return 1;
        return InNewtons.CompareTo(other.InNewtons);
    }

    public override string ToString() => $"{Value} {Unit.Symbol}";
}