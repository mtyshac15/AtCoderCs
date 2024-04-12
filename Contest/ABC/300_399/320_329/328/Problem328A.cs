using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC328;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// Not Too Hard
    /// </summary>
    public void Solve()
    {
        var NX = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NX[0];
        var X = NX[1];

        var S = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var ans = S.Where(x => x <= X).Sum();
        Console.WriteLine(ans);
    }
}
