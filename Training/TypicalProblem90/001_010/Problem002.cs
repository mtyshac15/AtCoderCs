using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Traing.Typical.Problem002;

public class Problem
{
    public static void Main(string[] args)
    {
        var problem = new Problem();
        problem.Solve();
    }

    /// <summary>
    /// Encyclopedia of Parentheses
    /// </summary>
    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var ans = 0;
        Console.WriteLine(ans);
    }
}
