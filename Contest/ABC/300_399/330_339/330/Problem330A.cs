using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC330;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// Counting Passes
    /// </summary>
    public void Solve()
    {
        var NL = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NL[0];
        var L = NL[1];

        var A = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var ans = A.Count(x => x >= L);
        Console.WriteLine(ans);
    }
}
