public class Solution
{
    public int solution(int a, int b, int k)
    {
        var d1 = a / k;
        var d2 = b / k;

        var diff = d2 - d1;

        if (a % k == 0) diff++;

        return diff;
    }
}