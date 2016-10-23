using System;

namespace L5.PrefixSums.CountDiv
{
    class Program
    {
        static void Main(string[] args)
        {
            Test(11, 345, 17);
            Test(70, 75, 5);
            Test(71, 76, 5);
            Test(71, 75, 5);
            Test(40, 120, 60);
            Test(20, 100, 60);
            Test(6, 11, 2);
        }

        static void Test(int a, int b, int k)
        {
            Console.WriteLine();

            var numMultiples = new Solution().solution(a, b, k);
            Console.WriteLine($"Number of multiples of {k} between {a} and {b}: {numMultiples}");
            PrintFactors(a, b, k);
        }

        static void PrintFactors(int from, int to, int of)
        {
            Console.Write("[");
            int n = 0;
            for (int i = from; i <= to; i++)
            {
                if (i % of == 0)
                {
                    Console.Write($"{i}, ");
                    n++;
                }
            }

            Console.WriteLine($"]: {n} factors found.");
        }
    }
}
