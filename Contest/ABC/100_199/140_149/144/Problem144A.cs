using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC144;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// 9×9
    /// </summary>
    public void Solve()
    {
        var AB = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var A = AB[0];
        var B = AB[1];

        var ans = -1;
        if (A < 10 && B < 10)
        {
            ans = A * B;
        }

        Console.WriteLine(ans);
    }
}
