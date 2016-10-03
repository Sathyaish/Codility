using System;
using System.Collections.Generic;
using System.Linq;

namespace L2.Arrays.CyclicRotation
{
    // https://codility.com/programmers/task/cyclic_rotation/
    // Lesson 2: Arrays
    // Task: CyclicRotation
    // Rotate an array to the right by a given number of steps.

    // A zero-indexed array A consisting of N integers is given. 
    // Rotation of the array means that each element is shifted right 
    // by one index, and the last element of the array is also moved 
    // to the first place.

    // For example, the rotation of array A = [3, 8, 9, 7, 6] is 
    // [6, 3, 8, 9, 7]. The goal is to rotate array A K times; that is, 
    // each element of A will be shifted to the right by K indexes.

    // Write a function:

    //     public int[] solution(int A[], int N, int K);

    // that, given a zero-indexed array A consisting of N integers and an 
    // integer K, returns the array A rotated K times.

    // For example, given array A = [3, 8, 9, 7, 6] and K = 3, the function 
    // should return [9, 7, 6, 3, 8].

    // Assume that:

    //         N and K are integers within the range [0..100];
    //         each element of array A is an integer within the range [−1,000..1,000].
    class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { 8, 7, 9, 6, 3 };
            var len = array.Length;

            TestInPlace(array, len);
            TestUsingExtraMemory(array, len);
            TestUsingExtraMemoryUsingLINQ(array, len);

            Console.ReadKey();
        }

        private static void TestUsingExtraMemoryUsingLINQ(int[] array, int len)
        {
            array.Print(leadingMessage: "\nOriginal array: ");
            Console.WriteLine("ROTATED USING EXTRA MEMORY USING LINQ OPERATORS:");

            for (int i = 0; i <= 2 * len; i++)
            {
                var newArray = Util.UsingExtraMemoryUsingLINQ(array, len, i);
                newArray.Print(leadingMessage: string.Format($"Rotated {i} times: "));
            }
        }

        private static void TestUsingExtraMemory(int[] array, int len)
        {
            array.Print(leadingMessage: "\nOriginal array: ");
            Console.WriteLine("ROTATED USING EXTRA MEMORY:");

            for (int i = 0; i <= 2 * len; i++)
            {
                var newArray = Util.UsingExtraMemory(array, len, i);
                newArray.Print(leadingMessage: string.Format($"Rotated {i} times: "));
            }
        }

        private static void TestInPlace(int[] array, int len)
        {
            array.Print(leadingMessage: "\nOriginal array: ");
            Console.WriteLine("USING IN PLACE ROTATION:");

            // Since this is an in-place rotation, I will
            // need a copy of the original array to pass
            // it to each test iteration
            for(int i = 0; i <= 2 * len; i++)
            {
                var rotatable = array.Copy();

                Util.InPlace(rotatable, len, i);
                rotatable.Print(leadingMessage: string.Format($"Rotated {i} times: "));
            }
        }
        
        private static int[] GetUserInput()
        {
            Console.WriteLine("This program rotates the elements of an array to the right N times: \n");
            Console.WriteLine("\nType in a bunch of numbers to make up an array, each number separated by a space:\n");

            var list = new List<int>();

            Console.ReadLine().Split()
                .ToList()
                .ForEach(t =>
                {
                    int n = 0;
                    var b = int.TryParse(t, out n);
                    if (b) list.Add(n);
                });

            if (list.Count == 0) return null;

            return list.ToArray();
        }
    }
}