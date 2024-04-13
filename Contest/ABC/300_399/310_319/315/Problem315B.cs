using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC315;

public class ProblemB
{
    public static void Main(string[] args)
    {
        var problem = new ProblemB();
        problem.Solve();
    }

    /// <summary>
    /// The Middle Day
    /// </summary>
    public void Solve()
    {
        var M = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var D = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var middle = (D.Sum() + 1) / 2;

        var total = 0;
        var a = 1;

        //月
        for (int m = 0; m < M; m++)
        {
            if (total + D[m] < middle)
            {
                total += D[m];
            }
            else
            {
                a = m + 1;
                break;
            }
        }

        //日
        var b = middle - total;
        var ans = $"{a} {b}";
        Console.WriteLine(ans);
    }
}
