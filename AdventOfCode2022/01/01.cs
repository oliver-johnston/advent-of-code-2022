using OliverJ.AdventOfCode2022.Utils;

namespace OliverJ.AdventOfCode2022._01;

class _01 : AocBase
{
    protected override object Part1(Input input)
    {
        return input.LineGroups()
            .Select(line => line.Sum(int.Parse))
            .Max();
    }

    protected override object Part2(Input input)
    {
        return input.LineGroups()
            .Select(line => line.Sum(int.Parse))
            .OrderByDescending(x => x)
            .Take(3)
            .Sum();
    }
}