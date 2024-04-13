using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC349;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var A = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var ans = 0 - A.Sum();
        Console.WriteLine(ans);
    }
}
