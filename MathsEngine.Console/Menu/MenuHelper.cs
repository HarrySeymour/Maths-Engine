using MathsEngine.Console.Utils;

namespace MathsEngine.Console.Menu;

public static class MenuHelper
{
    public static void RunMenu(string title, List<(string Label, Action Action)> options)
    {
        while (true)
        {
            System.Console.Clear();
            System.Console.WriteLine(title);

            for (int i = 0; i < options.Count; i++)
            {
                System.Console.WriteLine($"{i + 1}. {options[i].Label}");
            }
            
            int exitOption = options.Count + 1;
            System.Console.WriteLine($"{exitOption}. Back / Exit Program");

            int response = Parsing.GetMenuInput("Input: ", exitOption);

            if (response == exitOption) 
            {
                return;
            }

            options[response - 1].Action();
        }
    }
}