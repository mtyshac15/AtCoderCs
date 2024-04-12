using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC322;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// First ABC 2
    /// </summary>
    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var S = Console.ReadLine().Trim();

        var ans = -1;
        for (int i = 0; i < N - 2; i++)
        {
            var str = string.Join("", S[i], S[i + 1], S[i + 2]);
            if (str == "ABC")
            {
                ans = i + 1;
                break;
            }
        }

        Console.WriteLine(ans);
    }
}
