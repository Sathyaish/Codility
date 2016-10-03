using System;

namespace L1.Iterations.BinaryGap
{
    public class Solution
    {
        public int solution(int n)
        {
            var s = Convert.ToString(n, 2);
            Console.WriteLine("\nThe binary representation of {0} is {1}.", n, s);

            var len = s.Length;
            var numZeros = 0;
            var previousWasZero = false;
            var longest = 0;

            for (int i = 0; i < len; i++)
            {
                if (s[i] == '0')
                {
                    numZeros++;
                    previousWasZero = true;
                }
                else
                {
                    if (previousWasZero)
                    {
                        longest = Max(numZeros, longest);

                        if ((len - (i + 1)) < numZeros) break;

                        numZeros = 0;
                    }

                    previousWasZero = false;
                }
            }

            return Max(numZeros, longest);
        }

        public static int Max(int a, int b)
        {
            return a > b ? a : b;
        }
    }
}
