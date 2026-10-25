using Core.Explanations.Models.Abstractions;
using Core.Measurement.Units.Geometry.Area;
using Core.Measurement.Units.Geometry.Length;
using AreaMeasurement = Core.Measurement.Units.Geometry.Area.Area;
using LengthMeasurement = Core.Measurement.Units.Geometry.Length.Length;

namespace Core.Measurement.Units.Geometry.Volume;

public class Volume : IMathematicalValue, IMeasurement, IEquatable<Volume>, IComparable<Volume>
{
    public double Value { get; }
    public VolumeUnit Unit { get; }

    public Volume(double value, VolumeUnit unit)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(nameof(value), "Volume value must be greater than zero.");
        
        Value = value;
        Unit = unit;
    }

    public double InCubicMetres => Value * Unit.ScaleFactor;

    public Volume ConvertTo(VolumeUnit targetUnit)
    {
        double newValue = UnitConverter.Convert(Value, Unit, targetUnit);
        return new Volume(newValue, targetUnit);
    }

    public static Volume operator +(Volume left, Volume right)
    {
        double rightValueInLeftUnit = right.InCubicMetres / left.Unit.ScaleFactor;
        return new Volume(left.Value + rightValueInLeftUnit, left.Unit);
    }

    public static Volume operator -(Volume left, Volume right)
    {
        double rightValueInLeftUnit = right.InCubicMetres / left.Unit.ScaleFactor;
        return new Volume(left.Value - rightValueInLeftUnit, left.Unit);
    }

    public static AreaMeasurement operator /(Volume volume, LengthMeasurement length)
    {
        double squareMetres = volume.InCubicMetres / length.InMetres;
        return new AreaMeasurement(squareMetres, AreaUnit.SquareMeter);
    }
    public static LengthMeasurement operator /(Volume volume, AreaMeasurement area)
    {
        double metres = volume.InCubicMetres / area.InSquareMetres;
        return new LengthMeasurement(metres, LengthUnit.Meter);
    }
    public static Volume operator *(Volume volume, double scalar) => new Volume(volume.Value * scalar, volume.Unit);
    public static Volume operator *(double scalar, Volume volume) => volume * scalar;
    public static Volume operator /(Volume volume, double scalar) => new Volume(volume.Value / scalar, volume.Unit);

    public static bool operator ==(Volume? left, Volume? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return left.InCubicMetres == right.InCubicMetres;
    }

    public static bool operator !=(Volume? left, Volume? right) => !(left == right);

    public static bool operator <(Volume left, Volume right) => left.InCubicMetres < right.InCubicMetres;
    public static bool operator >(Volume left, Volume right) => left.InCubicMetres > right.InCubicMetres;
    public static bool operator <=(Volume left, Volume right) => left.InCubicMetres <= right.InCubicMetres;
    public static bool operator >=(Volume left, Volume right) => left.InCubicMetres >= right.InCubicMetres;

    public bool Equals(Volume? other)
    {
        if (other is null) return false;
        return InCubicMetres.Equals(other.InCubicMetres);
    }

    public override bool Equals(object? obj) => obj is Volume other && Equals(other);

    public override int GetHashCode() => InCubicMetres.GetHashCode();

    public int CompareTo(Volume? other)
    {
        if (other is null) return 1;
        return InCubicMetres.CompareTo(other.InCubicMetres);
    }

    public override string ToString() => $"{Value} {Unit.Symbol}";
}