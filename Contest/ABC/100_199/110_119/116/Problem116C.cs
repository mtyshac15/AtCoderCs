using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC116;

public class ProblemC
{
    public static void Main(string[] args)
    {
        var problem = new ProblemC();
        problem.Solve();
    }

    /// <summary>
    /// Grand Garden
    /// </summary>
    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var h = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var ans = h[0];

        for (int i = 1; i < N; i++)
        {
            var subH = h[i] - h[i - 1];
            if (subH > 0)
            {
                ans += subH;
            }
        }

        Console.WriteLine(ans);
    }
}
