namespace Core.Measurement.Units.Geometry.Volume;

public readonly struct VolumeUnit : IUnit
{
    public string Symbol { get; }
    public double ScaleFactor { get; }

    public VolumeUnit(string symbol, double scaleFactor)
    {
        Symbol = symbol;
        ScaleFactor = scaleFactor;
    }

    public static readonly VolumeUnit CubicMillimetres = new VolumeUnit("mm³", 1e-9);
    public static readonly VolumeUnit CubicCentimetres = new VolumeUnit("cm³", 1e-6);
    public static readonly VolumeUnit Litres = new VolumeUnit("L", 1e-3);
    public static readonly VolumeUnit CubicMetres = new VolumeUnit("m³", 1);
}