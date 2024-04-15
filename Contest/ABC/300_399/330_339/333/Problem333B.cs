using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC333;

public class ProblemB
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemB();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemB()
    {
    }

    public ProblemB(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
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
