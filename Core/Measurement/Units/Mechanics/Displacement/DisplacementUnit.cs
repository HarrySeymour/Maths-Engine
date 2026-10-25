namespace Core.Measurement.Units.Mechanics.Displacement;

public readonly struct DisplacementUnit : IUnit
{
    public string Symbol { get; }
    public double ScaleFactor { get; }

    public DisplacementUnit(string symbol, double scaleFactor)
    {
        Symbol = symbol;
        ScaleFactor = scaleFactor;
    }

    public static readonly DisplacementUnit Millimeter = new("mm", 0.001);
    public static readonly DisplacementUnit Centimeter = new("cm", 0.01);
    public static readonly DisplacementUnit Meter = new("m", 1.0);
    public static readonly DisplacementUnit Kilometer = new("km", 1000.0);
}