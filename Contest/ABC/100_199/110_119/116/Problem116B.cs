using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC116;

public class ProblemB
{
    public static void Main(string[] args)
    {
        var problem = new ProblemB();
        problem.Solve();
    }

    /// <summary>
    /// Collatz Problem
    /// </summary>
    public void Solve()
    {
        var s = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var a = s;
        var ans = 1;

        var set = new HashSet<int>();

        while (set.Add(a))
        {
            if (a % 2 == 0)
            {
                a = a / 2;
            }
            else
            {
                a = 3 * a + 1;
            }

            ans++;
        }

        Console.WriteLine(ans);
    }
}
