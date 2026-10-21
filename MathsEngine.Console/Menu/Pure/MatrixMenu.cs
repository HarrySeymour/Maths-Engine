using MathsEngine.Core.Modules.Pure.Matrices;
using MathsEngine.Console.Utils;
using MathsEngine.Core.Utils.Exceptions;

namespace MathsEngine.Console.Menu.Pure;
internal static class MatrixMenu
{
    public static void Menu()
    {
        while (true)
        {
            System.Console.Clear();
            System.Console.WriteLine("Matrices Calculator");
            System.Console.WriteLine("1. Adding matrices");
            System.Console.WriteLine("2. Subtract matrices");
            System.Console.WriteLine("3. Multiply a matrix by a number");
            System.Console.WriteLine("4. Divide a matrix by a number");
            System.Console.WriteLine("5. Multiply matrices by matrices");
            System.Console.WriteLine("6. Calculate the determinant of a square matrix");
            System.Console.WriteLine("7. Back");
            int response = Parsing.GetMenuInput("Input: ", 7);

            switch (response)
            {
                case 1:
                    HandleAddMatrix();
                    break;
                case 2:
                    HandleSubtractMatrix();
                    break;
                case 3:
                    HandleScalarMultiplication();
                    break;
                case 4:
                    HandleScalarDivision();
                    break;
                case 5:
                    HandleMatrixMultiplication();
                    break;
                case 6:
                    HandleDeterminant();
                    break;
                case 7: return;
            }
            System.Console.WriteLine("\nPress Enter to continue...");
            System.Console.ReadLine();
        }
    }

    private static void HandleAddMatrix()
    {
        System.Console.Clear();

        int rows1 = Parsing.GetIntInput("First Matrix - How many rows: ");
        int columns1 = Parsing.GetIntInput("First Matrix - How many columns: ");
        MatrixBase matrix1 = new MatrixBase(rows1, columns1);
        PopulateMatrixFromInput(matrix1);

        int rows2 = Parsing.GetIntInput("Second Matrix - How many rows: ");
        int columns2 = Parsing.GetIntInput("Second Matrix - How many columns: ");
        MatrixBase matrix2 = new MatrixBase(rows2, columns2);
        PopulateMatrixFromInput(matrix2);

        try
        {
            var result = MatrixCalculator.AddMatrix(matrix1, matrix2);
            DisplayMatrix(result.Matrix);

            System.Console.WriteLine("\nCalculation complete. Press any key to return to the menu...");
            System.Console.ReadKey();
        }
        catch (NullInputException)
        {
            ErrorDisplay.ShowError("Error: Empty Input - Please enter values for the matrices.");
        }
        catch (IncompatibleMatrixAdditionException)
        {
            ErrorDisplay.ShowError("Error: Matrices are not the same size.");
        }
    }
    private static void HandleSubtractMatrix()
    {
        System.Console.Clear();

        int rows1 = Parsing.GetIntInput("First Matrix - How many rows: ");
        int columns1 = Parsing.GetIntInput("First Matrix - How many columns: ");
        MatrixBase matrix1 = new MatrixBase(rows1, columns1);
        PopulateMatrixFromInput(matrix1);

        int rows2 = Parsing.GetIntInput("Second Matrix - How many rows: ");
        int columns2 = Parsing.GetIntInput("Second Matrix - How many columns: ");
        MatrixBase matrix2 = new MatrixBase(rows2, columns2);
        PopulateMatrixFromInput(matrix2);

        try
        {
            var result = MatrixCalculator.SubtractMatrix(matrix1, matrix2);
            DisplayMatrix(result.Matrix);

            System.Console.WriteLine("\nCalculation complete. Press any key to return to the menu...");
            System.Console.ReadKey();
        }
        catch (NullInputException)
        {
            ErrorDisplay.ShowError("\nError: Empty Input - Please enter values for the matrices.");
        }
        catch (IncompatibleMatrixSubtractionException)
        {
            ErrorDisplay.ShowError("Error: Matrices are not the same size.");
        }
    }

    private static void HandleScalarMultiplication()
    {
        System.Console.Clear();

        int rows = Parsing.GetIntInput("How many rows in the matrix: ");
        int columns = Parsing.GetIntInput("How many columns in the matrix: ");

        double number = Parsing.GetDoubleInput("What number would you like to multiply this matrix by: ");

        MatrixBase matrix = new MatrixBase(rows, columns);
        PopulateMatrixFromInput(matrix);

        try
        {
            var result = MatrixCalculator.ScalarMultiplication(matrix, number);
            DisplayMatrix(result.Matrix);

            System.Console.WriteLine("\nCalculation complete. Press any key to return to the menu...");
            System.Console.ReadKey();
        }
        catch (NullInputException)
        {
            ErrorDisplay.ShowError("\nError: Empty Input - Please enter values for the matrices.");
        }
    }
    private static void HandleScalarDivision()
    {
        System.Console.Clear();

        int rows = Parsing.GetIntInput("How many rows in the matrix: ");
        int columns = Parsing.GetIntInput("How many columns in the matrix: ");

        double number = Parsing.GetDoubleInput("What number would you like to divide this matrix by: ");

        MatrixBase matrix = new MatrixBase(rows, columns);
        PopulateMatrixFromInput(matrix);

        try
        {
            var result = MatrixCalculator.ScalarDivision(matrix, number);
            DisplayMatrix(result.Matrix);

            System.Console.WriteLine("\nCalculation complete. Press any key to return to the menu...");
            System.Console.ReadKey();
        }
        catch (DivideByZeroException)
        {
            ErrorDisplay.ShowError("\nError: Cannot divide by 0");
        }
        catch (NullInputException)
        {
            ErrorDisplay.ShowError("\nError: Empty Input - Please enter values for the matrices.");
        }
    }

    private static void HandleMatrixMultiplication()
    {
        System.Console.Clear();

        int rows1 = Parsing.GetIntInput("First Matrix - How many rows: ");
        int columns1 = Parsing.GetIntInput("First Matrix - How many columns: ");
        MatrixBase matrix1 = new MatrixBase(rows1, columns1);
        PopulateMatrixFromInput(matrix1);

        int rows2 = Parsing.GetIntInput("Second Matrix - How many rows: ");
        int columns2 = Parsing.GetIntInput("Second Matrix - How many columns: ");
        MatrixBase matrix2 = new MatrixBase(rows2, columns2);
        PopulateMatrixFromInput(matrix2);

        try
        {
            var result = MatrixCalculator.MatrixMultiplication(matrix1, matrix2);
            DisplayMatrix(result.Matrix);

            System.Console.WriteLine("\nCalculation complete. Press any key to return to the menu...");
            System.Console.ReadKey();
        }
        catch (IncompatibleMatrixMultiplicationException)
        {
            ErrorDisplay.ShowError("Error: These matrices are not compatible for multiplication");
        }
    }

    private static void HandleDeterminant()
    {
        System.Console.Clear();

        MatrixBase matrix = new MatrixBase(2, 2);
        PopulateMatrixFromInput(matrix);

        try
        {
            var determinant = matrix.CalculateDeterminant();
            System.Console.WriteLine($"Determinant: {determinant}");

            System.Console.WriteLine("\nCalculation complete. Press any key to return to the menu...");
            System.Console.ReadKey();
        }
        catch (NullInputException)
        {
            ErrorDisplay.ShowError("\nError: Empty Input - Please enter values for the matrices.");
        }
    }

    private static void PopulateMatrixFromInput(MatrixBase matrix)
    {
        System.Console.WriteLine("Enter the matrix values:");
        for (int i = 0; i < matrix.NumRows; i++)
        {
            for (int j = 0; j < matrix.NumCols; j++)
            {
                matrix.Matrix[i, j] = Parsing.GetDoubleInput($"Enter value for [{i + 1},{j + 1}]: ");
            }
        }
    }

    private static void DisplayMatrix(double[,] matrix)
    {
        try
        {
            System.Console.WriteLine("\nResult Matrix: ");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    System.Console.Write(matrix[i, j] + " ");
                }

                System.Console.WriteLine();
            }

            System.Console.WriteLine("\nCalculation complete. Press any key to return to the menu...");
            System.Console.ReadKey();
        }
        catch (NullInputException)
        {
            ErrorDisplay.ShowError("\nError: Empty Input - Please enter values for the matrices.");
        }
    }
}