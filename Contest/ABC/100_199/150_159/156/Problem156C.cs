using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC156;

public class ProblemC
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemC();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemC()
    {
    }

    public ProblemC(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// Rally
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var X = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var ans = int.MaxValue;

        var min = X.Min();
        var max = X.Max();

        for (int P = min; P <= max; P++)
        {
            var total = 0;
            for (int i = 0; i < N; i++)
            {
                total += (X[i] - P) * (X[i] - P);
            }

            ans = Math.Min(total, ans);
        }

        _writer.WriteLine(ans);
    }
}
