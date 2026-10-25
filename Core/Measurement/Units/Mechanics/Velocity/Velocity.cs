using Core.Explanations.Models.Abstractions;

namespace Core.Measurement.Units.Mechanics.Velocity;

public class Velocity : IMathematicalValue, IMeasurement, IEquatable<Velocity>, IComparable<Velocity>
{
    public double Value { get; }
    public VelocityUnit Unit { get; }

    public Velocity(double value, VelocityUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    public double InMetersPerSecond => Value * Unit.ScaleFactor;
    
    public Velocity ConvertTo(VelocityUnit targetUnit)
    {
        double newValue = UnitConverter.Convert(Value, Unit, targetUnit);
        return new Velocity(newValue, targetUnit);
    }

    public static Velocity operator +(Velocity left, Velocity right)
    {
        double rightValueInLeftUnit = right.InMetersPerSecond / left.Unit.ScaleFactor;
        return new Velocity(left.Value + rightValueInLeftUnit, left.Unit);
    }

    public static Velocity operator -(Velocity left, Velocity right)
    {
        double rightValueInLeftUnit = right.InMetersPerSecond / left.Unit.ScaleFactor;
        return new Velocity(left.Value - rightValueInLeftUnit, left.Unit);
    }

    public static Velocity operator *(double scalar, Velocity velocity) => new Velocity(velocity.Value * scalar, velocity.Unit);
    public static Velocity operator *(Velocity velocity, double scalar) => new Velocity(velocity.Value * scalar, velocity.Unit);
    public static Velocity operator /(Velocity velocity, double scalar) => new Velocity(velocity.Value / scalar, velocity.Unit);

    public static bool operator ==(Velocity? left, Velocity? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return left.InMetersPerSecond == right.InMetersPerSecond;
    }

    public static bool operator !=(Velocity? left, Velocity? right) => !(left == right);

    public static bool operator <(Velocity left, Velocity right)
    {
        return left.InMetersPerSecond < right.InMetersPerSecond;
    }

    public static bool operator >(Velocity left, Velocity right)
    {
        return left.InMetersPerSecond > right.InMetersPerSecond;
    }

    public static bool operator <=(Velocity left, Velocity right)
    {
        return left.InMetersPerSecond <= right.InMetersPerSecond;
    }

    public static bool operator >=(Velocity left, Velocity right)
    {
        return left.InMetersPerSecond >= right.InMetersPerSecond;
    }   

    public bool Equals(Velocity? other)
    {
        if (other is null) return false;
        return InMetersPerSecond == other.InMetersPerSecond;
    }

    public override bool Equals(object? obj) => obj is Velocity other && Equals(other);

    public override int GetHashCode() => InMetersPerSecond.GetHashCode();

    public int CompareTo(Velocity? other)
    {
        if (other is null) return 1;
        return InMetersPerSecond.CompareTo(other.InMetersPerSecond);
    }

    public override string ToString() => $"{Value} {Unit.Symbol}";
}