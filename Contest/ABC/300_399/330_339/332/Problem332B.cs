using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC332;

public class ProblemB
{
    public static void Main(string[] args)
    {
        var problem = new ProblemB();
        problem.Solve();
    }

    /// <summary>
    /// Glass and Mug
    /// </summary>
    public void Solve()
    {
        var KGM = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var K = KGM[0];
        var G = KGM[1];
        var M = KGM[2];

        var glass = 0;
        var cup = 0;
        for (int i = 0; i < K; i++)
        {
            if (glass == G)
            {
                glass = 0;
            }
            else if (cup == 0)
            {
                cup = M;
            }
            else
            {
                var tmp = Math.Min(cup, G - glass);
                cup -= tmp;
                glass += tmp;
            }
        }

        var ans = string.Join(" ", glass, cup);
        Console.WriteLine(ans);
    }
}
