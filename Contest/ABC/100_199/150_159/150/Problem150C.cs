using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC150;

public class ProblemC
{
    public static void Main(string[] args)
    {
        var problem = new ProblemC();
        problem.Solve();
    }

    /// <summary>
    /// Count Order
    /// </summary>
    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var P = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var Q = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var ans = 0;
        Console.WriteLine(ans);
    }
}
