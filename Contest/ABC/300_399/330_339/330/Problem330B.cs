using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC330;

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
    /// Minimize Abs 1
    /// </summary>
    public void Solve()
    {
        var NLR = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NLR[0];
        var L = NLR[1];
        var R = NLR[2];

        var A = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var ansList = new List<int>();
        for (int i = 0; i < N; i++)
        {
            // L <= Ai <= Rのとき、∣Y−Ai|の最小値は0
            var YA = 0;
            if (A[i] < L || A[i] > R)
            {
                YA = Math.Min(Math.Abs(L - A[i]), Math.Abs(R - A[i]));
            }

            // |L-Ai|、|R-Ai|と、|Y-Ai|を比較
            var XL = Math.Abs(L - A[i]);
            var XR = Math.Abs(R - A[i]);

            if (XL <= YA)
            {
                ansList.Add(L);
            }
            else if (XR <= YA)
            {
                ansList.Add(R);
            }
            else
            {
                ansList.Add(A[i]);
            }
        }

        var ans = string.Join(" ", ansList);
        _writer.WriteLine(ans);
    }
}
