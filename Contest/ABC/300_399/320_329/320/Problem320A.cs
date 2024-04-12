using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC320;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// Leyland Number
    /// </summary>
    public void Solve()
    {
        var AB = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var A = AB[0];
        var B = AB[1];

        var ans = 0L;

        {
            var num = 1L;
            for (int i = 0; i < B; i++)
            {
                num *= A;
            }

            ans += num;
        }

        {
            var num = 1L;
            for (int i = 0; i < A; i++)
            {
                num *= B;
            }

            ans += num;
        }

        Console.WriteLine(ans);
    }
}
