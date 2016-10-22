using System;
using System.Linq;

namespace L4.CountingElements.MissingInteger
{
    /* 

    Lesson 4: Counting Elements
    MissingInteger
    Find the minimal positive integer not occurring in a given sequence.

    Write a function:

        class Solution { public int solution(int[] A); }

    that, given a non-empty zero-indexed array A of N integers, returns the minimal positive integer (greater than 0) that does not occur in A.

    For example, given:
      A[0] = 1
      A[1] = 3
      A[2] = 6
      A[3] = 4
      A[4] = 1
      A[5] = 2

    the function should return 5.

    Assume that:

            N is an integer within the range [1..100,000];
            each element of array A is an integer within the range [−2,147,483,648..2,147,483,647].

    Complexity:

            expected worst-case time complexity is O(N);
            expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).

    Elements of input arrays can be modified.

    */
    class Program
    {
        static void Main(string[] args)
        {
            var array = Enumerable
                .Range(1, 1000000)
                .Except(Enumerable.Repeat(250009, 1))
                .ToArray();

            var s = new Solution();
            var result = s.solution(array);

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }

    class Solution
    {
        public int solution(int[] array)
        {
            var len = array.Length;

            if (len == 1)
            {
                return (array[0] == 1) ? 2 : 1;
            }

            var shadow = new int[len + 2];

            for(int i = 0; i < len; i++)
            {
                var current = array[i];

                if ((current < 0) || (current > len + 1)) continue;

                shadow[current] += 1;
            }

            for (int i = 1; i < len + 2; i++)
                if (shadow[i] == 0) return i;

            return 0;
        }
    }
}
