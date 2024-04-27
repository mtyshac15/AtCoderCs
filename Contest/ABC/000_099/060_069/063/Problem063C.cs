using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC063;

public class ProblemC
{
    private TextReader _reader;
    private TextWriter _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemC();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemC()
    {
        _reader = Console.In;
        _writer = Console.Out;
    }

    public ProblemC(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// X: Yet Another Die Game
    /// </summary>
    public void Solve()
    {
        var S = _reader.ReadLine().Trim();

        var ans = 0;
        _writer.WriteLine(ans);
    }
}
