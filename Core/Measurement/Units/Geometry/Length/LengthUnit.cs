namespace Core.Measurement.Units.Geometry.Length;

public readonly struct LengthUnit : IUnit
{
    public string Symbol { get; }
    public double ScaleFactor { get; }

    public LengthUnit(string symbol, double scaleFactor)
    {
        Symbol = symbol;
        ScaleFactor = scaleFactor;
    }

    public static readonly LengthUnit Millimeter = new LengthUnit("mm", 0.001);
    public static readonly LengthUnit Centimeter = new LengthUnit("cm", 0.01);
    public static readonly LengthUnit Meter = new LengthUnit("m", 1.0);
    public static readonly LengthUnit Kilometer = new LengthUnit("km", 1000.0);
}