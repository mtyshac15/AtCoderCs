using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC332;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// Online Shopping
    /// </summary>
    public void Solve()
    {
        var NSK = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NSK[0];
        var S = NSK[1];
        var K = NSK[2];

        var total = 0;
        for (int i = 0; i < N; i++)
        {
            var PQ = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            total += PQ[0] * PQ[1];
        }

        var postage = 0;
        if (total < S)
        {
            postage = K;
        }

        var ans = total + postage;
        Console.WriteLine(ans);
    }
}
