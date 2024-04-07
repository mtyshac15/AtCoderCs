using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC333;

public class ProblemB
{
    public static void Main(string[] args)
    {
        var problem = new ProblemB();
        problem.Solve();
    }

    /// <summary>
    /// Pentagon
    /// </summary>
    public void Solve()
    {
        var S = Console.ReadLine().Trim();
        var T = Console.ReadLine().Trim();

        var adjust = new string[]
        {
            "AB", "BA",
            "BC", "CB",
            "CD", "DC",
            "DE", "ED",
            "EA", "AE",
        };

        var ans = false;
        if (adjust.Contains(S) && adjust.Contains(T)
            || !adjust.Contains(S) && !adjust.Contains(T))
        {
            ans = true;
        }

        Console.WriteLine(ProblemB.ToYesOrNo(ans));
    }

    public static string ToYesOrNo(bool value)
    {
        return value ? $"Yes" : $"No";
    }
}
