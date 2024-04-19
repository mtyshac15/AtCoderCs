using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC056;

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
    /// NarrowRectanglesEasy
    /// </summary>
    public void Solve()
    {
        var Wab = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var W = Wab[0];
        var a = Wab[1];
        var b = Wab[2];

        var ans = Math.Max(Math.Abs(b - a) - W, 0);
        _writer.WriteLine(ans);
    }
}
