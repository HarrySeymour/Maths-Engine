namespace Console.Utils;

public static class ErrorDisplay
{
    public static void ShowError(string message)
    {
        System.Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine($"\nError: {message}");
        System.Console.ResetColor();
    }

    public static void ShowValidationError()
    {
        ShowError("Invalid input. Please enter valid numbers.");
    }
}