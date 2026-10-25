namespace Core.Measurement.Units.Mechanics.Time;

public readonly struct TimeUnit : IUnit
{
    public string Symbol { get; }
    public double ScaleFactor { get; }

    public TimeUnit(string symbol, double scaleFactor)
    {
        Symbol = symbol;
        ScaleFactor = scaleFactor;
    }

    public static readonly TimeUnit Millisecond = new TimeUnit("ms", 0.001);
    public static readonly TimeUnit Second = new TimeUnit("s", 1.0);
    public static readonly TimeUnit Minute = new TimeUnit("min", 60.0);
    public static readonly TimeUnit Hour = new TimeUnit("h", 3600.0);
    public static readonly TimeUnit Day = new TimeUnit("d", 86400.0);
}