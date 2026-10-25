namespace Core.Measurement.Units.Geometry.Angle;

public readonly struct AngleUnit : IUnit
{
    public string Symbol { get; }
    public double ScaleFactor { get; } // Scale factor relative to Radians

    public AngleUnit(string symbol, double scaleFactor)
    {
        Symbol = symbol;
        ScaleFactor = scaleFactor;
    }

    public static readonly AngleUnit Radian = new AngleUnit("rad", 1.0);
    public static readonly AngleUnit Degree = new AngleUnit("°", Math.PI / 180.0);
    public static readonly AngleUnit Turn = new AngleUnit("tr", 2.0 * Math.PI);
}