using MathsEngine.Console.Menu.Statistics;
using MathsEngine.Console.Menu.Mechanics;
using MathsEngine.Console.Menu.Pure;

namespace MathsEngine.Console.Menu;

internal static class Menu
{
    public static void MainMenu() =>
        MenuHelper.RunMenu("Welcome to the Maths Engine", new List<(string Label, Action Action)>
        {
            ("Pure", PureMenu),
            ("Mechanics", MechanicsMenu),
            ("Statistics", StatisticsMenu)
        });

    private static void PureMenu() =>
        MenuHelper.RunMenu("Welcome to the Pure Maths Menu", new List<(string Label, Action Action)>()
        {
            ("Pythagoras Theorem", PythagorasMenu.Menu),
            ("Trigonometry", TrigonometryMenu.Menu),
            ("Matrices", MatrixMenu.Menu),
            ("Coordinate Geometry", CoordinateGeometryMenu.Menu),
            ("Algebra", AlgebraMenu.Menu)
        });

    private static void MechanicsMenu() =>
        MenuHelper.RunMenu("Welcome to the Mechanics Menu", new List<(string Label, Action Action)>()
        {
            ("Uniform Acceleration", UniformAccelerationMenu.Menu),
            ("Newton's Laws Calculations", NewtonsLawsMenu.Menu)
        });

    private static void StatisticsMenu() =>
        MenuHelper.RunMenu("Welcome to the Statistics Menu", new List<(string Label, Action Action)>
        {
            ("Bivariate Analysis", BivariateAnalysisMenu.Menu),
            ("Standard Deviation", DispersionMenu.Menu)
        });
}