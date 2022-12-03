using OliverJ.AdventOfCode2022.Utils;

namespace OliverJ.AdventOfCode2022._03;

class _03 : AocBase
{
    protected override object Part1(Input input)
    {
        var rucksacks = input.Lines;
        return rucksacks.Select(GetDuplicate)
            .Sum(GetPriority);
    }

    private int GetPriority(char c)
    {
        if (c is >= 'a' and <= 'z')
        {
            return c - 'a' + 1;
        }

        return c - 'A' + 27;
    }

    private char GetDuplicate(string rucksack)
    {
        var first = rucksack.Substring(0, rucksack.Length / 2);
        var second = rucksack.Substring(rucksack.Length / 2);
        return first.Intersect(second).Single();
    }

    protected override object Part2(Input input)
    {
        return input.Lines
            .Select((r, i) => new { Index = i, Rucksack = r })
            .GroupBy(x => x.Index / 3)
            .Select(g => GetDuplicate(g.Select(x => x.Rucksack).ToList()))
            .Sum(GetPriority);
    }

    private char GetDuplicate(IList<string> rucksacks)
    {
        var set = rucksacks.First().ToHashSet();
        foreach (var r in rucksacks.Skip(1))
        {
            set.IntersectWith(r);
        }

        return set.Single();
    }
}