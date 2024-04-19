using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC057;

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
    /// 
    /// </summary>
    public void Solve()
    {
        var NM = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NM[0];
        var M = NM[1];

        var a = new int[N];
        var b = new int[N];
        var c = new int[M];
        var d = new int[M];

        for (int i = 0; i < N; i++)
        {
            var ab = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            a[i] = ab[0];
            b[i] = ab[1];
        }

        for (int i = 0; i < M; i++)
        {
            var cd = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            c[i] = cd[0];
            d[i] = cd[1];
        }

        var goal = Enumerable.Repeat(int.MaxValue, N).ToArray();
        var checkPoints = new int[N];

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                var length = Math.Abs(a[i] - c[j]) + Math.Abs(b[i] - d[j]);
                if (length < goal[i])
                {
                    goal[i] = length;
                    checkPoints[i] = j + 1;
                }
            }
        }

        var ans = string.Join(Environment.NewLine, checkPoints);
        _writer.WriteLine(ans);
    }
}
