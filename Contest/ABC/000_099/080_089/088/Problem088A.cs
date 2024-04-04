using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC088;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// Infinite Coins
    /// </summary>
    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var A = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var reminder = N % 500;

        var ans = reminder <= A;
        Console.WriteLine(ProblemA.ToYesOrNo(ans));
    }

    public static string ToYesOrNo(bool value)
    {
        return value ? $"Yes" : $"No";
    }
}
