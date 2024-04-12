using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC324;

public class ProblemB
{
    public static void Main(string[] args)
    {
        var problem = new ProblemB();
        problem.Solve();
    }

    /// <summary>
    /// 3-smooth Numbers
    /// </summary>
    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(long.Parse).ToArray()[0];

        var ans = true;

        var value = N;
        foreach (var num in new int[] { 2, 3 })
        {
            while (true)
            {
                var remainder = value % num;
                if (remainder != 0)
                {
                    break;
                }

                value = value / num;
            }
        }

        if (value != 1)
        {
            ans = false;
        }

        Console.WriteLine(ProblemB.ToYesOrNo(ans));
    }

    public static string ToYesOrNo(bool value)
    {
        return value ? $"Yes" : $"No";
    }
}
