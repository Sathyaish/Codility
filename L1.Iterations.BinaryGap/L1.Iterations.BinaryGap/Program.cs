using System;

namespace L1.Iterations.BinaryGap
{
    // https://codility.com/programmers/lessons/18/
    // Lesson 1: Iterations
    // Task: Binary Gap
    // Find longest sequence of zeros in binary representation of a number
    class Program
    {
        static void Main(string[] args)
        {
            var n = 0;

            Console.WriteLine("This program finds the longest sequence of zeros \nin the binary representation of a number.");
            Console.Write("\nType the number in whose binary representation you \nwish to find the longest sequence of zeros: ");
            var b = int.TryParse(Console.ReadLine(), out n);

            if (!b) return;

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
                        longest = LargerOf(numZeros, longest);

                        if ((len - i) < numZeros) break;

                        numZeros = 0;
                    }
                }
            }

            if (longest == 0)
            {
                Console.WriteLine("There are no zero's in the binary representation of {0}.", n);
            }
            else
            {
                Console.WriteLine("The largest sequence of zero's in the binary represenation of {0} consists of {1} zeros.", n, longest);
            }

            Console.ReadKey();
        }

        public static int LargerOf(int a, int b)
        {
            return a > b ? a : b;
        }
    }
}
