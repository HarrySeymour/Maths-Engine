using Core.Explanations.Models.Abstractions;

namespace Core.Measurement.Units.Mechanics.Acceleration;

public class Acceleration : IMathematicalValue, IMeasurement, IEquatable<Acceleration>, IComparable<Acceleration> 
{
    public double Value { get; }
    public AccelerationUnit Unit { get; }

    public Acceleration(double value, AccelerationUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    public double InMetersPerSecondSquared => Value * Unit.ScaleFactor;

    public Acceleration ConvertTo(AccelerationUnit targetUnit)
    {
        double newValue = UnitConverter.Convert(Value, Unit, targetUnit);
        return new Acceleration(newValue, targetUnit);
    }

    public static Acceleration operator +(Acceleration left, Acceleration right)
    {
        double rightValueInLeftUnit = right.InMetersPerSecondSquared / left.Unit.ScaleFactor;
        return new Acceleration(left.Value + rightValueInLeftUnit, left.Unit);
    }

    public static Acceleration operator -(Acceleration left, Acceleration right)
    {
        double rightValueInLeftUnit = right.InMetersPerSecondSquared / left.Unit.ScaleFactor;
        return new Acceleration(left.Value - rightValueInLeftUnit, left.Unit);
    }

    public static Acceleration operator *(Acceleration acceleration, double scalar)
        => new Acceleration(acceleration.Value * scalar, acceleration.Unit);

    public static Acceleration operator *(double scalar, Acceleration acceleration)
        => acceleration * scalar;

    public static Acceleration operator /(Acceleration acceleration, double scalar)
        => new Acceleration(acceleration.Value / scalar, acceleration.Unit);

    public static bool operator ==(Acceleration? left, Acceleration? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return left.InMetersPerSecondSquared == right.InMetersPerSecondSquared;
    }

    public static bool operator !=(Acceleration? left, Acceleration? right) => !(left == right);

    public static bool operator <(Acceleration left, Acceleration right) => left.InMetersPerSecondSquared < right.InMetersPerSecondSquared;
    public static bool operator >(Acceleration left, Acceleration right) => left.InMetersPerSecondSquared > right.InMetersPerSecondSquared;
    public static bool operator <=(Acceleration left, Acceleration right) => left.InMetersPerSecondSquared <= right.InMetersPerSecondSquared;
    public static bool operator >=(Acceleration left, Acceleration right) => left.InMetersPerSecondSquared >= right.InMetersPerSecondSquared;

    public bool Equals(Acceleration? other)
    {
        if (other is null) return false;
        return InMetersPerSecondSquared.Equals(other.InMetersPerSecondSquared);
    }

    public override bool Equals(object? obj) => obj is Acceleration other && Equals(other);

    public override int GetHashCode() => InMetersPerSecondSquared.GetHashCode();

    public int CompareTo(Acceleration? other)
    {
        if (other is null) return 1;
        return InMetersPerSecondSquared.CompareTo(other.InMetersPerSecondSquared);
    }

    public override string ToString() => $"{Value} {Unit.Symbol}";
}