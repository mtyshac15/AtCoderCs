using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC333;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// Three Threes
    /// </summary>
    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var ansBuilder = new StringBuilder();
        for (int i = 0; i < N; i++)
        {
            ansBuilder.Append(N.ToString());
        }

        var ans = ansBuilder.ToString();
        Console.WriteLine(ans);
    }
}
