using System;

namespace L5.PrefixSums.CountDiv
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 11;
            int b = 345;
            int k = 17;

            var numMultiples = new Solution().solution(a, b, k);

            Console.WriteLine($"Number of multiples of {k} between {a} and {b}: {numMultiples}");
        }
    }
}
