using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC044;

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
    /// 
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var K = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var X = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var Y = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var first = Math.Min(K, N);
        var second = Math.Max(N - K, 0);

        var ans = first * X + second * Y;
        _writer.WriteLine(ans);
    }
}
