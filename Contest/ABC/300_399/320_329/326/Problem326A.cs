using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC326;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// 2UP3DOWN
    /// </summary>
    public void Solve()
    {
        var XY = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var X = XY[0];
        var Y = XY[1];

        var sub = Y - X;
        var ans = sub <= 2 && sub >= -3;
        Console.WriteLine(ProblemA.ToYesOrNo(ans));
    }

    public static string ToYesOrNo(bool value)
    {
        return value ? $"Yes" : $"No";
    }
}
