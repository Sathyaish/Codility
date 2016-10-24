using System;

class Program
{
    static void Main(string[] args)
    {
        Test(100);
        Test(24);
        Test(0);
    }

    static void Test(int n)
    {
        try
        {
            var result = new Solution().solution(n);
            Console.WriteLine(result);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();
    }
}