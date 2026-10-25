using Core.Modules.Statistics.BivariateAnalysis;
using Console.Utils;
using Core.Utils.Exceptions;

namespace Console.Menu.Statistics;

public static class BivariateAnalysisMenu
{
    public static void Menu()
    {
        try
        {
            System.Console.Clear();
            System.Console.WriteLine("Bivariate Analysis - Spearman's Rank");
            var scores1 = GetScores("Enter the first set of scores, separated by commas:");
            var scores2 = GetScores("Enter the second set of scores, separated by commas:");

            var calculator = new BivariateAnalysisCalculator(scores1, scores2);
            calculator.Run();

            DisplayResults(calculator);

            System.Console.WriteLine("\nPress any key to return to the menu...");
            System.Console.ReadKey();
        }
        catch (FormatException)
        {
            ErrorDisplay.ShowError("Error: Invalid input. Please ensure you enter only numbers separated by commas.");
            System.Console.ReadKey();
        }
        catch (NullInputException)
        {
            ErrorDisplay.ShowError("Error: One or both of the score sets were empty. Please provide data.");
            System.Console.ReadKey();
        }
        catch (ListsNotSameSizeException)
        {
            ErrorDisplay.ShowError("Error: The two sets of scores must contain the same number of values.");
            System.Console.ReadKey();
        }
        catch (InsufficientDataException)
        {
            ErrorDisplay.ShowError("Error: At least two pairs of scores are required to perform the analysis.");
            System.Console.ReadKey();
        }
    }

    private static List<double> GetScores(string prompt)
    {
        System.Console.WriteLine(prompt);
        string? input = System.Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
            throw new NullInputException();

        return input.Split(',')
                    .Select(s => double.Parse(s.Trim()))
                    .ToList();
    }

    private static void DisplayResults(BivariateAnalysisCalculator calc)
    {
        System.Console.WriteLine("\n--- Results ---");
        System.Console.WriteLine($"Rank 1: {string.Join(", ", calc.Ranks1)}");
        System.Console.WriteLine($"Rank 2: {string.Join(", ", calc.Ranks2)}");
        System.Console.WriteLine($"Difference: {string.Join(", ", calc.Difference)}");
        System.Console.WriteLine($"Difference Squared: {string.Join(", ", calc.DifferenceSquared)}");
        System.Console.WriteLine($"Sum of Difference Squared: {calc.SumDifferenceSquared:F2}");
        System.Console.WriteLine($"\nSpearman's Rank Correlation Coefficient is: {calc.CorrelationCoefficient:F3}");
        System.Console.WriteLine($"Correlation: {calc.CorrelationString}");
    }
}