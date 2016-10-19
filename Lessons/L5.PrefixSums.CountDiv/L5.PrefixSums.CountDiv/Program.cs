using System;

namespace L5.PrefixSums.CountDiv
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 71;
            int b = 79;
            int k = 5;

            var numMultiples = new Solution().solution(a, b, k);

            Console.WriteLine($"Number of multiples of {k} between {a} and {b}: {numMultiples}");
        }
    }
}
