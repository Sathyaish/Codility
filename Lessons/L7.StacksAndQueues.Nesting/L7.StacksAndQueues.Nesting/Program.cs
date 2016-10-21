using System;

namespace L7.StacksAndQueues.Nesting
{
    class Program
    {
        static void Main(string[] args)
        {
            // var s = "(()(())())";
            // string s = null;
            // string s = string.Empty;
            // var s = "())";
            // var s = "(";
            var s = "))))((((";

            var result = new Solution().solution2(s);

            Console.WriteLine((result == 1).ToString());
        }
    }
}
