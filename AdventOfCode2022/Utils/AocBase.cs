using System.Reflection;

namespace OliverJ.AdventOfCode2022.Utils;

public abstract class AocBase
{
    public void Run(bool testsOnly = false)
    {
        var files = ReadInput(testsOnly).OrderBy(x => x.Name.Contains("Test") ? 0 : 1).ToList();
        Console.WriteLine("*** PART 1 ***");
        foreach (var input in files)
        {
            Console.WriteLine();
            Console.WriteLine($"{input.Name}:");
            Part1(input.Content).Dump();
        }

        Console.WriteLine();
        Console.WriteLine("*** PART 2 ***");
        foreach (var input in files)
        {
            Console.WriteLine();
            Console.WriteLine($"{input.Name}:");
            Part2(input.Content).Dump();
        }
    }

    protected abstract object Part1(string input);
    protected abstract object Part2(string input);

    private IList<(string Name, string Content)> ReadInput(bool testsOnly)
    {
        var resources = Assembly.GetExecutingAssembly().GetManifestResourceNames()
            .Where(n => n.StartsWith(GetType().Namespace))
            .ToList();

        return resources
            .Select(x => new
            {
                Name = x,
                Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(x)
            })
            .Where(x => !testsOnly || x.Name.Contains("Test"))
            .Select(x => (x.Name.Split(".").Last(), new StreamReader(x.Stream).ReadToEnd()))
            .ToList();
    }
}