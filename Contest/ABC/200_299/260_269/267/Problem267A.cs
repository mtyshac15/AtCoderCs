using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC267;

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
    /// Saturday
    /// </summary>
    public void Solve()
    {
        var S = _reader.ReadLine().Trim();

        var week = new string[5]
        {
            "Monday","Tuesday","Wednesday","Thursday","Friday"
        };

        var ans = 5 - Array.IndexOf(week, S);
        _writer.WriteLine(ans);
    }
}
