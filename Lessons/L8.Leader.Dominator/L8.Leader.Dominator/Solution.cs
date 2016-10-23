using System;

public class Solution
{
    // 100 %, 100 %
    public int solution(int[] array)
    {
        // null array
        if (array == null)
            throw new ArgumentNullException("array");

        var len = array.Length;

        // empty array
        if (len == 0) return -1;

        // single element array
        if (len == 1) return 0;

        // two element array
        if (len == 2) return (array[0] == array[1] ? 0 : -1);

        var copy = new int[len];
        Array.Copy(array, copy, len);
        Array.Sort(copy);

        var candidate = copy[len / 2];
        var candidateIndex = -1;
        var n = 0;

        // Verify
        for (int i = 0; i < len; i++)
        {
            if (array[i] == candidate)
            {
                if (candidateIndex == -1)
                    candidateIndex = i;

                n++;
            }
        }

        if (n > (len / 2)) return candidateIndex;

        return -1;
    }

    // 90 %, 100 %
    // This stack based solution, though more time efficient
    // than the sorting solution as embodied in solution(), 
    // has a bug. It doesn't work for a corner case where
    // there is no leader and an element appears exactly 
    // n / 2 times. For e.g. { 1, 2, 3, 4, 4, 4 }
    public int solution2(int[] array)
    {
        // null array
        if (array == null)
            throw new ArgumentNullException("array");

        var len = array.Length;

        // empty array
        if (len == 0) return -1;

        // single element array
        if (len == 1) return 0;

        // two element array
        if (len == 2) return (array[0] == array[1] ? 0 : -1);

        var stack = new int[len];
        var curr = -1;
        stack[++curr] = array[0];

        for (int i = 1; i < len; i++)
        {
            stack[++curr] = array[i];

            if (curr < 1) continue;

            if (stack[curr] != stack[curr - 1]) curr -= 2;
        }

        if (curr < 0) return -1;

        var n = 1;
        var stackLen = curr + 1;
        var candidate = stack[curr];
        while (--curr >= 0)
        {
            if (stack[curr] == candidate) n++;
        }

        if (n > (stackLen / 2))
        {
            for (int i = 0; i <= len / 2; i++)
                if (array[i] == candidate)
                    return i;
        }

        return -1;
    }

    // 100 %, 100 %
    // From someone else from comments
    // but I am doing this on my own
    // after understanding their code
    // and stepping through it
    // See L8.Leader.Dominator.SomeoneElses
    // This uses the Stack solution but without
    // actually creating memory for a separate
    // stack. It uses just a counter as the 
    // stack size. This is also how, I have 
    // now understood, the reading material
    // suggested we solve this using the stack
    // approach, which I never understood so
    // I had written by own version in solution2
    // which allocates memory for another stack.
    public int solution3(int[] array)
    {
        // null array
        if (array == null)
            throw new ArgumentNullException("array");

        var len = array.Length;

        // empty array
        if (len == 0) return -1;

        // single element array
        if (len == 1) return 0;

        // two element array
        if (len == 2) return (array[0] == array[1] ? 0 : -1);

        // Size of the stack
        var size = 0;

        // Value on the stack
        var value = 0;

        // More than two element array
        for (int i = 0; i < len; i++)
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
                    // If the element at this index
                    // is not the same as value, then
                    // remove the element on the stack.
                    size--;
                }
                else
                {
                    // This element is the same as value
                    // so no need to update value. Just assume
                    // that this also went on the stack and so
                    // we increase the stack size. Now the stack
                    // has only values that are only this value.
                    // And it has 'size' number of values.
                    size++;
                }
            }
        }

        int? candidate = null;
        // At the end of the above loop, now we have
        // only the candidate element in the stack
        // 'size' times.
        if (size > 0)
            candidate = value;
        else
            return -1;

        // Verify if the candidate is actually
        // the leader
        // Number of times the candidate occurs
        var n = 0;
        var firstOccuranceOfCandidateAtIndex = -1;
        for (int i = 0; i < len; i++)
        {
            if (array[i] == candidate)
            {
                // Just in case a question wants to know
                // the index as well.
                // If they don't, then this variable and this
                // if condition is not necessary.
                // Since this problem needs any one of
                // the indices of the leader returned
                // this is necessary.
                if (firstOccuranceOfCandidateAtIndex == -1)
                    firstOccuranceOfCandidateAtIndex = i;

                n++;
            }

            if (n > (len / 2))
                return firstOccuranceOfCandidateAtIndex;
        }

        return -1;
    }
}