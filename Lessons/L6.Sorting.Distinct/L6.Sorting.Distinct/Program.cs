using System;

namespace L6.Sorting.Distinct
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { 2, 1, 1, 2, 3, 1 };
            var n = new Solution().solution(array);

            Console.WriteLine(n);
        }
    }
}
