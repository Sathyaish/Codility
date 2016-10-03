using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace L2.Arrays.OddOccurrencesInArray
{
    // https://codility.com/programmers/task/odd_occurrences_in_array/
    // Lesson 2: Arrays
    // OddOccurrencesInArray
    // Find value that occurs in odd number of elements.

    // A non-empty zero-indexed array A consisting of N integers 
    // is given. The array contains an odd number of elements, 
    // and each element of the array can be paired with another 
    // element that has the same value, except for one element 
    // that is left unpaired.

    // For example, in array A such that:
    //   A[0] = 9  A[1] = 3  A[2] = 9
    //   A[3] = 3  A[4] = 9  A[5] = 7
    //   A[6] = 9

    //         the elements at indexes 0 and 2 have value 9,
    //         the elements at indexes 1 and 3 have value 3,
    //         the elements at indexes 4 and 6 have value 9,
    //         the element at index 5 has value 7 and is unpaired.

    // Write a function:

    //     int solution(int A[], int N);

    // that, given an array A consisting of N integers fulfilling 
    // the above conditions, returns the value of the unpaired element.

    // For example, given array A such that:
    //   A[0] = 9  A[1] = 3  A[2] = 9
    //   A[3] = 3  A[4] = 9  A[5] = 7
    //   A[6] = 9

    // the function should return 7, as explained in the example above.


    // I recall that this is the same as the HackerRank Lonely Integer problem:
    // https://github.com/Sathyaish/HackerRank/tree/master/LonelyInteger

    class Program
    {
        static void Main(string[] args)
        {
            var array = GetUserInput();
            var len = 0;

            if (array == null || (len = array.Length) == 0) return;

            var unpaired = new Solution().solution(array);

            array.Print(leadingMessage: "\nInput: ");
            Console.WriteLine($"Unpaired integer: {unpaired}");
            
            Console.ReadKey();
        }
        
        private static int[] GetUserInput()
        {
            var s =
                @"* Consider an array of integers where all but one of the integers 
* occur in pairs. In other words, every element in occurs exactly 
* twice except for one unique element.
* Find and print the unique element.";

            Console.WriteLine("The premise of this problem is as follows:\n");
            Console.WriteLine(s);

            Console.WriteLine("\nType in a bunch of numbers conforming to the array pattern described above, each number separated by a space:\n");

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
