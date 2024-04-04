using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderCs.Contest.ABC336;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// Long Loong
    /// </summary>
    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var strBuilder = new StringBuilder();
        strBuilder.Append("L");

        for (int i = 0; i < N; i++)
        {
            strBuilder.Append("o");
        }

        strBuilder.Append("n");
        strBuilder.Append("g");

        var ans = strBuilder.ToString();
        Console.WriteLine(ans);
    }
}
