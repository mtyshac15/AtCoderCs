using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC150;

public class ProblemE
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemE();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemE()
    {
    }

    public ProblemE(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void Solve()
    {
        var S = _reader.ReadLine().Trim();

        var ans = 0;
        _writer.WriteLine(ans);
    }
}
