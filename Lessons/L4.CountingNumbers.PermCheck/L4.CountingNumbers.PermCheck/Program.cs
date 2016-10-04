using System;
using System.Linq;

namespace L4.CountingNumbers.PermCheck
{
    /*
    https://codility.com/programmers/task/perm_check/
    Lesson 4: Counting Elements
    PermCheck
    Check whether array A is a permutation.



    A non-empty zero-indexed array A consisting of N integers is given.

    A permutation is a sequence containing each element from 1 to N once, and only once.

    For example, array A such that:
        A[0] = 4
        A[1] = 1
        A[2] = 3
        A[3] = 2

    is a permutation, but array A such that:
        A[0] = 4
        A[1] = 1
        A[2] = 3

    is not a permutation, because value 2 is missing.

    The goal is to check whether array A is a permutation.

    Write a function:

        class Solution { public int solution(int[] A); }

    that, given a zero-indexed array A, returns 1 if array A is a permutation and 0 if it is not.

    For example, given array A such that:
        A[0] = 4
        A[1] = 1
        A[2] = 3
        A[3] = 2

    the function should return 1.

    Given array A such that:
        A[0] = 4
        A[1] = 1
        A[2] = 3

    the function should return 0.

    Assume that:

            N is an integer within the range [1..100,000];
            each element of array A is an integer within the range [1..1,000,000,000].

    Complexity:

            expected worst-case time complexity is O(N);
            expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).

    Elements of input arrays can be modified.

    */
    class Program
    {
        static void Main(string[] args)
        {
            // var array = Enumerable.Repeat(1000000, 1000000).ToArray();

            var array = Enumerable.Range(1, 1000000)
                .Except(Enumerable.Repeat(2, 1))
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
            var shadow = new int[len + 1];
            
            for (int i = 0; i < len; i++)
            {
                var current = array[i];

                if (current < 1 || current > len || shadow[current] > 0) return 0;

                shadow[current] += 1;
            }

            for (int i = 1; i < len + 1; i++)
                if (shadow[i] != 1)
                    return 0;

            return 1;
        }

        public int solution2(int[] array)
        {
            var len = array.Length;
            var sum = array[0];

            for(int i = 1; i < len; i++)
            {
                var current = array[i];

                sum += current;

                if (Exists(current, array, 0, i - 1) || current < 1 || current > len)
                    return 0;
            }

            long sumShouldBe = len * (len + 1) / 2;
            
            return sum == sumShouldBe ? 1 : 0;
        }

        private bool Exists(int n, int[] array, int start, int end)
        {
            for (int i = start; i <= end; i++)
                if (array[i] == n)
                    return true;

            return false;
        }
    }
}
