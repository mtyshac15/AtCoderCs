using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC335;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// 202<s>3</s>
    /// </summary>
    public void Solve()
    {
        var S = Console.ReadLine().Trim();
        var sArray = S.ToCharArray();
        sArray[S.Length - 1] = '4';

        var ans = string.Join("", sArray);
        Console.WriteLine(ans);
    }
}
