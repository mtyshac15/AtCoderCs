using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC150;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// 500 Yen Coins
    /// </summary>
    public void Solve()
    {
        var KX = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var K = KX[0];
        var X = KX[1];

        var ans = 500 * K >= X;
        Console.WriteLine(ProblemA.ToYesOrNo(ans));
    }

    public static string ToYesOrNo(bool value)
    {
        return value ? $"Yes" : $"No";
    }
}
