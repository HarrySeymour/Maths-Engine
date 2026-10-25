using Console.Utils;
using Core.Explanations.Pure.Trigonometry;
using Core.Modules.Pure.Trigonometry;
using Core.Utils.Exceptions;

namespace Console.Menu.Pure;

public static class TrigonometryMenu
{
    public static void Menu()
    {
        while (true)
        {
            System.Console.Clear();
            System.Console.WriteLine("1. Calculate a missing side");
            System.Console.WriteLine("2. Calculate a missing angle");
            System.Console.WriteLine("3. Check valid triangle");
            System.Console.WriteLine("4. Back");
            int response = Parsing.GetMenuInput("Input: ", 4);

            switch (response)
            {
                case 1:
                    HandleMissingSide();
                    break;
                case 2:
                    HandleMissingAngle();
                    break;
                case 3:
                    HandleCheckValidTriangle();
                    break;
                case 4: return;
            }
        }
    }

    private static void HandleMissingSide()
    {
        System.Console.Clear();
        System.Console.WriteLine("Calculating a missing Side");

        double? angle = Parsing.GetNullableDoubleInput("Enter the angle you know in degrees: ");

        SideType sideKnown =
            Parsing.GetSideType("Which side do you know? (Opposite, Adjacent, Hypotenuse): ");

        double? knownSideLength = Parsing.GetNullableDoubleInput("Enter the length of the known side: ");

        SideType sideToFindType;

        switch (sideKnown)
        {
            case SideType.Opposite:
                sideToFindType = Parsing.GetSideType("Which side do you want to find? (Adjacent, Hypotenuse): ");
                break;
            case SideType.Adjacent:
                sideToFindType = Parsing.GetSideType("Which side do you want to find? (Opposite, Hypotenuse): ");
                break;
            case SideType.Hypotenuse:
                sideToFindType = Parsing.GetSideType("Which side do you want to find? (Adjacent, Opposite): ");
                break;
            default:
                Menu();
                return;
        }

        try
        {
            double result = TrigonometryCalculator.CalculateMissingSide(knownSideLength, angle, sideKnown, sideToFindType);

            System.Console.WriteLine($"\nResult: {sideToFindType} = {result:F2}");
        }
        catch (DuplicateSideException)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(
                $"\nError: You cannot find the side you already know. Please choose a different side to find.");
            System.Console.ResetColor();
        }
        catch (AcuteAngleException)
        {
            ErrorDisplay.ShowError("The angle in a right-angled triangle must be greater than 0 and less than 90 degrees.");
        }
        catch (NegativeSideLengthException)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine($"\nError: The length of a side cannot be negative or zero.");
            System.Console.ResetColor();
        }
        catch (NullInputException)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine($"\nError: You must provide a value for all inputs.");
            System.Console.ResetColor();
        }
        catch (Exception e)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine($"\nAn unexpected error occurred: {e.Message}");
            System.Console.ResetColor();
        }
        finally
        {
            System.Console.WriteLine("\nPress any key to return to the menu...");
            System.Console.ReadKey(true);
        }
    }

    private static void HandleMissingAngle()
    {
        System.Console.Clear();
        System.Console.WriteLine("Calculating a missing Angle\n");

        SideType side1Type = Parsing.GetSideType("Enter the first side you know (Opposite, Adjacent, Hypotenuse): ");
        double? side1Length = Parsing.GetNullableDoubleInput("Enter the length of the first side: ");

        SideType side2Type = Parsing.GetSideType("Enter the second side you know (Opposite, Adjacent, Hypotenuse): ");
        double? side2Length = Parsing.GetNullableDoubleInput("Enter the length of the second side: ");

        try
        {
            double result = TrigonometryCalculator.CalculateMissingAngle(side1Length, side1Type, side2Length, side2Type);

            System.Console.WriteLine($"\nResult: angle = {result:F2}°");
        }
        catch (DuplicateSideException)
        {
            ErrorDisplay.ShowError("Error: You cannot find the side you already know.Please choose a different side to find.");
        }
        catch (NegativeSideLengthException)
        {
            ErrorDisplay.ShowError("Error: The length of a side cannot be negative or zero.");
        }
        catch (NullInputException)
        {
            ErrorDisplay.ShowError("Error: You must provide a value for all inputs.");
        }
        catch (HypotenuseNotLongestSideException)
        {
            ErrorDisplay.ShowError("The hypotenuse must be the longest side");
        }
        catch (Exception ex)
        {
            ErrorDisplay.ShowError(ex.Message);
        }
        finally
        {
            System.Console.WriteLine("\nPress any key to return to the menu...");
            System.Console.ReadKey(true);
        }
    }

    private static void HandleCheckValidTriangle()
    {
        System.Console.Clear();
        System.Console.WriteLine("Checking for a valid triangle\n");

        double? hypotenuse = Parsing.GetNullableDoubleInput("Enter the value for the Hypotenuse: ");
        double? opposite = Parsing.GetNullableDoubleInput("Enter the value for the Opposite: ");
        double? adjacent = Parsing.GetNullableDoubleInput("Enter the value for the Adjacent: ");
        double? angle = Parsing.GetNullableDoubleInput("Enter the value for the Angle: ");

        try
        {
            var result = TrigonometryTutor.IsValidTriangleWithSteps(hypotenuse, opposite, adjacent, angle);

            System.Console.WriteLine("\n--- Validation Analysis Steps ---");
            System.Console.WriteLine(result.Steps);
        }
        catch (NullInputException)
        {
            ErrorDisplay.ShowError("Validation failed: You must provide a value for all inputs.");
        }
        catch (Exception ex)
        {
            ErrorDisplay.ShowError($"An unexpected error occurred during validation: {ex.Message}");
        }
        finally
        {
            System.Console.WriteLine("\nPress any key to return to the menu...");
            System.Console.ReadKey(true);
        }
    }
}