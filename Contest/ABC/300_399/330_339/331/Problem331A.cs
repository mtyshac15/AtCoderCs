using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC331;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// Tomorrow
    /// </summary>
    public void Solve()
    {
        var MD = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var M = MD[0];
        var D = MD[1];

        var ymd = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var y = ymd[0];
        var m = ymd[1];
        var d = ymd[2];

        var newy = y;
        var newm = m;
        var newd = d + 1;

        if (newd == D + 1)
        {
            newd = 1;
            newm++;
        }

        if (newm == M + 1)
        {
            newm = 1;
            newy++;
        }

        var ans = string.Join(" ", newy, newm, newd);
        Console.WriteLine(ans);
    }
}
