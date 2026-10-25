namespace Core.Measurement.Units.Mechanics.Mass;

public readonly struct MassUnit : IUnit
{
    public string Symbol { get; }
    public double ScaleFactor { get; }

    public MassUnit(string symbol, double scaleFactor)
    {
        Symbol = symbol;
        ScaleFactor = scaleFactor;
    }

    public static readonly MassUnit Milligram = new MassUnit("mg", 0.000001);
    public static readonly MassUnit Gram = new MassUnit("g", 0.001);
    public static readonly MassUnit Kilogram = new MassUnit("kg", 1.0);
    public static readonly MassUnit Tonne = new MassUnit("t", 1000.0);
}