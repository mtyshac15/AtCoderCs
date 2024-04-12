using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC122;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// Double Helix
    /// </summary>
    public void Solve()
    {
        var b = Console.ReadLine().Trim();

        var ans = string.Empty;

        switch (b)
        {
            case "A":
                ans = "T";
                break;

            case "C":
                ans = "G";
                break;

            case "G":
                ans = "C";
                break;

            case "T":
                ans = "A";
                break;
        }

        Console.WriteLine(ans);
    }
}
