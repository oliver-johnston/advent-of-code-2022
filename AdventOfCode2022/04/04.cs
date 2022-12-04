using OliverJ.AdventOfCode2022.Utils;

namespace OliverJ.AdventOfCode2022._04;

class _04 : AocBase
{
    protected override object Part1(Input input)
    {
        return input
            .GroupPerLine()
            .Count(l => IsFullOverlap(l[0], l[1]));
    }

    private bool IsFullOverlap(string a, string b)
    {
        (var minA, var maxA) = Parse(a);
        (var minB, var maxB) = Parse(b);

        return minA <= minB && maxA >= maxB
               || minB <= minA && maxB >= maxA;
    }

    private (int minA, int maxA) Parse(string x)
    {
        var split = x.Split("-");
        return (int.Parse(split[0]), int.Parse(split[1]));
    }

    protected override object Part2(Input input)
    {
        return input
            .GroupPerLine()
            .Count(l => IsPartialOverlap(l[0], l[1]));
    }

    private bool IsPartialOverlap(string a, string b)
    {
        (var minA, var maxA) = Parse(a);
        (var minB, var maxB) = Parse(b);

        return minA <= minB && maxA >= minB
               || minA <= maxB && maxA >= maxB
               || minB <= minA && maxB >= minA
               || minB <= maxA && maxB >= maxA;
    }
}