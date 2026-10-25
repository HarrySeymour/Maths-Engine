namespace Core.Measurement.Units.Mechanics.Acceleration;

public readonly struct AccelerationUnit : IUnit
{
    public string Symbol { get; }
    public double ScaleFactor { get; }

    public AccelerationUnit(string symbol, double scaleFactor)
    {
        Symbol = symbol;
        ScaleFactor = scaleFactor;
    }

    public static readonly AccelerationUnit MetersPerSecondSquared = new AccelerationUnit("m/s²", 1.0);
    public static readonly AccelerationUnit CentimetersPerSecondSquared = new AccelerationUnit("cm/s²", 0.01);
    public static readonly AccelerationUnit StandardGravity = new AccelerationUnit("g", 10); // Give option to change
}