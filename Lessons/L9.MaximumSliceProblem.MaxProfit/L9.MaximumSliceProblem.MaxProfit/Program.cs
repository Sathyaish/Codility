using System;

// https://codility.com/media/train/7-MaxSlice.pdf
class Program
{
    static void Main(string[] args)
    {
        Test(null);
        Test(new int[] { });
        Test(new[] { 1 });
        Test(new[] { 0 });
        Test(new[] { int.MinValue });
        Test(new[] { 4, 7, 1, 2, 3, 9, 12 });
        Test(new[] { 23171, 21011, 21123, 21366, 21013, 21367});
    }

    static void Test(int[] array)
    {
        try
        {
            var result = new Solution().solution(array);
            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();
    }
}