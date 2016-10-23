using System;

namespace L8.Leader.RM.Leader
{
    // https://codility.com/media/train/6-Leader.pdf
    class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { 1, 2, 3, 3, 3, 2, 3, 3, 3 };
            var leader = new Solution().solution2(array);
            Console.WriteLine($"Leader: {leader}");
        }
    }
}
