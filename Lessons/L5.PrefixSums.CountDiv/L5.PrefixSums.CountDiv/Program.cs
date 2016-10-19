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

            Console.WriteLine($"Number of multiples of {k} between {a} and {b}: {numMultiples}\n");
            PrintFactors(a, b, k);
            Verbose(a, b, k);
        }

        static void PrintFactors(int from, int to, int of)
        {
            int n = 0;
            for (int i = from; i <= to; i++)
            {
                if (i % of == 0)
                {
                    Console.Write($"{i}, ");
                    n++;
                }
            }

            Console.WriteLine($"\n{n} factors found.");
        }

        static int Verbose(int a, int b, int k)
        {
            Console.WriteLine();

            var difference = b - a;
            Console.WriteLine($"Difference: {difference}");

            if (difference == 0) return (a % k == 0 ? 1 : 0);

            var dividend = difference / k;
            var remainder = difference % k;

            Console.WriteLine($"Dividend: {dividend}");
            Console.WriteLine($"Remainder: {remainder}");

            return ((remainder == (k - 1)) || (remainder == 0)) ? dividend + 1 : dividend;
        }
    }
}
