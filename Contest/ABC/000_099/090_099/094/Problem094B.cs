using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC094;

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
    /// Toll Gates
    /// </summary>
    public void Solve()
    {
        var NMX = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NMX[0];
        var M = NMX[1];
        var X = NMX[2];

        var A = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var left = A.Count(a => a < X);
        var right = A.Count(a => a > X);

        var ans = Math.Min(left, right);
        _writer.WriteLine(ans);
    }
}
