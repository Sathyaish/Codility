using System;

namespace L7.StacksAndQueues.Brackets
{
    public class Solution
    {
        private const int Yes = 1;
        private const int No = 0;
        
        // I would ideally store the bracket types
        // in a dictionary with their key being the closing
        // one and the value being the opening one or vice-versa
        // but they want a space complexity solution of O(N)
        // so I'll just resort to inline if else statements.
        // Bracket types: (), {}, []
        public int solution(string s)
        {
            if (s == null) throw new ArgumentNullException("s");

            s = s.Trim();
            var len = s.Length;

            if (len == 1) return No;

            var stack = new char[len];
            var curr = 0;

            for (int i = 0; i < len; i++)
            {
                if (s[i] == '(' || s[i] == '{' || s[i] == '[')
                {
                    stack[curr++] = s[i];
                }
                else
                {
                    curr--;

                    if (curr < 0) return No;

                    if (s[i] == ')')
                    {
                        if (stack[curr] != '(') return No;
                    }
                    else if (s[i] == '}')
                    {
                        if (stack[curr] != '{') return No;
                    }
                    else if (s[i] == ']')
                    {
                        if (stack[curr] != '[') return No;
                    }
                }
            }

            return curr == 0 ? Yes : No;
        }
    }
}
