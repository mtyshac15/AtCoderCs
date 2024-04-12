using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC150;

public class ProblemB
{
    public static void Main(string[] args)
    {
        var problem = new ProblemB();
        problem.Solve();
    }

    /// <summary>
    /// Count ABC
    /// </summary>
    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var S = Console.ReadLine().Trim();

        var target = "ABC";

        var ans = 0;

        for (int i = 0; i < N - target.Length + 1; i++)
        {
            var str = string.Join("", S[i], S[i + 1], S[i + 2]);
            if (str == target)
            {
                ans++;
            }
        }

        Console.WriteLine(ans);
    }
}
