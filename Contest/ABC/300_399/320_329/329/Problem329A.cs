using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC329;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// Spread
    /// </summary>
    public void Solve()
    {
        var S = Console.ReadLine().Trim();
        var charArray = S.ToArray();

        var ans = string.Join(" ", charArray);
        Console.WriteLine(ans);
    }
}
