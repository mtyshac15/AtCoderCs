using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace AtCoderCs.Contest.ABC313;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// To Be Saikyo
    /// </summary>
    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var P = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var ans = 0;
        if (N > 1)
        {
            var max = P.Skip(1).Max();
            ans = Math.Max(max - P[0] + 1, 0);
        }

        Console.WriteLine(ans);
    }
}
