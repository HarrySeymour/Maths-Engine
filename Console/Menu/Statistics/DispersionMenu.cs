using Console.Utils;
using Core.Modules.Statistics.Dispersion;
using Core.Utils.Exceptions;

namespace Console.Menu.Statistics;

public static class DispersionMenu
{
    public static void Menu()
    {
        while (true)
        {
            System.Console.Clear();
            System.Console.WriteLine("Welcome to the Dispersion Menu");
            System.Console.WriteLine("1. Calculate from an array of numbers");
            System.Console.WriteLine("2. Calculate from a frequency table");
            System.Console.WriteLine("3. Calculate from a continuous table");
            System.Console.WriteLine("4. Back");
            int response = Parsing.GetMenuInput("Input: ", 4);

            switch (response)
            {
                case 1:
                    HandleArrayOfNumbers();
                    break;
                case 2:
                    HandleFrequencyTable();
                    break;
                case 3:
                    HandleContinuousTable();
                    break;
                case 4:
                    return;
            }
        }
    }

    private static void HandleArrayOfNumbers()
    {
        try
        {
            var values = GetDoubleList("Enter the values separated by commas: ");
            var calculator = new ArrayOfNumbersCalculator(values);
            calculator.Run();

            System.Console.WriteLine("\n--- Results ---");
            System.Console.WriteLine($"Original values: {string.Join(", ", calculator.OriginalValues)}");
            System.Console.WriteLine($"Sorted values: {string.Join(", ", calculator.SortedValues)}");
            System.Console.WriteLine($"Mean: {calculator.Mean:F3}");
            System.Console.WriteLine($"Median: {calculator.Median:F3}");
            System.Console.WriteLine($"Mode: {string.Join(", ", calculator.Mode)}");
            System.Console.WriteLine($"Range: {calculator.Range:F3}");
            System.Console.WriteLine($"Q1: {calculator.Q1:F3}");
            System.Console.WriteLine($"Q3: {calculator.Q3:F3}");
            System.Console.WriteLine($"IQR: {calculator.Iqr:F3}");
            System.Console.WriteLine($"Variance: {calculator.Variance:F3}");
            System.Console.WriteLine($"Standard Deviation: {calculator.StandardDeviation:F3}");
        }
        catch (FormatException)
        {
            ErrorDisplay.ShowError("Invalid input. Please enter only numbers separated by commas.");
        }
        catch (NullInputException)
        {
            ErrorDisplay.ShowError("Please provide at least one value.");
        }
        catch (EmptyDataSetException)
        {
            ErrorDisplay.ShowError("The data set cannot be empty.");
        }
        finally
        {
            WaitForContinue();
        }
    }

    private static void HandleFrequencyTable()
    {
        try
        {
            var values = GetDoubleList("Enter the values separated by commas: ");
            var frequencies = GetIntList("Enter the frequencies for each value, separated by commas: ");

            var calculator = new FrequencyTableCalculator(values, frequencies);
            calculator.Run();

            System.Console.WriteLine("\n--- Results ---");
            calculator.DisplayData();
        }
        catch (FormatException)
        {
            ErrorDisplay.ShowError("Invalid input. Please ensure the lists contain only numbers separated by commas.");
        }
        catch (NullInputException)
        {
            ErrorDisplay.ShowError("Both values and frequencies must be provided.");
        }
        catch (EmptyDataSetException)
        {
            ErrorDisplay.ShowError("The data sets cannot be empty.");
        }
        catch (ListsNotSameSizeException)
        {
            ErrorDisplay.ShowError("The number of values must match the number of frequencies.");
        }
        catch (InvalidFrequencyException)
        {
            ErrorDisplay.ShowError("Frequencies cannot be negative.");
        }
        finally
        {
            WaitForContinue();
        }
    }

    private static void HandleContinuousTable()
    {
        try
        {
            var intervals = GetStringList("Enter the class intervals (e.g. 10-20) separated by commas: ");
            var frequencies = GetIntList("Enter the frequencies for each interval, separated by commas: ");

            var calculator = new ContinuousTableCalculator(intervals, frequencies);
            calculator.Run();

            System.Console.WriteLine("\n--- Results ---");
            calculator.DisplayData();
        }
        catch (FormatException)
        {
            ErrorDisplay.ShowError("Invalid input. Please ensure the lists contain only numbers separated by commas.");
        }
        catch (NullInputException)
        {
            ErrorDisplay.ShowError("Both class intervals and frequencies must be provided.");
        }
        catch (EmptyDataSetException)
        {
            ErrorDisplay.ShowError("The data sets cannot be empty.");
        }
        catch (ListsNotSameSizeException)
        {
            ErrorDisplay.ShowError("The number of class intervals must match the number of frequencies.");
        }
        catch (InvalidFrequencyException)
        {
            ErrorDisplay.ShowError("Frequencies cannot be negative.");
        }
        catch (InvalidClassIntervalFormatException)
        {
            ErrorDisplay.ShowError("Invalid class interval format. Please use 'lower-upper' (for example, 10-20).");
        }
        finally
        {
            WaitForContinue();
        }
    }

    private static void WaitForContinue()
    {
        System.Console.WriteLine("\nPress any key to return to the menu...");
        System.Console.ReadKey(true);
    }

    private static List<double> GetDoubleList(string prompt)
    {
        System.Console.WriteLine(prompt);
        string? input = System.Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
            throw new NullInputException();

        return input.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(double.Parse)
                    .ToList();
    }

    private static List<int> GetIntList(string prompt)
    {
        System.Console.WriteLine(prompt);
        string? input = System.Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
            throw new NullInputException();

        return input.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(int.Parse)
                    .ToList();
    }

    private static List<string> GetStringList(string prompt)
    {
        System.Console.WriteLine(prompt);
        string? input = System.Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
            throw new NullInputException();

        return input.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .ToList();
    }
}
