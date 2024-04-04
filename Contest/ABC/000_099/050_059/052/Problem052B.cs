using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC052;

public class ProblemB
{
    public static void Main(string[] args)
    {
        var problem = new ProblemB();
        problem.Solve();
    }

    /// <summary>
    /// Increment Decrement
    /// </summary>
    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var S = Console.ReadLine().Trim();

        var x = 0;

        var ans = 0;
        foreach (var c in S)
        {
            if (c == 'I')
            {
                x++;
            }
            else if (c == 'D')
            {
                x--;
            }

            ans = Math.Max(ans, x);
        }

        Console.WriteLine(ans);
    }
}
