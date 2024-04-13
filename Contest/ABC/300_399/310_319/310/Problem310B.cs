using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC310;

public class ProblemB
{
    public static void Main(string[] args)
    {
        var problem = new ProblemB();
        problem.Solve();
    }

    /// <summary>
    /// Measure
    /// </summary>
    public void Solve()
    {
        var NM = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NM[0];
        var M = NM[1];

        var P = new int[N];
        var C = new int[N];

        var F = new int[N][];

        for (int i = 0; i < N; i++)
        {
            var input = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
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

        Console.WriteLine(ProblemB.ToYesOrNo(ans));
    }

    public static string ToYesOrNo(bool value)
    {
        return value ? $"Yes" : $"No";
    }
}
