namespace MathsEngine.Core.Modules.Pure;

public class NumberTheory
{
    /// <summary>
    /// Calculates the Highest Common Factor (HCF) for a list of integers.
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public static int GetHcf(params int[] numbers)
    {
        if (numbers.Length == 0) return 1;
        if (numbers.Length == 1) return Math.Abs(numbers[0]);

        int result = Math.Abs(numbers[0]);
        for (int i = 1; i < numbers.Length; i++)
        {
            result = Hcf(result, Math.Abs(numbers[i]));
        }
        return result;
    }

    /// <summary>
    /// Calculates the Lowest Common Multiple (LCM) for a list of integers.
    /// </summary>
    public static int GetLcm(params int[] numbers)
    {
        if (numbers.Length == 0) return 0;
        if (numbers.Length == 1) return Math.Abs(numbers[0]);

        int result = Math.Abs(numbers[0]);
        for (int i = 1; i < numbers.Length; i++)
        {
            // LCM(a, b) = (|a * b|) / HCF(a, b)
            // The 'checked' keyword will throw an OverflowException if the multiplication exceeds int.MaxValue
            result = checked((result * Math.Abs(numbers[i])) / Hcf(result, Math.Abs(numbers[i])));
        }
        return result;
    }

    /// <summary>
    /// Determines if a given integer is a prime number.
    /// </summary>
    public static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        var boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i += 2)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }

    /// <summary>
    /// Helper method to find HCF of two numbers using the Euclidean algorithm.
    /// </summary>
    private static int Hcf(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}