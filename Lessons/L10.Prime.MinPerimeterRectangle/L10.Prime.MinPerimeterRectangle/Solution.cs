using System;

internal class Solution
{
    internal int solution(int n)
    {
        if (n == 1) return 4;

        long perimeter = 0L;
        long min = 0L;

        var sqrt = (int)Math.Sqrt(n);

        for(int i = 1; i <= sqrt; i++)
        {
            if (n % i == 0)
            {
                var factor1 = n / i;
                var factor2 = n / factor1;

                perimeter = 2 * (factor1 + factor2);

                if (perimeter <= int.MaxValue)
                {
                    if (i == 1)
                        min = perimeter;
                    else
                        min = min < perimeter ? min : perimeter;
                }
            }
        }

        return (int) min;
    }
}