using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC058;

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
    /// ∵∴∵
    /// </summary>
    public void Solve()
    {
        var O = _reader.ReadLine().Trim();
        var E = _reader.ReadLine().Trim();

        var zip = O.Zip(E.Append(' '), (o, e) => string.Concat(o, e));
        var ans = string.Concat(zip).Trim();
        _writer.WriteLine(ans);
    }
}
