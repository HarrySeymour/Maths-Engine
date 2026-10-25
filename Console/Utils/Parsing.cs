using Core.Modules.Pure.CoordinateGeometry;
using Core.Modules.Pure.Trigonometry;

namespace Console.Utils;

public static class Parsing
{
    public static double? GetNullableDoubleInput(string prompt)
    {
        System.Console.Write(prompt);
        string? input = System.Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(input))
            return null;

        if (double.TryParse(input, out double value))
            return value;

        throw new ArgumentException("Invalid number entered.");
    }

    public static double GetDoubleInput(string prompt)
    {
        while (true)
        {
            System.Console.Write(prompt);
            string? input = System.Console.ReadLine()?.Trim();

            if (!string.IsNullOrEmpty(input) && double.TryParse(input, out double value))
                return value;

            System.Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    public static int GetIntInput(string prompt)
    {
        while (true)
        {
            System.Console.Write(prompt);
            string? input = System.Console.ReadLine()?.Trim();

            if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int value))
                return value;

            System.Console.WriteLine("Invalid input. Please enter a valid number");
        }
    }

    public static int GetMenuInput(string prompt, int maxNum)
    {
        while (true)
        {
            System.Console.Write(prompt);
            var input = System.Console.ReadLine()?.Trim();

            if (int.TryParse(input, out int value))
                if (value <= maxNum && value > 0)
                    return value;

            System.Console.WriteLine("Invalid input. Try again.");
        }
    }

    public static SideType GetSideType(string prompt)
    {
        while (true)
        {
            System.Console.WriteLine(prompt);
            string? input = System.Console.ReadLine()?.Trim();

            if (input == "Hypotenuse" || input == "hypotenuse")
                return SideType.Hypotenuse;
            if (input == "Opposite" || input == "opposite")
                return SideType.Opposite;
            if (input == "Adjacent" || input == "adjacent")
                return SideType.Adjacent;
            System.Console.WriteLine("You have not entered a valid side. Try Again");
        }
    }

    /// <summary>
    /// Prompts the user to enter the X and Y values for a coordinate separately.
    /// </summary>
    /// <param name="prompt">The message to display to the user to give context for the coordinate.</param>
    /// <returns>A Coordinate object.</returns>
    public static Coordinate ParseCoordinate(string prompt)
    {
        System.Console.WriteLine(prompt);
        var x = GetDoubleInput("  Enter X value: ");
        var y = GetDoubleInput("  Enter Y value: ");
        return new Coordinate(x, y);
    }
}