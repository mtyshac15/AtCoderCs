using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC088;

public class ProblemB
{
    public static void Main(string[] args)
    {
        var problem = new ProblemB();
        problem.Solve();
    }

    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var a = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        Array.Sort(a);
        var sortedA = a.Reverse();

        var ans = 0;
        var sign = 1;
        foreach (var card in sortedA)
        {
            ans += card * sign;
            sign *= -1;
        }

        Console.WriteLine(ans);
    }
}
