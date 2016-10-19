using System;

namespace L5.PrefixSums.MinAvgTwoSlice
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { 4, 2, 2, 5, 1, 5, 8 };

            var result = new Solution().solution(array);

            Console.WriteLine(result);
        }
    }
}
