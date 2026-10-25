namespace Core.Measurement.Units;

public static class UnitConverter
{
    public static double Convert<TUnit>(double value, TUnit fromUnit, TUnit toUnit) where TUnit : IUnit
    {
        if (fromUnit is null) throw new ArgumentNullException(nameof(fromUnit));
        if (toUnit is null) throw new ArgumentNullException(nameof(toUnit));

        // Convert the value to a base unit (e.g., meters for length, seconds for time)
        double baseValue = value * fromUnit.ScaleFactor;

        // Convert the base unit value to the target unit
        return baseValue / toUnit.ScaleFactor;
    }
}