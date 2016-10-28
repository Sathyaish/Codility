using System;
using System.Collections.Generic;

public class Solution
{

    // To be continued tomorrow

    public Set[] solution(int[] denominations, int amount)
    {
        if (denominations == null)
            throw new ArgumentNullException("denominations");

        var len = denominations.Length;

        if (len == 1)
        {
            var d = denominations[0];

            if (d > amount) return new Set[] { new Set(d, 1) };

            var q = amount % d;
            var dividend = amount / d;
            var n = (q == 0) ? dividend : ++dividend;

            return new Set[] { new Set(d, n) };
        }

        Array.Sort(denominations);

        var sets = new List<Set>();
        var remainingAmount = amount;

        for(int i = len - 1; ((i >= 0) || (remainingAmount == 0)); i--)
        {
            var d = denominations[i];
            var q = remainingAmount % d;
            var dividend = remainingAmount / d;

            
        }

        return sets?.ToArray();
    }
}

public class Set
{
    public Set(int denomination, int numberOfCoins)
    {
        Denomination = denomination;
        NumberOfCoins = numberOfCoins;
    }

    public int Denomination { get; set; }
    public int NumberOfCoins { get; set; }
}