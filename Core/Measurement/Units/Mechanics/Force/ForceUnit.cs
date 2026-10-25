namespace Core.Measurement.Units.Mechanics.Force;

public readonly struct ForceUnit : IUnit
{
    public string Symbol { get; }
    public double ScaleFactor { get; }

    public ForceUnit(string symbol, double scaleFactor)
    {
        Symbol = symbol;
        ScaleFactor = scaleFactor;
    }

    public static readonly ForceUnit Newton = new ForceUnit("N", 1.0);
}