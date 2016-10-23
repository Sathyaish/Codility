public class Solution
{
    public int solution(int[] array)
    {
        var leader = -1;
        var candidate = -1;
        int count = 0;
        var size = 0;
        var value = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (size == 0)
            {
                value = array[i];
                size++;
            }
            else if (value != array[i])
                size--;
            else
                size++;
        }
        if (size != 0)
            candidate = value;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == candidate)
                count++;
            if (count > array.Length / 2)
                leader = candidate;
        }


        int lcount = 0;
        var equiLeadersCount = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == leader)
                lcount++;
            var rcount = count - lcount;
            if (lcount > (int)(i + 1) / 2 && rcount > (int)(array.Length - i - 1) / 2)
                equiLeadersCount++;

        }
        return equiLeadersCount;
    }
}