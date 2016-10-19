using System;

namespace L5.PrefixSums.CountDiv
{
    public class Solution
    {
        public int solution(int a, int b, int k)
        {
            var difference = b - a;

            if (difference == 0) return (a % k == 0 ? 1 : 0);

            var dividend = difference / k;
            var remainder = difference % k;

            return (remainder == (k - 1)) ? dividend + 1 : dividend;
        }
    }
}
