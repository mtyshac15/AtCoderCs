using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC350;

public class ProblemG
{
    private TextReader _reader;
    private TextWriter _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemG();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemG()
    {
        _reader = Console.In;
        _writer = Console.Out;
    }

    public ProblemG(TextReader reader, TextWriter writer)
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
