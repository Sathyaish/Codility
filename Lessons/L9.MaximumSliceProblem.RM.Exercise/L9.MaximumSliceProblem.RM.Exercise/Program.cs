using System;
using System.Linq;

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
        Test(new[] { 4, 7, 1, 2, -3, 9, 12 });
        Test(Enumerable.Repeat<int>(int.MinValue, 10).ToArray());

        // This test takes far too long for solution1 and solution2
        // and causes an OutOfMemoryException for solution3
        // Test(Enumerable.Range(int.MinValue, int.MaxValue).ToArray());
    }

    static void Test(int[] array)
    {
        try
        {
            var result = new Solution().solution3(array);
            Console.WriteLine(result);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();
    }
}