using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC315;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// tcdr
    /// </summary>
    public void Solve()
    {
        var S = Console.ReadLine().Trim();

        var strArray = "aeiou";

        var ans = S;
        foreach (var s in strArray)
        {
            ans = ans.Replace(s.ToString(), string.Empty);
        }

        Console.WriteLine(ans);
    }
}
