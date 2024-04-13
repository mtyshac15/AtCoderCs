using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC311;

public class ProblemB
{
    public static void Main(string[] args)
    {
        var problem = new ProblemB();
        problem.Solve();
    }

    /// <summary>
    /// Vacation Together
    /// </summary>
    public void Solve()
    {
        var ND = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = ND[0];
        var D = ND[1];

        var S = new string[N];
        for (int i = 0; i < N; i++)
        {
            S[i] = Console.ReadLine().Trim();
        }

        var ans = 0;
        var count = 0;
        for (int i = 0; i < D; i++)
        {
            var isFree = true;
            for (int j = 0; j < N; j++)
            {
                if (S[j][i] != 'o')
                {
                    isFree = false;
                    count = 0;
                    break;
                }
            }

            if (isFree)
            {
                count++;
                ans = Math.Max(count, ans);
            }
        }

        Console.WriteLine(ans);
    }
}
