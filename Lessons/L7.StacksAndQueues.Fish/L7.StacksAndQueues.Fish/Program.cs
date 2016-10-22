using System;

namespace L7.StacksAndQueues.Fish
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //var sizes = new[] { 4, 3, 2, 1, 5 };
                //var direction = new[] { 0, 1, 0, 0, 0 };

                //var sizes = new[] { 5, 3, 4,  };
                //var direction = new[] { 1, 0, 0 };

                //var sizes = new[] { 99, 98, 92, 91, 93 };
                //var direction = new[] { 1, 1, 1, 1, 0 };

                var sizes = new[] { 91, 92 };
                var direction = new[] { 1, 0 };

                var numFishesSurvived = new Solution().solution(sizes, direction);

                Console.WriteLine(numFishesSurvived);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
