using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC317;

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
    /// MissingNo.
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var A = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var sumA = A.Sum();

        //端の数はなくした整数ではない
        var min = A.Min();
        var max = A.Max();

        // minからmaxまでの和
        var sum = (min + max) * (N + 1) / 2;
        var ans = sum - sumA;
        _writer.WriteLine(ans);
    }
}
