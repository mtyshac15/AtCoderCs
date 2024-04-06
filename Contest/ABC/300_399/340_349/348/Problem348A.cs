using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC348;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// Penalty Kick
    /// </summary>
    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var strBuilder = new StringBuilder();
        for (int i = 0; i < N; i++)
        {
            if ((i + 1) % 3 == 0)
            {
                strBuilder.Append('x');
            }
            else
            {
                strBuilder.Append('o');
            }
        }

        var ans = strBuilder.ToString();
        Console.WriteLine(ans);
    }
}
