using System;

namespace L5.PrefixSums.RM.Exercise1
{
    // https://codility.com/media/train/3-PrefixSums.pdf
    // Or consult my private repo on bitbucket named Codility
    // for a description of this exercise.
    class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { 7, 21, 12, 8, 0, 9, 2, 7 };

            array.Print(leadingMessage: "Input: ");
            Console.WriteLine();

            var maxMushrooms = MaxNumberOfMushrooms(array, 2, 6);
            Console.WriteLine($"Max: {maxMushrooms}");

            Console.ReadKey();
        }

        static long MaxNumberOfMushrooms(int[] array, int station, int numMoves)
        {
            int? nLen = array?.Length;

            // array must not be null or must not contain zero items
            if (array == null || nLen == null || nLen == 0)
                throw new ArgumentNullException("array");

            var len = nLen.Value;

            // station and numMoves must be greater than zero and 
            // less than the length of the input array
            if (station < 0 || station >= len)
                throw new ArgumentException("station must be a number greater than or equal to zero and less than the length of the input array.");

            if (numMoves < 0 || numMoves >= len)
                throw new ArgumentException("numMoves must be a number greater than or equal to zero and less than the length of the input array.");

            // if no moves, then the number of mushrooms
            // is the value of the station
            if (numMoves == 0) return array[station];

            var prefixSums = GetPrefixSums(array);
            prefixSums.Print(leadingMessage: "Prefix Sums: ");

            long max = 0L;

            // Go left first till you hit the left end of the array
            Console.WriteLine();
            int lMoves = 0;
            while (true)
            {
                int fromIndex = station - lMoves;
                int toIndex = fromIndex + (numMoves - lMoves);

                if (toIndex >= len)
                {
                    lMoves++;
                    continue;
                }

                if (fromIndex < 0) break;

                var sum = GetSumOfSlice(prefixSums, fromIndex, toIndex);
                Console.WriteLine($"Sum from index {fromIndex} to {toIndex}: {sum}");
                max = Max(max, sum);

                lMoves++;
            }

            // Go right now till you hit the right end of the array
            Console.WriteLine();
            int rMoves = 0;
            while (true)
            {
                int toIndex = station + rMoves;
                int fromIndex = toIndex - (numMoves - rMoves);

                if (fromIndex < 0)
                {
                    rMoves++;
                    continue;
                }

                if (toIndex >= len) break;

                var sum = GetSumOfSlice(prefixSums, fromIndex, toIndex);
                Console.WriteLine($"Sum from index {fromIndex} to {toIndex}: {sum}");
                max = Max(max, sum);

                rMoves++;
            }

            return max;
        }

        private static long[] GetPrefixSums(int[] array)
        {
            int? nLen = array?.Length;

            // array null or empty
            if (array == null || nLen == null || nLen == 0)
                throw new ArgumentNullException("array");

            var len = nLen.Value;

            // array with 1 element
            if (len == 1) return new long[] { 0L, array[0] };

            var prefixSums = new long[len + 1];

            prefixSums[0] = 0L;
            var runningTotal = 0L;

            for (int i = 1; i < len + 1; i++)
            {
                runningTotal += array[i - 1];
                prefixSums[i] = runningTotal;
            }

            return prefixSums;
        }

        static long GetSumOfSlice(long[] prefixSums, int from, int to)
        {
            return prefixSums[to + 1] - prefixSums[from];
        }

        static long Max(long a, long b)
        {
            return a > b ? a : b;
        }
    }
}