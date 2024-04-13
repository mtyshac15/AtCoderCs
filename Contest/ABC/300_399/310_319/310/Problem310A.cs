using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC310;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// Order Something Else
    /// </summary>
    public void Solve()
    {
        var NPQ = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var M = NPQ[0];
        var P = NPQ[1];
        var Q = NPQ[2];

        var D = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var ans = Math.Min(P, Q + D.Min());
        Console.WriteLine(ans);
    }
}
