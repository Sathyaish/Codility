using System;

namespace L7.StacksAndQueues.Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            // string s = null; // exception expected
            // var s = string.Empty; // proper
            // var s = "{"; // improper
            // var s = "{[()()]}"; // proper
            // var s = "{}{}{}{}[][][][][{()}]"; // proper
            // var s = "{}{}{}{}[][][][][{()]}"; // improper
            // var s = "([)()]"; // improper

            try
            {
                var result = new Solution().solution(s);

                Console.WriteLine((result == 1).ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
