using System;

namespace L8.Leader.Dominator
{
    class Program
    {
        static void Main(string[] args)
        {
            Test(null);
            Test(new int[] { });
            Test(new[] { 1 });
            Test(new[] { 1, 2 });
            Test(new[] { 1, 1 });
            Test(new[] { 1, 2, 3, 3, 2, 3, 1, 3, 3, 1, 3 });
            Test(new[] { 3, 4, 3, 2, 3, -1, 3, 3 });
            Test(new[] { 0, 0, 1, 1, 1 });
            Test(new[] { 1, 2, 3, 4, 4, 4 });
        }

        static void Test(int[] array)
        {
            try
            {
                Console.WriteLine();
                var result = new Solution().solution(array);
                Console.WriteLine(result);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
