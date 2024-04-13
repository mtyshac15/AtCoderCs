using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace AtCoderCs.Contest.ABC317;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// Potions
    /// </summary>
    public void Solve()
    {
        var NHX = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NHX[0];
        var H = NHX[1];
        var X = NHX[2];

        var P = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var ans = 0;
        for (int i = 0; i < N; i++)
        {
            if (H + P[i] >= X)
            {
                ans = i + 1;
                break;
            }
        }

        Console.WriteLine(ans);
    }
}
