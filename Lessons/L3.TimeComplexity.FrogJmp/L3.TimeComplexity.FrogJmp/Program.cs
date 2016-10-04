using System;

namespace L3.TimeComplexity.FrogJmp
{
    // https://codility.com/programmers/task/frog_jmp/
    // Lesson 3: Time Complexity
    // FrogJmp
    // Count minimal number of jumps from position X to Y.

    /* 

    A small frog wants to get to the other side of the road. The frog is currently located at position X and wants to get to a position greater than or equal to Y. The small frog always jumps a fixed distance, D.

    Count the minimal number of jumps that the small frog must perform to reach its target.

    Write a function:

        class Solution { public int solution(int X, int Y, int D); }

    that, given three integers X, Y and D, returns the minimal number of jumps from position X to a position equal to or greater than Y.

    For example, given:
      X = 10
      Y = 85
      D = 30

    the function should return 3, because the frog will be positioned as follows:

            after the first jump, at position 10 + 30 = 40
            after the second jump, at position 10 + 30 + 30 = 70
            after the third jump, at position 10 + 30 + 30 + 30 = 100

    Assume that:

            X, Y and D are integers within the range [1..1,000,000,000];
            X ≤ Y.

    Complexity:

            expected worst-case time complexity is O(1);
            expected worst-case space complexity is O(1).

    */
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();

            Console.WriteLine(s.solution(10, 85, 30));
            Console.WriteLine(s.solution(2, 85, 3));
            Console.WriteLine(s.solution(3, 85, 3));
            Console.WriteLine(s.solution(4, 85, 3));

            Console.ReadKey();
        }
    }

    class Solution
    {
        public int solution(int x, int y, int d)
        {
            int dividend = (y - x) / d;

            return (y - x) % d == 0 ? dividend : dividend + 1;
        }
    }
}
