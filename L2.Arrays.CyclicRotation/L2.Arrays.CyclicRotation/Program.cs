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
                var newArray = UsingExtraMemoryUsingLINQ(array, len, i);
                newArray.Print(leadingMessage: string.Format($"Rotated {i} times: "));
            }
        }

        private static void TestUsingExtraMemory(int[] array, int len)
        {
            array.Print(leadingMessage: "\nOriginal array: ");
            Console.WriteLine("ROTATED USING EXTRA MEMORY:");

            for (int i = 0; i <= 2 * len; i++)
            {
                var newArray = UsingExtraMemory(array, len, i);
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

                InPlace(rotatable, len, i);
                rotatable.Print(leadingMessage: string.Format($"Rotated {i} times: "));
            }
        }

        public static void InPlace(int[] array, int len, int rotateTimes)
        {
            if (array == null) throw new ArgumentNullException();
            if (len < 0) throw new ArgumentOutOfRangeException();
            if (len <= 1) return;

            var r = rotateTimes % len;
            if (r == 0) return;

            // This is the only extra bit of memory whose usage
            // is inevitable
            var prefix = array.Copy(len - r, len - 1);

            for(int i = len - r - 1; i >= 0; i--)
            {
                array[i + r] = array[i];
            }
            
            for (int i = 0; i < r; i++)
            {
                array[i] = prefix[i];
            }
        }

        public static int[] UsingExtraMemory(int[] array, int len, int rotateTimes)
        {
            if (array == null) throw new ArgumentNullException();
            if (len < 0) throw new ArgumentOutOfRangeException();
            if (len <= 1) return array.Copy();

            var r = rotateTimes % len;
            if (r == 0) return array.Copy();

            var newArray = new int[len];

            for(int i = len - r, counter = 0; i < len; i++, counter++)
            {
                newArray[counter] = array[i];
            }

            for (int i = r; i < len; i++)
            {
                newArray[i] = array[i - r];
            }

            return newArray;
        }

        public static int[] UsingExtraMemoryUsingLINQ(int[] array, int len, int rotateTimes)
        {
            if (array == null) throw new ArgumentNullException();
            if (len < 0) throw new ArgumentOutOfRangeException();
            if (len <= 1) return array.Copy();

            var r = rotateTimes % len;
            if (r == 0) return array.Copy();

            return array.Skip(len - r)
                .Take(r)
                .Concat(array.Take(len - r))
                .ToArray();
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