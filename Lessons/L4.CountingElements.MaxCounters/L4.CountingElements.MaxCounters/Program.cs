using System;

namespace L4.CountingElements.MaxCounters
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { 3, 4, 4, 6, 1, 4, 4 };

            var s = new Solution();
            var result = s.solution(5, array);

            result.Print(leadingMessage: "\nOutput array: ");

            Console.ReadKey();
        }
    }

    class Solution
    {
        public int[] solution(int n, int[] array)
        {
            var len = array.Length;
            var counters = new int[n];
            var max = 0;

            for(int i = 0; i < len; i++)
            {
                var current = array[i];

                if (current <= 0) throw new Exception("Invalid input. Array element cannot be less than 1.");

                if (current <= n)
                {
                    increase(current - 1, counters);
                    max = Max(max, counters[current - 1]);
                }
                else
                {
                    maxCounter(max, counters);
                }
            }

            return counters;
        }

        private int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        private void increase(int i, int[] array)
        {
            array[i] += 1;
        }

        private void maxCounter(int max, int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = max;
        }
    }
}