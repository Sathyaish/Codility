using System;

namespace L4.CountingElements.FrogRiverOne
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { 1, 3, 1, 4, 2, 3, 5, 4 }; // Enumerable.Range(1, 100).ToArray();

            var s = new Solution();
            var result = s.solution(5, array);

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }

    class Solution
    {
        public int solution(int x, int[] array)
        {
            var len = array.Length;

            if (len == 1) return (x == 0 ? 0 : -1);

            var shadow = new int[len + 1];
            var sumTillX = (long)(x * (x + 1)) / 2;
            var runningTotal = 0;

            for (int i = 0; i < len; i++)
            {
                var current = array[i];

                if (current < 0 || current > x) continue;

                shadow[current] += 1;

                if (shadow[current] == 1)
                {
                    runningTotal += current;

                    if (runningTotal == sumTillX) return i;
                }
            }

            return -1;
        }
    }
}