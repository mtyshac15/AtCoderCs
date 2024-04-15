using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC116;

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
    /// Right Triangle
    /// </summary>
    public void Solve()
    {
        var input = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var AB = input[0];
        var BC = input[1];
        var CA = input[2];

        var ans = AB * BC / 2;
        _writer.WriteLine(ans);
    }
}
