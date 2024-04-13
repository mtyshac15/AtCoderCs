using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC314;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// 3.14
    /// </summary>
    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var pi = "3.1415926535897932384626433832795028841971693993751058209749445923078164062862089986280348253421170679";

        var ansBuilder = new StringBuilder();
        ansBuilder.Append("3.");

        for (int i = 0; i < N; i++)
        {
            ansBuilder.Append(pi[2 + i]);
        }

        var ans = ansBuilder.ToString();
        Console.WriteLine(ans);
    }
}
