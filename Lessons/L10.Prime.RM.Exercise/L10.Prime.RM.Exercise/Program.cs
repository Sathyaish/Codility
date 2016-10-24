using System;

namespace L10.Prime.RM.Exercise
{
    // Just translating the code in the reading material
    // to understand it.
    // https://codility.com/media/train/8-PrimeNumbers.pdf
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Coins(10));
        }

        static int Coins(int n)
        {
            var result = 0;
            var coins = new int[n + 1];

            for (int i = 1; i < n + 1; i++)
            {
                var k = i;

                while (k <= n)
                {
                    coins[k] = (coins[k] + 1) % 2;

                    k += i;
                }

                result += coins[i];
            }

            return result;
        }
    }
}
