using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace AtCoderCs.Contest.ABC323;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// Weak Beats
    /// </summary>
    public void Solve()
    {
        var S = Console.ReadLine().Trim();

        var ans = true;
        for (int i = 1; i < S.Length; i += 2)
        {
            if (S[i] != '0')
            {
                ans = false;
                break;
            }
        }

        Console.WriteLine(ProblemA.ToYesOrNo(ans));
    }

    public static string ToYesOrNo(bool value)
    {
        return value ? $"Yes" : $"No";
    }
}
