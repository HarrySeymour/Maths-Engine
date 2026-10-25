using Console.Utils;

namespace Console.Menu.Pure;

public static class AlgebraMenu
{
    public static void Menu()
    {
        while (true)
        {
            System.Console.Clear();

            switch (Parsing.GetMenuInput("Input: ", 0))
            {
                
            }

            System.Console.WriteLine("\nPress any key to continue...");
            System.Console.ReadKey(true);
        }
    }
}