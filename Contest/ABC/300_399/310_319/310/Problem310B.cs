using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC310;

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
    /// Measure
    /// </summary>
    public void Solve()
    {
        var NM = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NM[0];
        var M = NM[1];

        var P = new int[N];
        var C = new int[N];

        var F = new int[N][];

        for (int i = 0; i < N; i++)
        {
            var input = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            P[i] = input[0];
            C[i] = input[1];
            F[i] = input.Skip(2).ToArray();
        }

        var ans = false;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (i != j)
                {
                    var isHigher = P[i] >= P[j];

                    for (int c = 0; c < C[i]; c++)
                    {
                        isHigher = isHigher & F[j].Contains(F[i][c]);
                    }

                    var sub = F[j].Except(F[i]);
                    isHigher = isHigher & (P[i] > P[j] || sub.Any());

                    if (isHigher)
                    {
                        ans = isHigher;
                        break;
                    }
                }
            }

            if (ans)
            {
                break;
            }
        }

        _writer.WriteLine(IOLibrary.ToYesOrNo(ans));
    }

    public static class IOLibrary
    {
        public static string ToYesOrNo(bool value)
        {
            return value ? $"Yes" : $"No";
        }
    }
}
