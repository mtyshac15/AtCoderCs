using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC069;

public class ProblemA
{
    private TextReader _reader;
    private TextWriter _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemA();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemA()
    {
        _reader = Console.In;
        _writer = Console.Out;
    }

    public ProblemA(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// K-City
    /// </summary>
    public void Solve()
    {
        var nm = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];

        var ans = (n - 1) * (m - 1);
        _writer.WriteLine(ans);
    }
}
