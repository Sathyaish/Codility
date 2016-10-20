using System;

namespace L6.Sorting.Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { 10, 2, 5, 1, 8, 20 };

            var result = new Solution().solution(array);

            Console.WriteLine($"{(result != 0).ToString()}");
        }
    }
}
