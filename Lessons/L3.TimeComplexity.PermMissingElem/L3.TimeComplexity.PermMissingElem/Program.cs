using System;
using System.Linq;

namespace L3.TimeComplexity.PermMissingElem
{
    // https://codility.com/programmers/task/perm_missing_elem/
    // Lesson 3: Time Complexity
    // PermMissingElem
    // Find the missing element in a given permutation.

    /*

    A zero-indexed array A consisting of N different integers is given. The array contains integers in the range [1..(N + 1)], which means that exactly one element is missing.

    Your goal is to find that missing element.

    Write a function:

        class Solution { public int solution(int[] A); }

    that, given a zero-indexed array A, returns the value of the missing element.

    For example, given array A such that:
      A[0] = 2
      A[1] = 3
      A[2] = 1
      A[3] = 5

    the function should return 4, as it is the missing element.

    Assume that:

            N is an integer within the range [0..100,000];
            the elements of A are all distinct;
            each element of array A is an integer within the range [1..(N + 1)].

    Complexity:

            expected worst-case time complexity is O(N);
            expected worst-case space complexity is O(1), beyond input storage (not counting the storage required for input arguments).

    Elements of input arrays can be modified.

    */
    class Program
    {
        static void Main(string[] args)
        {
            var array = Enumerable
                .Range(1, 1000000)
                .Except(Enumerable.Repeat(10001, 1))
                .ToArray();

            var s = new Solution();
            var n = s.solution(array);
            Console.WriteLine(n);

            Console.ReadKey();
        }
    }

    class Solution
    {
        public int solution(int[] array)
        {
            var len = array.Length;

            var sum = 0;

            for (int i = 0; i < len; i++)
                sum += array[i];

            long product = (long)(len + 1) * (len + 2);

            return (int)((product / 2) - sum);
        }
    }
}