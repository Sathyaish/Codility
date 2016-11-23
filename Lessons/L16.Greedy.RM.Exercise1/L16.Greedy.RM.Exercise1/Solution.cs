using System;
using System.Collections.Generic;

public class Solution
{
    public Set[] solution(int[] denominations, int amount)
    {
        if (denominations == null)
            throw new ArgumentNullException("denominations");

        var len = denominations.Length;

        Array.Sort(denominations);

        var sets = new List<Set>();
        var remainingAmount = amount;

        for(int i = len - 1; ((i >= 0) && (remainingAmount > 0)); i--)
        {
            var d = denominations[i];
            if (d == 0) break;
            var dividend = remainingAmount / d;
            remainingAmount = remainingAmount % d;

            sets.Add(new Set(d, dividend));
        }

        if (remainingAmount > 0)
            sets[len - 1].NumberOfCoins++;

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