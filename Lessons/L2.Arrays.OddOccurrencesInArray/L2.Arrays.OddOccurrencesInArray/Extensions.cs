using System;

namespace L2.Arrays.OddOccurrencesInArray
{
    public static class Extensions
    {
        public static bool IsOdd(this int n)
        {
            return (n & 1) == 1;
        }

        public static int Find<T>(this T[] array, T elementToFind)
        {
            if (array == null) throw new ArgumentNullException("array");

            return Find<T>(array, elementToFind, 0, array.Length);
        }

        public static int Find<T>(this T[] array, T elementToFind, int startsSearchingAtIndex, int searchTillIndex)
        {
            var len = 0;

            if (array == null) throw new ArgumentNullException("array");

            if ((len = array.Length) == 0) return -1;

            if (startsSearchingAtIndex < 0 
                || startsSearchingAtIndex > searchTillIndex 
                || searchTillIndex >= len)
                throw new ArgumentOutOfRangeException("One or more of the search boundaries are invalid. The index to start the search must be less than or equal to the index to end searching. And the index to end the search must be less than the length of the source array.");

            int start = startsSearchingAtIndex;
            int end = searchTillIndex;

            for (int i = start; i <= end; i++)
                if (array[i].Equals(elementToFind))
                    return i;

            return -1;
        }

        public static void RemoveElementAt<T>(this T[] array, int index)
        {
            if (array == null) throw new ArgumentNullException();

            var len = 0;
            if ((len = array.Length) == 0) return;
            if (index < 0 || index >= len) throw new ArgumentOutOfRangeException("index");

            if (index == len - 1)
            {
                array[len - 1] = default(T);
                return;
            }

            for(int i = index + 1; i < len; i++)
            {
                array[i - 1] = array[i];
            }

            array[len - 1] = default(T);
        }
    }
}