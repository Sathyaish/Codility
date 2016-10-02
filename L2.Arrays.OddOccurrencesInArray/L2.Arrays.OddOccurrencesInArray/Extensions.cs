using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace L2.Arrays.OddOccurrencesInArray
{
    public static class Extensions
    {
        public static void Print<T>(this IEnumerable<T> source,
            TextWriter writer = null,
            string separator = ", ",
            string leadingMessage = null,
            bool newLineAfterSequence = true,
            bool throwOnEmptySource = true,
            string emptySequenceMessage = "No items to print.",
            string bracket = "[]")
        {
            TextWriter w = writer ?? Console.Out;
            IEnumerable<string> mutated = null;
            var count = 0;
            var builder = new StringBuilder();
            string openingBracket = null;
            string closingBracket = null;

            if (source == null || source.Count() == 0)
            {
                if (throwOnEmptySource) throw new ArgumentNullException("source");

                emptySequenceMessage.Print(w, newLineAfterSequence);
                return;
            }

            if (bracket != null && bracket.Length != 2)
            {
                throw new ArgumentException("Invalid bracket");
            }

            openingBracket = bracket[0].ToString();
            closingBracket = bracket[1].ToString();

            count = source.Count();
            if (count == 1)
            {
                builder.AppendFormat($"{leadingMessage}{openingBracket}{source.First()?.ToString()}{closingBracket}");
                builder.ToString().Print(w, newLineAfterSequence);
                return;
            }

            mutated = source.Take(count - 1)
                .Select(item => string.Format($"{item.ToString()}{separator}"))
                .Concat(Enumerable.Repeat(source.Last().ToString(), 1));

            var s = string.Concat(leadingMessage, openingBracket,
                mutated.Aggregate((current, next) => string.Format($"{current}{next}")),
                closingBracket,
                (newLineAfterSequence ? Environment.NewLine : null));

            s.Print(w, false);
            return;
        }

        public static void Print(this string s, TextWriter writer, bool newLine = true)
        {
            if (s == null) throw new ArgumentNullException("s");

            if (newLine) writer.WriteLine(s); else writer.Write(s);
        }

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
