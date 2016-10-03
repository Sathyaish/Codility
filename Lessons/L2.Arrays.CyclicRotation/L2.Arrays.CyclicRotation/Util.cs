using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2.Arrays.CyclicRotation
{
    public class Util
    {
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

            for (int i = len - r - 1; i >= 0; i--)
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

            for (int i = len - r, counter = 0; i < len; i++, counter++)
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
    }
}
