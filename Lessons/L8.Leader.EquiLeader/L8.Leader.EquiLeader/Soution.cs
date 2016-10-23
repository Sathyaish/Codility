using System;

public class Solution
{
    public int solution(int[] array)
    {
        // null array
        if (array == null)
            throw new ArgumentNullException("array");

        var len = array.Length;

        // empty array, single element array
        if (len <= 1) return 0;

        // more than one element
        var leader = FindLeader(array);

        if (leader == null) return 0;

        var lCount = 0;
        var rCount = 0;
        var eCount = 0;
        for(int i = 0; i < len; i++)
        {
            if (array[i] == leader.Value)
                lCount++;

            rCount = leader.Count - lCount;

            if (lCount > ((i + 1) / 2) && rCount > (len - i - 1) / 2)
                eCount++;
        }
        return eCount;
    }

    static Leader FindLeader(int[] array)
    {
        // For an explanation of what's going on here
        // see L8.Leader.Dominator::Solution.solution3()
        var len = array.Length;
        var size = 0;
        var value = 0;
        for(int i = 0; i < len; i++)
        {
            if (size == 0)
            {
                value = array[i];
                size++;
            }
            else
            {
                if (array[i] != value)
                {
                    size--;
                }
                else
                {
                    size++;
                }
            }
        }

        int? candidate = null;

        if (size == 0)
            return null;
        else
            candidate = value;

        var n = 0;

        // Verify
        for (int i = 0; i < len; i++)
        {
            if (array[i] == candidate)
                n++;
        }

        return (n > (len / 2)) ? new Leader(candidate.Value, n) : null;
    }
}

public class Leader
{
    public Leader(int value, int count)
    {
        Value = value;
        Count = count;
    }

    public int Value { get; set; }
    public int Count { get; set; }
}