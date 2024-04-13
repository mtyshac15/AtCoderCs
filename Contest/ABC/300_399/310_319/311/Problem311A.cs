using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC311;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// First ABC
    /// </summary>
    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var S = Console.ReadLine().Trim();

        var set = new HashSet<int>();
        var ans = 1;

        for (int i = 0; i < N; i++)
        {
            set.Add(S[i]);
            if (set.Count == 3)
            {
                ans = i + 1;
                break;
            }
        }

        Console.WriteLine(ans);
    }
}
