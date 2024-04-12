using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC321;

public class ProblemB
{
    public static void Main(string[] args)
    {
        var problem = new ProblemB();
        problem.Solve();
    }

    /// <summary>
    /// Cutoff
    /// </summary>
    public void Solve()
    {
        var NX = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NX[0];
        var X = NX[1];

        var A = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var ans = 101;
        for (int i = 0; i <= 100; i++)
        {
            var newA = A.Append(i).ToArray();
            var currentSum = newA.Sum() - newA.Min() - newA.Max();

            if (currentSum >= X)
            {
                ans = i;
                break;
            }
        }

        if (ans > 100)
        {
            ans = -1;
        }

        Console.WriteLine(ans);
    }
}
