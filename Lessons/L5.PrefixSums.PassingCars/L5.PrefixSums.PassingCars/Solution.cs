using System;

namespace L5.PrefixSums.PassingCars
{
    public class Solution
    {
        public int solution(int[] array)
        {
            var nLen = array?.Length;

            if (array == null || nLen == null || nLen == 0)
                throw new ArgumentNullException("array");

            if (nLen < 2)
                throw new ArgumentException("Input array must have at least 2 elements.");

            var len = nLen.Value;

            var numPairs = 0;
            var prefixSums = GetPrefixSums(array);

            for (int i = 0; i < len; i++)
            {
                if (array[i] != 0) continue;

                numPairs += GetSumOfSlice(prefixSums, i, len - 1);
            }

            return numPairs > 1000000000 ? -1 : numPairs;
        }
        
        private int GetSumOfSlice(int[] prefixSums, int from, int to)
        {
            return prefixSums[to + 1] - prefixSums[from];
        }

        private int[] GetPrefixSums(int[] array)
        {
            var nLen = array?.Length;

            if (array == null || nLen == null || nLen == 0)
                throw new ArgumentNullException("array");

            var len = nLen.Value;

            if (len == 1) return new[] { 0, array[0] };

            var prefixSums = new int[len + 1];
            prefixSums[0] = array[0];
            int runningTotal = 0;

            for(int i = 1; i < len + 1; i++)
            {
                runningTotal += array[i - 1];
                prefixSums[i] = runningTotal;
            }

            return prefixSums;
        }
    }
}
