using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC326;

public class ProblemB
{
    public static void Main(string[] args)
    {
        var problem = new ProblemB();
        problem.Solve();
    }

    /// <summary>
    /// 326-like Numbers
    /// </summary>
    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var ans = N;
        while (true)
        {
            var array = ans.ToString().ToArray().Select(x => int.Parse(x.ToString())).ToArray();
            if (array[0] * array[1] == array[2])
            {
                break;
            }

            ans++;
        }

        Console.WriteLine(ans);
    }
}
