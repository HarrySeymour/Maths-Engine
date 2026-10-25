using Core.Modules.Pure.PythagorasTheorem;
using Console.Utils;
using Core.Utils.Exceptions;

namespace Console.Menu.Pure;
internal static class PythagorasMenu
{
    public static void Menu()
    {
        while (true)
        {
            System.Console.Clear();
            System.Console.WriteLine("Pythagoras Theorem Calculator");
            System.Console.WriteLine("1. Find the hypotenuse");
            System.Console.WriteLine("2. Find another side");
            System.Console.WriteLine("3. Check if calculation is valid");
            System.Console.WriteLine("4. Back");
            int response = Parsing.GetMenuInput("Input: ", 4);

            switch (response)
            {
                case 1:
                    HandleFindHypotenuse();
                    break;
                case 2:
                    HandleFindOtherSide();
                    break;
                case 3:
                    HandleCheckTheorem();
                    break;
                case 4: return;
            }
        }
    }

    /// <summary>
    /// Methods that retrieve the side lengths and inputs them into the Pythagoras Theorem
    /// </summary>

    private static void HandleFindHypotenuse()
    {
        try
        {
            System.Console.Clear();
            double? sideA = Parsing.GetNullableDoubleInput("Enter side A: ");
            double? sideB = Parsing.GetNullableDoubleInput("Enter side B: ");

            double hypotenuse = PythagorasCalculator.CalculateHypotenuse(sideA, sideB);

            System.Console.WriteLine("\nHypotenuse: " + hypotenuse);

            System.Console.WriteLine("\nCalculation complete. Press any key to return to the menu...");
            System.Console.ReadKey();
        }
        catch (FormatException)
        {
            ErrorDisplay.ShowError("Error: Invalid input. Please enter valid numbers for the side lengths.");
        }
        catch (NullInputException)
        {
            ErrorDisplay.ShowError("Error: Invalid input. Please enter valid numbers for the side lengths.");
        }
        catch (NegativeSideLengthException)
        {
            ErrorDisplay.ShowError("Error: Cannot have negative sides.");
        }
        catch (Exception e)
        {
            ErrorDisplay.ShowError($"\nError: {e.Message}");
        }
    }

    private static void HandleFindOtherSide()
    {
        try
        {
            System.Console.Clear();
            double? hypotenuse = Parsing.GetNullableDoubleInput("Enter the hypotenuse: ");
            double? knownSide = Parsing.GetNullableDoubleInput("Enter the known side: ");

            double unknownSide =
                PythagorasCalculator.CalculateOtherSide(hypotenuse, knownSide);

            System.Console.WriteLine("\nUnknown side: " + unknownSide);

            System.Console.WriteLine("\nCalculation complete. Press any key to return to the menu...");
            System.Console.ReadKey();
        }
        catch (FormatException)
        {
            ErrorDisplay.ShowError("Error: Invalid input. Please enter valid numbers for the side lengths.");
        }
        catch (NullInputException)
        {
            ErrorDisplay.ShowError("Error: Invalid input. Please enter valid numbers for the side lengths.");
        }
        catch (Exception ex) when (ex is NegativeSideLengthException || ex is HypotenuseNotLongestSideException)
        {
            ErrorDisplay.ShowError(ex.Message);
        }
        catch (Exception e)
        {
            ErrorDisplay.ShowError($"\nError: {e.Message}");
        }
    }

    private static void HandleCheckTheorem()
    {
        try
        {
            System.Console.Clear();
            double? hypotenuse = Parsing.GetNullableDoubleInput("Enter the hypotenuse: ");
            double? firstSide = Parsing.GetNullableDoubleInput("Enter the first side: ");
            double? secondSide = Parsing.GetNullableDoubleInput("Enter the second side: ");

            bool validResult =
                PythagorasCalculator.CheckValidCalculation(hypotenuse, firstSide, secondSide);

            System.Console.WriteLine((validResult) ? "\nThis is a valid equation" : "\nThis is not a valid equation");

            System.Console.WriteLine("\nCalculation complete. Press any key to return to the menu...");
            System.Console.ReadKey();
        }
        catch (FormatException)
        {
            ErrorDisplay.ShowError("Error: Invalid input. Please enter valid numbers for the side lengths.");
        }
        catch (NullInputException)
        {
            ErrorDisplay.ShowError("Error: Invalid input. Please enter valid numbers for the side lengths.");
        }
        catch (Exception ex) when (ex is NegativeSideLengthException || ex is HypotenuseNotLongestSideException)
        {
            ErrorDisplay.ShowError(ex.Message);
        }
        catch (Exception e)
        {
            ErrorDisplay.ShowError($"\nError: {e.Message}");
        }
    }
}