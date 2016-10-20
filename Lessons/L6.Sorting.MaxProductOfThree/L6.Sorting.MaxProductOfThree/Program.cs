using System;

namespace L6.Sorting.MaxProductOfThree
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { -3, 1, 2, -2, 5, 6 };

            var maxProduct = new Solution().solution(array);

            Console.WriteLine($"Maximum product: {maxProduct}");
        }
    }
}
