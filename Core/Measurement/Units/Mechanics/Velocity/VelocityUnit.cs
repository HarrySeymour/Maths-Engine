namespace Core.Measurement.Units.Mechanics.Velocity;

public readonly struct VelocityUnit : IUnit
{
    public string Symbol { get; }
    public double ScaleFactor { get; }

    private VelocityUnit(string symbol, double scaleFactor)
    {
        Symbol = symbol;
        ScaleFactor = scaleFactor;
    }

    public static readonly VelocityUnit CentiMetersPerSecond = new VelocityUnit("cm/s", 0.01);
    public static readonly VelocityUnit MetersPerSecond = new VelocityUnit("m/s", 1);
    public static readonly VelocityUnit KilometersPerHour = new VelocityUnit("km/h", 1.0 / 3.6);
    public static readonly VelocityUnit MilesPerHour = new VelocityUnit("mph", 0.44704);
}