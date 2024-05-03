using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC070;

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
    /// Two Switches
    /// </summary>
    public void Solve()
    {
        var ABCD = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var A = ABCD[0];
        var B = ABCD[1];
        var C = ABCD[2];
        var D = ABCD[3];

        var start = Math.Max(A, C);
        var end = Math.Min(B, D);

        var ans = Math.Max(end - start, 0);
        _writer.WriteLine(ans);
    }
}
