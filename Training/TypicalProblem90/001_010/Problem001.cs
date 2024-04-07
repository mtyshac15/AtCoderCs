using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Traing.Typical.Problem001;

public class Problem
{
    public static void Main(string[] args)
    {
        var problem = new Problem();
        problem.Solve();
    }

    /// <summary>
    /// Yokan Party
    /// </summary>
    public void Solve()
    {
        var input = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = input[0];
        var L = input[1];

        var K = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var A = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var ans = 0;
        Console.WriteLine(ans);
    }
}
