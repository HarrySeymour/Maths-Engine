using MathsEngine.Core.Modules.Pure.Algebra.Core;
using MathsEngine.Core.Modules.Pure.Algebra.Differentiation;
using MathsEngine.Core.Modules.Pure.Algebra.Quadratics;

namespace MathsEngine.Console;

internal static class Program
{
    private static void Main()
    {
        //Menu.Menu.MainMenu();
        
        Polynomial p = new Polynomial("3x^2 + 2x + 1");
        Polynomial differentiated = DifferentiationCalculator.Differentiate(p);
        System.Console.WriteLine(differentiated.ToString());
        
        double gradient  = DifferentiationCalculator.DifferentiateAtPoint(p, 2);
        System.Console.WriteLine($"Gradient at x=2: {gradient}");
    }
}