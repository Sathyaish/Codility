namespace L5.PrefixSums.GenomicRangeQuery
{
    public class Solution
    {
        public int[] solution(string s, int[] p, int[] q)
        {
            var prefixSums = GetPrefixSums(s);

            var len = p.Length;
            var result = new int[len];

            for(int m = 0; m < len; m++)
            {
                var from = p[m];
                var to = q[m];

                if (prefixSums.PA[to + 1] - prefixSums.PA[from] > 0)
                {
                    result[m] = 1;
                }
                else if (prefixSums.PC[to + 1] - prefixSums.PC[from] > 0)
                {
                    result[m] = 2;
                }
                else if (prefixSums.PG[to + 1] - prefixSums.PG[from] > 0)
                {
                    result[m] = 3;
                }
                else
                {
                    result[m] = 4;
                }
            }

            return result;
        }

        private PrefixSums GetPrefixSums(string s)
        {
            var len = s.Length;

            var a = new int[len + 1];
            var c = new int[len + 1];
            var g = new int[len + 1];

            a[0] = c[0] = g[0] = 0;
            int nA = 0, nC = 0, nG = 0;

            for(int i = 1; i < len + 1; i++)
            {
                if (s[i - 1] == 'A')
                {
                    nA++;
                }
                else if (s[i - 1] == 'C')
                {
                    nC++;
                }
                else if (s[i - 1] == 'G')
                {
                    nG++;
                }

                a[i] = nA;
                c[i] = nC;
                g[i] = nG;
            }

            return new PrefixSums { PA = a, PC = c, PG = g };
        }
    }

    public class PrefixSums
    {
        public int[] PA { get; set; }
        public int[] PC { get; set; }
        public int[] PG { get; set; }
    }
}
