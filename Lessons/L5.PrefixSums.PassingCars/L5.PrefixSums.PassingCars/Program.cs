using System;

namespace L5.PrefixSums.PassingCars
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { 1, 0, 0, 1, 1, 0, 1, 1, 1, 1, 0, 0 };

            var maxPairs = new Solution().solution(array);

            Console.WriteLine($"Max pairs: {maxPairs}");
        }
    }
}
