using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC080;

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
    /// Parking
    /// </summary>
    public void Solve()
    {
        var NAB = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NAB[0];
        var A = NAB[1];
        var B = NAB[2];

        var ans = Math.Min(A * N, B);
        _writer.WriteLine(ans);
    }
}
