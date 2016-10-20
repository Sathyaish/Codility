using System;

namespace L5.PrefixSums.MinAvgTwoSlice
{
    public class Solution
    {
        public int solution(int[] array)
        {
            // Empty or null array
            var nLen = array?.Length;

            if (array == null || nLen == null || nLen == 0)
                throw new ArgumentNullException("array");

            var len = nLen.Value;

            // Array with less than two elements
            if (len < 2) throw new ArgumentException("array");

            // Array with two elements
            if (len == 2) return 0;

            // Asymotes towards large values
            double minAverage = double.MaxValue;
            var prefixSums = GetPrefixSums(array);
            var minIndex = -1;

            // Console.WriteLine();

            for(int i = 0; i < len - 1; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    int n = j - i + 1;
                    long sumOfSlice = prefixSums[j + 1] - prefixSums[i];
                    double average = sumOfSlice / n;

                    // Console.WriteLine($"slice ({i}, {j}), Average: {average}");

                    if (average < minAverage)
                    {
                        minAverage = average;
                        minIndex = i;
                    }
                }

                // Console.WriteLine();
            }

            return minIndex;
        }

        static long[] GetPrefixSums(int[] array)
        {
            var nLen = array?.Length;

            if (array == null || nLen == null || nLen == 0)
                throw new ArgumentNullException("array");

            var len = nLen.Value;
            var prefixSums = new long[len + 1];
            prefixSums[0] = 0;
            var runningTotal = 0;

            for(int i = 1; i < len + 1; i++)
            {
                runningTotal += array[i - 1];
                prefixSums[i] = runningTotal;    
            }

            return prefixSums;
        }
    }
}
