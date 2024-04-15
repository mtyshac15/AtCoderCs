using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace AtCoderCs.Contest.ABC317;

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
    /// Potions
    /// </summary>
    public void Solve()
    {
        var NHX = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NHX[0];
        var H = NHX[1];
        var X = NHX[2];

        var P = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var ans = 0;
        for (int i = 0; i < N; i++)
        {
            if (H + P[i] >= X)
            {
                ans = i + 1;
                break;
            }
        }

        _writer.WriteLine(ans);
    }
}
