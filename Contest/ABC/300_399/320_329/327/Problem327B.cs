using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace AtCoderCs.Contest.ABC327;

public class ProblemB
{
    public static void Main(string[] args)
    {
        var problem = new ProblemB();
        problem.Solve();
    }

    /// <summary>
    /// A^A
    /// </summary>
    public void Solve()
    {
        var B = Console.ReadLine().Trim().Split().Select(long.Parse).ToList()[0];

        var A = 1L;

        var ans = 0L;
        while (true)
        {
            var value = A;
            for (int i = 1; i < A; i++)
            {
                value *= A;
            }

            if (value == B)
            {
                ans = A;
                break;
            }
            else if (value > B)
            {
                ans = -1;
                break;
            }

            A++;
        }

        Console.WriteLine(ans);
    }
}
