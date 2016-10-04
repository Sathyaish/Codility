using System;

namespace L1.Iterations.BinaryGap
{
    public class Solution
    {
        // This one finds the longest sequence of zeros
        // ONLY WHERE it is surrounded by 1's on both sides
        public int solution(int n)
        {
            var s = Convert.ToString(n, 2);
            
            var len = s.Length;
            var numZeros = 0;
            var oneEncountered = false;
            var previousWasZero = false;
            var longest = 0;

            for (int i = 0; i < len; i++)
            {
                if (s[i] == '0')
                {
                    if (oneEncountered) numZeros++;
                    previousWasZero = true;
                }
                else
                {
                    oneEncountered = true;

                    if (previousWasZero)
                    {
                        longest = Max(numZeros, longest);

                        if ((len - (i + 1)) < numZeros) break;

                        // Reset the number of zeros
                        numZeros = 0;
                    }

                    previousWasZero = false;
                }
            }

            return longest;
        }

        // This one find the longest sequence of binary zeros
        // NOT NECESSARILY surrounded by 1's on both sides.
        // Just the longest one.
        // So it will return 5 for this binary: 10100100000
        // or for this one: 0000010100
        // or even for this one: 100000101
        public int solution2(int n)
        {
            var s = Convert.ToString(n, 2);
            
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
