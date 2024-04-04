using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC052;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// Two Rectangles
    /// </summary>
    public void Solve()
    {
        var input = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var A = input[0];
        var B = input[1];
        var C = input[2];
        var D = input[3];

        var rectangles = new int[] { A * B, C * D };
        var ans = rectangles.Max();
        Console.WriteLine(ans);
    }
}
