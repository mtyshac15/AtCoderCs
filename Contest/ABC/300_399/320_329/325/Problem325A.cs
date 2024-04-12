using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC325;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// Takahashi san
    /// </summary>
    public void Solve()
    {
        var ST = Console.ReadLine().Trim().Split();
        var S = ST[0];
        var T = ST[1];

        var ans = $"{S} san";
        Console.WriteLine(ans);
    }
}
