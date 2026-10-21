using MathsEngine.Core.Modules.Mechanics.UniformAcceleration;
using MathsEngine.Console.Utils;
using MathsEngine.Core.Utils.Exceptions;

namespace MathsEngine.Console.Menu.Mechanics;
public static class UniformAccelerationMenu
{
    public static void Menu()
    {
        while (true)
        {
            System.Console.WriteLine("Welcome to the Uniform Acceleration Menu");
            System.Console.WriteLine("1. Horizontal Motion");
            System.Console.WriteLine("2. Back");
            int response = Parsing.GetMenuInput("Input: ", 2);

            switch (response)
            {
                case 1:
                    HorizontalMotionMenu();
                    break;
                case 2: return;
            }
        }
    }

    private static void HorizontalMotionMenu()
    {
        while (true)
        {
            System.Console.Clear();
            System.Console.WriteLine("1. Average Velocity");
            System.Console.WriteLine("2. UVATS equations");
            System.Console.WriteLine("3. Back");
            int response = Parsing.GetMenuInput("Input: ", 3);

            switch (response)
            {
                case 1:
                    HandleAverageVelocity();
                    break;
                case 2:
                    HandleUvats();
                    break;
                case 3:
                    return;
            }
        }
    }

    private static void HandleAverageVelocity()
    {
        try
        {
            double? initialVelocity = Parsing.GetNullableDoubleInput("Enter the initial velocity: ");
            double? finalVelocity = Parsing.GetNullableDoubleInput("Enter the final velocity: ");

            double averageVelocity = UniformAccelerationCalculator.CalculateAverageVelocity(initialVelocity, finalVelocity);
            System.Console.WriteLine($"\nAverage Velocity: {averageVelocity:F2}");
        }
        catch (Exception ex) when (ex is FormatException || ex is NullInputException)
        {
            ErrorDisplay.ShowError(ex.Message);
        }
        finally
        {
            WaitForContinue();
        }
    }

    private static void HandleUvats()
    {
        try
        {
            double? initialVelocity = Parsing.GetNullableDoubleInput("Enter the initial velocity (u): ");
            double? finalVelocity = Parsing.GetNullableDoubleInput("Enter the final velocity (v): ");
            double? acceleration = Parsing.GetNullableDoubleInput("Enter the acceleration (a): ");
            double? timeTaken = Parsing.GetNullableDoubleInput("Enter the time taken (t): ");
            double? displacement = Parsing.GetNullableDoubleInput("Enter the displacement (s): ");

            CheckCalculation(initialVelocity, finalVelocity, acceleration, timeTaken, displacement);
        }
        catch (Exception ex)
        {
            ErrorDisplay.ShowError(ex.Message);
        }
        finally
        {
            WaitForContinue();
        }
    }

    private static void CheckCalculation(double? u, double? v, double? a, double? t, double? s)
    {
        int missingCount =
            (u is null ? 1 : 0) +
            (v is null ? 1 : 0) +
            (a is null ? 1 : 0) +
            (t is null ? 1 : 0) +
            (s is null ? 1 : 0);

        if (missingCount > 2)
            throw new Exception("Too many unknown variables to calculate. Please provide at least 3 values.");

        if (missingCount == 0) return;

        for (int i = 0; i < 2; i++)
        {
            if (s is null && u.HasValue && v.HasValue && t.HasValue)
                s = UniformAccelerationCalculator.CalculateSUVT(null, u, v, t);
            if (s is null && u.HasValue && a.HasValue && t.HasValue)
                s = UniformAccelerationCalculator.CalculateSUTAT(null, u, a, t);
            if (s is null && v.HasValue && u.HasValue && a.HasValue)
                s = UniformAccelerationCalculator.CalculateVUAS(v, u, a, null);

            if (u is null && v.HasValue && a.HasValue && t.HasValue)
                u = UniformAccelerationCalculator.CalculateVUAT(v, null, a, t);
            if (u is null && v.HasValue && a.HasValue && s.HasValue)
                u = UniformAccelerationCalculator.CalculateVUAS(v, null, a, s);
            if (u is null && s.HasValue && v.HasValue && t.HasValue)
                u = UniformAccelerationCalculator.CalculateSUVT(s, null, v, t);
            if (u is null && s.HasValue && a.HasValue && t.HasValue)
                u = UniformAccelerationCalculator.CalculateSUTAT(s, null, a, t);

            if (v is null && u.HasValue && a.HasValue && t.HasValue)
                v = UniformAccelerationCalculator.CalculateVUAT(null, u, a, t);
            if (v is null && u.HasValue && a.HasValue && s.HasValue)
                v = UniformAccelerationCalculator.CalculateVUAS(null, u, a, s);
            if (v is null && s.HasValue && u.HasValue && t.HasValue)
                v = UniformAccelerationCalculator.CalculateSUVT(s, u, null, t);

            if (a is null && v.HasValue && u.HasValue && t.HasValue)
                a = UniformAccelerationCalculator.CalculateVUAT(v, u, null, t);
            if (a is null && v.HasValue && u.HasValue && s.HasValue)
                a = UniformAccelerationCalculator.CalculateVUAS(v, u, null, s);
            if (a is null && s.HasValue && u.HasValue && t.HasValue)
                a = UniformAccelerationCalculator.CalculateSUTAT(s, u, null, t);

            if (t is null && v.HasValue && u.HasValue && a.HasValue)
                t = UniformAccelerationCalculator.CalculateVUAT(v, u, a, null);
            if (t is null && s.HasValue && u.HasValue && v.HasValue)
                t = UniformAccelerationCalculator.CalculateSUVT(s, u, v, null);
            if (t is null && s.HasValue && u.HasValue && a.HasValue)
                t = UniformAccelerationCalculator.CalculateSUTAT(s, u, a, null);
        }

        System.Console.WriteLine($"Initial Velocity (U): {u}");
        System.Console.WriteLine($"Final Velocity (V): {v}");
        System.Console.WriteLine($"Acceleration (A): {a}");
        System.Console.WriteLine($"Time Taken (T): {t}");
        System.Console.WriteLine($"Displacement (S): {s}");
    }

    private static void WaitForContinue()
    {
        System.Console.WriteLine("\nPress any key to return to the menu...");
        System.Console.ReadKey(true);
    }
}