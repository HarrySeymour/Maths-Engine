using Core.Explanations.Models.Abstractions;

namespace Core.Measurement.Units.Mechanics.Time;

public class Time : IMathematicalValue, IMeasurement, IEquatable<Time>, IComparable<Time>
{
    public double Value { get; }
    public TimeUnit Unit { get; }

    public Time(double value, TimeUnit unit)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value), "Time duration cannot be negative.");

        Value = value;
        Unit = unit;
    }

    public double InSeconds => Value * Unit.ScaleFactor;

    public Time ConvertTo(TimeUnit targetUnit)
    {
        double newValue = UnitConverter.Convert(Value, Unit, targetUnit);
        return new Time(newValue, targetUnit);
    }

    public static Time operator +(Time left, Time right)
    {
        double rightValueInLeftUnit = right.InSeconds / left.Unit.ScaleFactor;
        return new Time(left.Value + rightValueInLeftUnit, left.Unit);
    }

    public static Time operator -(Time left, Time right)
    {
        double rightValueInLeftUnit = right.InSeconds / left.Unit.ScaleFactor;
        double resultValue = left.Value - rightValueInLeftUnit;

        if (resultValue < 0)
            throw new InvalidOperationException("Resulting time duration cannot be negative.");

        return new Time(resultValue, left.Unit);
    }

    public static Time operator *(Time time, double scalar)
        => new Time(time.Value * scalar, time.Unit);

    public static Time operator *(double scalar, Time time)
        => time * scalar;

    public static Time operator /(Time time, double scalar)
        => new Time(time.Value / scalar, time.Unit);

    public static double operator /(Time left, Time right)
        => left.InSeconds / right.InSeconds;

    public static bool operator ==(Time? left, Time? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return left.InSeconds == right.InSeconds;
    }

    public static bool operator !=(Time? left, Time? right) => !(left == right);

    public static bool operator <(Time left, Time right) => left.InSeconds < right.InSeconds;
    public static bool operator >(Time left, Time right) => left.InSeconds > right.InSeconds;
    public static bool operator <=(Time left, Time right) => left.InSeconds <= right.InSeconds;
    public static bool operator >=(Time left, Time right) => left.InSeconds >= right.InSeconds;

    public bool Equals(Time? other)
    {
        if (other is null) return false;
        return InSeconds.Equals(other.InSeconds);
    }

    public override bool Equals(object? obj) => obj is Time other && Equals(other);

    public override int GetHashCode() => InSeconds.GetHashCode();

    public int CompareTo(Time? other)
    {
        if (other is null) return 1;
        return InSeconds.CompareTo(other.InSeconds);
    }

    public override string ToString() => $"{Value} {Unit.Symbol}";
}