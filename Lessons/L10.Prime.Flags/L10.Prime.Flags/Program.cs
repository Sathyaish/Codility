using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // The example they have provided
        Test(new[] { 1, 5, 3, 4, 3, 4, 1, 2, 3, 4, 6, 2 });

        // Empty
        Test(new int[] { });

        // Single element
        Test(new[] { 1 });

        // Two element
        Test(new[] { 1, 1 });
        Test(new[] { 1, 2 });
        Test(new[] { 2, 1 });

        // Three element simple case with a peak
        Test(new[] { 1, 3, 2 });

        // Three element simple case with no peaks
        Test(new[] { 1, 2, 3 });

        // 100 element with no peaks
        Test(Enumerable.Range(100, 100).ToArray());

        // 20 element with maximum number of peaks
        Test(new[] { 4, 7, 6, 11, 2, 9, 4, 12, 1, 100, 92, 93, 0, 5, 4, 8, 2, 10, 9, 11 });

        // A series from the lowest possible to the largest possible element
        Test(Enumerable.Range(1, 400000 - 1).ToArray());

        // Max number of elements of largest possible values with no peaks
        
        // Max number of elements of largest possible values and maximum peaks

        // Max number of elements of largest possible values with only 1 peak
    }

    public static void Test(int[] array)
    {
        try
        {
            int result = new Solution().solution(array);
            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();
    }
}