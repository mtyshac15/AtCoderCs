using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC322;

public class ProblemC
{
    public static void Main(string[] args)
    {
        var problem = new ProblemC();
        problem.Solve();
    }

    /// <summary>
    /// Festival
    /// </summary>
    public void Solve()
    {
        var NM = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NM[0];
        var M = NM[1];

        var A = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
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
        Console.WriteLine(ans);
    }
}
