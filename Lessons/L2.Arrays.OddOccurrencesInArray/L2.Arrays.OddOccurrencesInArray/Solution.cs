using System;
using System.Diagnostics;

namespace L2.Arrays.OddOccurrencesInArray
{
    public class Solution
    {
        public int solution(int[] array)
        {
            if (array == null) throw new ArgumentNullException("array");

            var len = array.Length;
            Debug.Assert(len.IsOdd());

            var medianIndex = (len - 1) / 2;
            var tempArray = new int[medianIndex];
            tempArray[0] = array[medianIndex];
            var tempArrayFilledTillIndex = 0;

            int backward = medianIndex - 1;
            int forward = medianIndex + 1;

            while (backward >= 0 || forward < len)
            {
                if (backward >= 0)
                {
                    CompareElement(array, tempArray, ref backward, ref tempArrayFilledTillIndex);

                    backward--;
                }

                if (forward < len)
                {
                    CompareElement(array, tempArray, ref forward, ref tempArrayFilledTillIndex);

                    forward++;
                }
            }

            return tempArray[0];
        }

        private static void CompareElement(int[] array, int[] tempArray, ref int index, ref int tempArrayFilledTillIndex)
        {
            if (tempArrayFilledTillIndex < -1) throw new ArgumentException();

            if (tempArrayFilledTillIndex == -1)
            {
                tempArray[++tempArrayFilledTillIndex] = array[index];
                return;
            }

            var elementFoundAt = tempArray.Find<int>(array[index], 0, tempArrayFilledTillIndex);

            if (elementFoundAt >= 0)
            {
                tempArray.RemoveElementAt(elementFoundAt);
                tempArrayFilledTillIndex--;
            }
            else
            {
                tempArray[++tempArrayFilledTillIndex] = array[index];
            }
        }
    }
}
