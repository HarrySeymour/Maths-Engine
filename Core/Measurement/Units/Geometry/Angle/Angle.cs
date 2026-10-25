using Core.Explanations.Models.Abstractions;

namespace Core.Measurement.Units.Geometry.Angle;

public class Angle : IMathematicalValue, IMeasurement, IEquatable<Angle>, IComparable<Angle>
{
    public double Value { get; }
    public AngleUnit Unit { get; }
    

    public Angle(double value, AngleUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    public double InRadians => Value * Unit.ScaleFactor;
    public double InDegrees => InRadians * (180.0 / Math.PI);

    public Angle ConvertTo(AngleUnit targetUnit)
    {
        double newValue = UnitConverter.Convert(Value, Unit, targetUnit);
        return new Angle(newValue, targetUnit);
    }

    // Static Helpers
    public static Angle FromRadians(double radians) => new Angle(radians, AngleUnit.Radian);
    public static Angle FromDegrees(double degrees) => new Angle(degrees, AngleUnit.Degree);

    // Normalize angle to range [0, 2π) or [0, 360°)
    public Angle Normalize()
    {
        double twoPi = 2.0 * Math.PI;
        double rad = InRadians % twoPi;
        if (rad < 0) rad += twoPi;

        double newValue = rad / Unit.ScaleFactor;
        return new Angle(newValue, Unit);
    }

    // Arithmetic Operators
    public static Angle operator +(Angle left, Angle right)
    {
        double rightValueInLeftUnit = right.InRadians / left.Unit.ScaleFactor;
        return new Angle(left.Value + rightValueInLeftUnit, left.Unit);
    }

    public static Angle operator -(Angle left, Angle right)
    {
        double rightValueInLeftUnit = right.InRadians / left.Unit.ScaleFactor;
        return new Angle(left.Value - rightValueInLeftUnit, left.Unit);
    }

    public static Angle operator *(Angle angle, double scalar) => new Angle(angle.Value * scalar, angle.Unit);
    public static Angle operator *(double scalar, Angle angle) => angle * scalar;
    public static Angle operator /(Angle angle, double scalar) => new Angle(angle.Value / scalar, angle.Unit);
    public static double operator /(Angle left, Angle right) => left.InRadians / right.InRadians;

    // Relational & Comparison Operators
    public static bool operator ==(Angle? left, Angle? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return left.InRadians == right.InRadians;
    }

    public static bool operator !=(Angle? left, Angle? right) => !(left == right);

    public static bool operator <(Angle left, Angle right) => left.InRadians < right.InRadians;
    public static bool operator >(Angle left, Angle right) => left.InRadians > right.InRadians;
    public static bool operator <=(Angle left, Angle right) => left.InRadians <= right.InRadians;
    public static bool operator >=(Angle left, Angle right) => left.InRadians >= right.InRadians;

    public bool Equals(Angle? other)
    {
        if (other is null) return false;
        return InRadians.Equals(other.InRadians);
    }

    public override bool Equals(object? obj) => obj is Angle other && Equals(other);

    public override int GetHashCode() => InRadians.GetHashCode();

    public int CompareTo(Angle? other)
    {
        if (other is null) return 1;
        return InRadians.CompareTo(other.InRadians);
    }

    public override string ToString() => $"{Value} {Unit.Symbol}";
}