using System;

namespace L7.StacksAndQueues.Nesting
{
    public class Solution
    {
        private const int Yes = 1;
        private const int No = 0;

        public int solution(string s)
        {
            // Null string
            if (s == null) throw new ArgumentNullException("s");

            // Empty string
            s = s.Trim();
            var len = s.Length;
            if (len == 0) return Yes;
            if (len == 1) return No;

            var stack = new int[len];
            var curr = 0;

            for(int i = 0; i < len; i++)
            {
                if (curr < 0) return No;

                if (s[i] == '(')
                    stack[curr++] = s[i];
                else
                    curr--;
            }

            return curr == 0 ? Yes : No;
        }

        public int solution2(string s)
        {
            // Null string
            if (s == null) throw new ArgumentNullException("s");

            // Empty string
            s = s.Trim();
            var len = s.Length;
            if (len == 0) return Yes;
            if (len == 1) return No;

            var pendingOpenParens = 0;

            for (int i = 0; i < len; i++)
            {
                if (pendingOpenParens < 0) return No;

                if (s[i] == '(')
                    pendingOpenParens++;
                else
                    pendingOpenParens--;
            }

            return pendingOpenParens == 0 ? Yes : No;
        }
    }
}
