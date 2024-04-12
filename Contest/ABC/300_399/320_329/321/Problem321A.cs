using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC321;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// 321-like Checker
    /// </summary>
    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var nArray = N.ToString().ToArray().Select(x => int.Parse(x.ToString())).ToArray();
        var ans = true;

        for (int i = 0; i < nArray.Length - 1; i++)
        {
            if (nArray[i] <= nArray[i + 1])
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
