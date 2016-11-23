using System;

/*
    For a given set of denominations, you are asked to find the minimum number of coins with
    which a given amount of money can be paid. That problem can be approached by a greedy
    algorithm that always selects the largest denomination not exceeding the remaining amount
    of money to be paid. As long as the remaining amount is greater than zero, the process is
    repeated.
     */
class Program
{
    static void Main(string[] args)
    {
        var denominations = new[] { 2, 5, 10, 20, 50 };
        var amount = 2026;

        var sets = new Solution().solution(denominations, amount);

        Console.WriteLine($"Amount: Rs.{amount}\n");

        var runningTotal = 0L;
        foreach (var set in sets)
        {
            var total = set.NumberOfCoins * set.Denomination;
            runningTotal += total;

            Console.WriteLine($"{set.NumberOfCoins} notes of Rs.{set.Denomination} each = {total}");
        }

        Console.WriteLine("===============================================");
        Console.WriteLine($"TOTAL: Rs. {runningTotal}\n");
    }
}