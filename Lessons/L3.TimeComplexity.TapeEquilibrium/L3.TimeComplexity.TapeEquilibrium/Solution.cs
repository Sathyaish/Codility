using System;

namespace L3.TimeComplexity.TapeEquilibrium
{
    public class Solution
    {
        // Linear time : O(n)
        public int solution(int[] array)
        {
            if (array == null) throw new ArgumentNullException("array");

            var len = array.Length;

            if (len < 2) throw new ArgumentException("The array must have at least 2 elements.");

            if (len == 2) return (array[0] - array[1]).AbsoluteValue();

            // Make a one pass to get the sum
            var sum = 0;
            for (int i = 0; i < len; i++)
                sum += array[i];

            var sumL = array[0];
            var sumR = sum - array[0];
            var diff = (sumL - sumR).AbsoluteValue();
            var minDiff = diff;

            // Make a second pass to compute min diff
            for(int i = 1; i < len - 1; i++)
            {
                sumL += array[i];
                sumR -= array[i];
                diff = (sumL - sumR).AbsoluteValue();
                minDiff = Min(diff, minDiff);
            }

            return minDiff;
        }

        private int Min(int a, int b)
        {
            return (a < b) ? a : b;
        }
    }
}