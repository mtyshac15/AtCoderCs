using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC334;

public class ProblemB
{
    public static void Main(string[] args)
    {
        var problem = new ProblemB();
        problem.Solve();
    }

    /// <summary>
    /// Christmas Trees
    /// </summary>
    public void Solve()
    {
        var input = Console.ReadLine().Trim().Split().Select(long.Parse).ToArray();
        var A = input[0];
        var M = input[1];
        var L = input[2];
        var R = input[3];

        var decR = (R - A) / (decimal)M;
        var decL = (L - A) / (decimal)M;

        var longL = (long)decL;
        var longR = (long)decR;

        var ans = 0L;
        if (decL >= 0 && decR >= 0)
        {
            if (decL == longL)
            {
                ans = longR - longL + 1;
            }
            else
            {
                ans = longR - longL;
            }
        }
        else if (decL < 0 && decR >= 0)
        {
            ans = longR - longL + 1;
        }
        else
        {
            if (decR == longR)
            {
                ans = longR - longL + 1;
            }
            else
            {
                ans = longR - longL;
            }
        }

        Console.WriteLine(ans);
    }
}
