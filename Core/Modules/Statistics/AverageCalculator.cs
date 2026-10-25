using System.Numerics;
using Core.Utils.Exceptions;

namespace Core.Modules.Statistics
{
    internal class AverageCalculator<T> where T : INumber<T>
    {
        // MEASURES OF LOCATION

        /// <summary>
        /// Calculates the mean (average) of a list of double values.
        /// </summary>
        /// <param name="numbers">A list of double values for which the mean is to be calculated. The list must not be null.</param>
        /// <returns>The mean of the values in the list. Returns 0 if the list is empty.</returns>
        internal T CalculateMean(List<T> numbers)
        {
            if (numbers == null || numbers.Count == 0)
                throw new NullInputException("Input list cannot be null or empty.");

            T sum = T.Zero;

            foreach (T num in numbers)
                sum += num;

            T average = sum / T.CreateChecked(numbers.Count);

            return average;
        }

        /// <summary>
        /// Calculates the median (average) of a list of double values
        /// </summary>
        /// <param name="numbers"> A list of double values for which the median is to be calculated. The list must not be null.</param>
        /// <returns>The median of the values of the list. Returns 0 if the list is empty.</returns>
        internal T CalculateMedian(List<T> numbers)
        {
            if (numbers == null || numbers.Count == 0)
                throw new NullInputException("Input list cannot be null or empty.");

            var sortedNumbers = new List<T>(numbers);
            sortedNumbers.Sort();

            T midIndex = T.CreateChecked(numbers.Count / 2);
            T median;

            if (sortedNumbers.Count % 2 == 0)
            {
                // Even number of elements: average of the two middle elements
                int index = (int)Convert.ChangeType(midIndex, typeof(int));
                median = (sortedNumbers[index - 1] + sortedNumbers[index]) / T.CreateChecked(2);
            }
            else
            {
                // Odd number of elements: the middle element
                int index = (int)Convert.ChangeType(midIndex, typeof(int));
                median = sortedNumbers[index];
            }

            return median;
        }

        /// <summary>
        /// Calculates the mode(s) of a list of numbers.
        /// </summary>
        /// <param name="numbers">The list of numbers to analyze.</param>
        /// <returns>A List containing the mode(s). Returns an empty list if there is no mode.</returns>
        internal List<T> CalculateMode(List<T> numbers)
        {
            // If the list is empty or has only one value, there can be no mode.
            if (numbers == null || numbers.Count <= 1)
                throw new InsufficientDataException("List must contain more than one value to find a mode.");

            // Use a Dictionary to count the frequency of each number.
            // Key: the number, Value: its frequency.
            var counts = new Dictionary<T, int>();
            foreach (var number in numbers)
            {
                if (counts.ContainsKey(number))
                {
                    counts[number]++;
                }
                else
                {
                    counts[number] = 1;
                }
            }

            // Find the highest frequency count.
            int maxCount = 0;
            foreach (var count in counts.Values)
            {
                if (count > maxCount)
                {
                    maxCount = count;
                }
            }

            // If no number appears more than once, there is no mode.
            if (maxCount <= 1)
            {
                return new List<T>();
            }

            // Find all numbers that have the highest frequency.
            var modes = new List<T>();
            foreach (var pair in counts)
            {
                if (pair.Value == maxCount)
                {
                    modes.Add(pair.Key);
                }
            }

            return modes;
        }

        /// <summary>
        /// Calculates the range of a list of doubles. It sorts the list then gets the difference from the index at each end.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>The difference between the min and max value.</returns>
        internal T CalculateRange(List<T> numbers)
        {
            var sortedNums = new List<T>(numbers);

            return sortedNums[sortedNums.Count - 1] - sortedNums[0];
        }

        // MEASURES OF DISPERSION

        /// <summary>
        /// Calculates the interquartile range (IQR) of a given list of numeric values.
        /// </summary>
        /// <remarks>The interquartile range is calculated as the difference between the third quartile (Q3)
        /// and the first quartile (Q1). The input list is sorted internally, and the calculation  accounts for
        /// both even and odd numbers of elements in the list.</remarks>
        /// <param name="originalValues">A list of numeric values for which the interquartile range is to be calculated.  The list must contain at
        /// least four elements.</param>
        /// <returns>A list containing three values: the first quartile (Q1), the third quartile (Q3),  and the interquartile
        /// range (IQR), in that order. Returns <see langword="null"/>  if the input list contains fewer than four
        /// elements.</returns>
        internal List<T> GetInterQuartileRange(List<T> originalValues)
        {
            T Q1, Q3, IQR;
            int numValues = originalValues.Count;

            var sortedValues = new List<T>(originalValues);
            sortedValues.Sort();

            if (sortedValues == null || numValues < 4)
                throw new InsufficientDataException("List must contain at least four elements to calculate IQR.");

            if (numValues % 2 == 0) // 0 | Q1 | 1 | Q2 | 2 | Q3 |3
            {
                int midIndex = numValues / 2;

                List<T> upperHalf = sortedValues.GetRange(0, midIndex);
                List<T> lowerHalf = sortedValues.GetRange(midIndex, midIndex);

                Q1 = CalculateMedian(lowerHalf);
                Q3 = CalculateMedian(upperHalf);
                IQR = Q3 - Q1;

                return new List<T> { Q1, Q3, IQR };
            }
            if (numValues % 2 == 1)// 1 Q1 2 Q2 4 Q3 5
            {
                int midIndex = numValues / 2;

                List<T> lowerHalf = sortedValues.GetRange(0, midIndex);
                List<T> upperHalf = sortedValues.GetRange(midIndex + 1, midIndex);

                Q1 = CalculateMedian(lowerHalf);
                Q3 = CalculateMedian(upperHalf);
                IQR = Q3 - Q1;

                return new List<T> { Q1, Q3, IQR };
            }

            return null;
        }
    }
}