using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC267;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// Saturday
    /// </summary>
    public void Solve()
    {
        var S = Console.ReadLine().Trim();

        var week = new string[5]
        {
            "Monday","Tuesday","Wednesday","Thursday","Friday"
        };

        var ans = 5 - Array.IndexOf(week, S);
        Console.WriteLine(ans);
    }
}
