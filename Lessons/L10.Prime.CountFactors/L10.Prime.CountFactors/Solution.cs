using System;

public class Solution
{
    public int solution(int n)
    {
        var sqrt = (int)Math.Sqrt(n);

        var num = 0;

        if (n < 2) return n;
        
        for (int i = 1; i <= sqrt; i++)
            if (n % i == 0) num += 2;

        if ((sqrt * sqrt) == n) num--;

        return num;
    }
}