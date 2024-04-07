using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Traing.Typical.Problem003;

public class Problem
{
    public static void Main(string[] args)
    {
        var problem = new Problem();
        problem.Solve();
    }

    /// <summary>
    /// Longest Circular Road
    /// </summary>
    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var AB = new int[N, 2];

        for (int i = 0; i < N; i++)
        {
            var input = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            AB[i, 0] = input[0];
            AB[i, 1] = input[1];
        }

        var ans = 0;
        Console.WriteLine(ans);
    }
}
