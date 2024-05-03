using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC072;

public class ProblemA
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemA();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemA()
    {
    }

    public ProblemA(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// Sandglass2
    /// </summary>
    public void Solve()
    {
        var Xt = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var X = Xt[0];
        var t = Xt[1];

        var ans = Math.Max(X - t, 0);
        _writer.WriteLine(ans);
    }
}
