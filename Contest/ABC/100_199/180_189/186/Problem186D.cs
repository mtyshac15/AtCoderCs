using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC186;

public class ProblemD
{
    public static void Main(string[] args)
    {
        var problem = new ProblemD();
        problem.Solve();
    }

    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var A = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        Array.Sort(A);
        var sortedA = A.Reverse().ToArray();

        var ans = 0L;
        var count = N / 2;
        for (int i = 0; i < count; i++)
        {
            var a = N - 2 * i - 1;
            var subA = sortedA[i] - sortedA[N - i - 1];
            ans += (long)a * subA;
        }

        Console.WriteLine(ans);
    }
}
