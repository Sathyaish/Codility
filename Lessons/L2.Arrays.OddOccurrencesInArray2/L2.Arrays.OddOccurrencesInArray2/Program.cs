using System;

namespace L2.Arrays.OddOccurrencesInArray2
{
    // My previous solution to this (also checked in into this same
    // git repository) was *so* inefficient. I realize this now
    // having done 25 odd problems or so.
    // Here's another stab at a more efficient solution to this problem.
    // https://codility.com/programmers/lessons/2-arrays/odd_occurrences_in_array/
    class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { 9, 3, 9, 3, 9, 7, 9 };

            var oddOneOut = new Solution().solution(array);

            Console.WriteLine(oddOneOut);
        }
    }
}
