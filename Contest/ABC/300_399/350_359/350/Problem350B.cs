using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC350;

public class ProblemB
{
    private TextReader _reader;
    private TextWriter _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemB();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemB()
    {
        _reader = Console.In;
        _writer = Console.Out;
    }

    public ProblemB(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void Solve()
    {
        var NQ = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NQ[0];
        var Q = NQ[1];

        var T = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var teeth = Enumerable.Repeat(1, N).ToArray();

        for (int i = 0; i < Q; i++)
        {
            teeth[T[i] - 1] = 1 - teeth[T[i] - 1];
        }

        var ans = teeth.Sum();
        _writer.WriteLine(ans);
    }
}
