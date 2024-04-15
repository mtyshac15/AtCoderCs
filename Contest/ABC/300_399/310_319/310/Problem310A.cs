using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC310;

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
    /// Order Something Else
    /// </summary>
    public void Solve()
    {
        var NPQ = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var M = NPQ[0];
        var P = NPQ[1];
        var Q = NPQ[2];

        var D = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var ans = Math.Min(P, Q + D.Min());
        _writer.WriteLine(ans);
    }
}
