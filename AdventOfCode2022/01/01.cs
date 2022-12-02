using OliverJ.AdventOfCode2022.Utils;

namespace OliverJ.AdventOfCode2022._01;

class _01 : AocBase
{
    protected override object Part1(string input)
    {
        return input.Split("\r\n\r\n")
            .Select(g => g.Split("\r\n").Sum(int.Parse))
            .Max();
    }

    protected override object Part2(string input)
    {
        return input.Split("\r\n\r\n")
            .Select(g => g.Split("\r\n").Sum(int.Parse))
            .OrderByDescending(x => x)
            .Take(3)
            .Sum();
    }
}

