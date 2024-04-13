using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC317;

public class ProblemB
{
    public static void Main(string[] args)
    {
        var problem = new ProblemB();
        problem.Solve();
    }

    /// <summary>
    /// MissingNo.
    /// </summary>
    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var A = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var sumA = A.Sum();

        //端の数はなくした整数ではない
        var min = A.Min();
        var max = A.Max();

        // minからmaxまでの和
        var sum = (min + max) * (N + 1) / 2;
        var ans = sum - sumA;
        Console.WriteLine(ans);
    }
}
