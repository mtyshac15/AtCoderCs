using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC322;

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
    /// Festival
    /// </summary>
    public void Solve()
    {
        var NM = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NM[0];
        var M = NM[1];

        var A = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var newA = A.Prepend(0).Append(A[M - 1]).ToArray();

        var ansBuilder = new StringBuilder();

        for (int i = 1; i <= N; i++)
        {
            var ok = M;
            var ng = 0;

            while (Math.Abs(ok - ng) > 1)
            {
                var min = Math.Min(ng, ok);
                var max = Math.Max(ng, ok);

                var middle = min + (max - min) / 2;
                if (i <= newA[middle])
                {
                    ok = middle;
                }
                else
                {
                    ng = middle;
                }
            }

            var sub = newA[ok] - i;
            ansBuilder.AppendLine(sub.ToString());
        }

        var ans = ansBuilder.ToString();
        _writer.WriteLine(ans);
    }
}
