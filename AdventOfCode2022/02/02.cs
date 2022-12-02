using OliverJ.AdventOfCode2022.Utils;

namespace OliverJ.AdventOfCode2022._02;

class _02 : AocBase
{
    protected override object Part1(string input)
    {
        var value = new Dictionary<string, int>
        {
            { "A", 0 },
            { "B", 1 },
            { "C", 2 },
            { "X", 0 },
            { "Y", 1 },
            { "Z", 2 },
        };

        return input.Split("\r\n")
            .Select(x => x.Split(" "))
            .Select(x => (Theirs: value[x[0]], Mine: value[x[1]]))
            .Select(x => Score(x.Theirs, x.Mine))
            .Sum();
    }

    protected override object Part2(string input)
    {
        var value = new Dictionary<string, int>
        {
            { "A", 0 },
            { "B", 1 },
            { "C", 2 },
        };

        return input.Split("\r\n")
            .Select(x => x.Split(" "))
            .Select(x => (Theirs: value[x[0]], Mine: GetMove(value[x[0]], x[1])))
            .Select(x => Score(x.Theirs, x.Mine))
            .Sum();
    }

    private int GetMove(int theirs, string instruction)
    {
        return instruction switch
        {
            "X" => (theirs + 2) % 3,
            "Y" => theirs,
            "Z" => (theirs + 1) % 3,
        };
    }

    private int Score(int theirs, int mine)
    {
        var score = mine + 1;
        if (theirs == mine)
        {
            score += 3;
        }
        else if (mine == (theirs + 1) % 3)
        {
            score += 6;
        }

        return score;
    }
}