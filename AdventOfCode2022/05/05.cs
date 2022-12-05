using System.Text.RegularExpressions;
using OliverJ.AdventOfCode2022.Utils;

namespace OliverJ.AdventOfCode2022._05;

class _05 : AocBase
{
    protected override object Part1(Input input)
    {
        var layout = ParseLayout(input.LineGroups()[0]);
        var moves = ParseMoves(input.LineGroups()[1]).Dump();
        ApplyMoves(layout, moves);

        return string.Join("", layout.OrderBy(x => x.Key).Select(x => x.Value.First()));
    }

    private void ApplyMoves(Dictionary<int, Stack<char>> layout, IList<(int Quantity, int From, int To)> moves)
    {
        foreach (var move in moves)
        {
            for (int i = 0; i < move.Quantity; i++)
            {
                var c = layout[move.From].Pop();
                layout[move.To].Push(c);
            }
        }
    }

    private IList<(int Quantity, int From, int To)> ParseMoves(string[] lines)
    {
        var regex = new Regex("move ([0-9]+) from ([0-9])+ to ([0-9]+)");
        return lines.Select(l => regex.Match(l).Groups)
            .Select(m => (int.Parse(m[1].Value), int.Parse(m[2].Value), int.Parse(m[3].Value)))
            .ToList();
    }

    private Dictionary<int, Stack<char>> ParseLayout(IList<string> lines)
    {
        var stacks = new Dictionary<int, Stack<char>>();

        lines = lines.Reverse().ToList();
        stacks = lines[0].Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToDictionary(int.Parse, x => new Stack<char>());

        foreach (var line in lines.Skip(1))
        {
            foreach (var i in stacks.Keys)
            {
                var c = line[((i - 1) * 4) + 1];
                if (c != ' ')
                {
                    stacks[i].Push(c);
                }
            }
        }

        return stacks;
    }

    protected override object Part2(Input input)
    {
        var layout = ParseLayout(input.LineGroups()[0]);
        var moves = ParseMoves(input.LineGroups()[1]).Dump();
        ApplyMoves_9001(layout, moves);

        return string.Join("", layout.OrderBy(x => x.Key).Select(x => x.Value.First()));
    }

    private void ApplyMoves_9001(Dictionary<int, Stack<char>> layout, IList<(int Quantity, int From, int To)> moves)
    {
        foreach (var move in moves)
        {
            var substack = new Stack<char>();
            for (int i = 0; i < move.Quantity; i++)
            {
                var c = layout[move.From].Pop();
                substack.Push(c);
            }

            foreach (var c in substack)
            {
                layout[move.To].Push(c);
            }
        }
    }
}