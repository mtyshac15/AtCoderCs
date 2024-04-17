using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC050;

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
    /// Contest with Drinks Easy
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var T = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var M = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var P = new int[M];
        var X = new int[M];

        for (int i = 0; i < M; i++)
        {
            var PX = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            P[i] = PX[0];
            X[i] = PX[1];
        }

        var ansBuilder = new StringBuilder();

        var total = T.Sum();

        for (int i = 0; i < M; i++)
        {
            var time = total - T[P[i] - 1] + X[i];
            ansBuilder.AppendLine(time.ToString());
        }

        var ans = ansBuilder.ToString();
        _writer.WriteLine(ans);
    }
}
