namespace OliverJ.AdventOfCode2022.Utils;

public class Input
{
    public Input(string text)
    {
        Text = text;
    }

    public string Text { get; }

    public string[] Lines => Text.Split("\r\n");

    /// <summary>
    /// Separates the file into groups of input lines.
    ///
    /// e.g.
    /// 1
    /// 2
    /// 3
    ///
    /// 4
    /// 5
    ///
    /// becomes: [[1,2,3],[4,5]]
    /// </summary>
    public IList<string[]> LineGroups()
    {
        return Text.Split("\r\n\r\n")
            .Select(x => x.Split("\r\n"))
            .ToList();
    }

    /// <summary>
    /// Separates the file into groups of input lines.
    ///
    /// e.g.
    /// 1,2,3
    /// 4,5
    /// 
    /// becomes: [[1,2,3],[4,5]]
    /// </summary>
    public IList<string[]> GroupPerLine(string separator = ",")
    {
        return Text.Split("\r\n")
            .Select(x => x.Split(separator))
            .ToList();
    }
}