using System;

namespace L5.PrefixSums.GenomicRangeQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "CAGCCTA";
            var p = new [] { 2, 5, 0 };
            var q = new[] { 4, 5, 6 };

            var result = new Solution().solution(s, p, q);

            PrintArray(result);
        }

        private static void PrintArray(int[] result)
        {
            for(int i = 0; i < result.Length; i++)
            {
                Console.WriteLine($"{result[i]}");
            }
        }
    }
}
