using System;

namespace L6.Sorting.MaxProductOfThree
{
    public class Solution
    {
        public int solution(int[] array)
        {
            var nLen = array?.Length;

            if (array == null || nLen == null)
            {
                throw new ArgumentNullException("array");
            }

            var len = nLen.Value;

            if (len < 3)
            {
                throw new ArgumentException("The input array must have at least 3 elements.");
            }

            if (len == 3) return array[0] * array[1] * array[2];
            
            Array.Sort(array);

            var productOfLastThreeTerms = array[len - 1] * array[len - 2] * array[len - 3];

            var product = int.MinValue;
            if (array[0] < 0 && array[1] < 0 && array[len - 1] > 0)
            {
                product = array[0] * array[1] * array[len - 1];
            }

            return productOfLastThreeTerms > product ? productOfLastThreeTerms : product;
        }
    }
}