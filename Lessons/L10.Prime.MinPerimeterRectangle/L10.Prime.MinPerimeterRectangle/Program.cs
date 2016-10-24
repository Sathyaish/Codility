using System;

class Program
{
    static void Main(string[] args)
    {
        Test(1);
        Test(100);
        Test(30);
    }

    public static void Test(int n)
    {
        try
        {
            int result = new Solution().solution(n);
            Console.WriteLine(result);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();
    }
}