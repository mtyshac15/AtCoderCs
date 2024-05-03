using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC092;

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
    /// Traveling Budget
    /// </summary>
    public void Solve()
    {
        var A = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var B = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var C = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var D = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var ans = Math.Min(A, B) + Math.Min(C, D);
        _writer.WriteLine(ans);
    }
}
