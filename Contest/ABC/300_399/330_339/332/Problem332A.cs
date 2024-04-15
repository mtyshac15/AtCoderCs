using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC332;

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
    /// Online Shopping
    /// </summary>
    public void Solve()
    {
        var NSK = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NSK[0];
        var S = NSK[1];
        var K = NSK[2];

        var total = 0;
        for (int i = 0; i < N; i++)
        {
            var PQ = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            total += PQ[0] * PQ[1];
        }

        var postage = 0;
        if (total < S)
        {
            postage = K;
        }

        var ans = total + postage;
        _writer.WriteLine(ans);
    }
}
