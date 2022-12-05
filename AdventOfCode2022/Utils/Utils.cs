using System.Collections;

namespace OliverJ.AdventOfCode2022.Utils;

public static class Utils
{
    public static T Dump<T>(this T o)
    {
        if (o is IEnumerable && o is not string)
        {
            foreach (var i in (IEnumerable)o)
            {
                i.Dump();
            }
        }
        else
        {
            Console.WriteLine(o);
        }

        return o;
    }
}