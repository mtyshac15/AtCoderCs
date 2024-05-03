using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC092;

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
    /// Chocolate
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var DX = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var D = DX[0];
        var X = DX[1];

        var A = new int[N];
        for (int i = 0; i < N; i++)
        {
            A[i] = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        }

        var ans = X;
        for (int i = 0; i < N; i++)
        {
            ans++;
            var day = 1;
            while (true)
            {
                day += A[i];
                if (day <= D)
                {
                    ans++;
                }
                else
                {
                    break;
                }
            }
        }

        _writer.WriteLine(ans);
    }
}
