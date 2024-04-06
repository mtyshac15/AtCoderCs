using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC039;

public class ProblemB
{
    public static void Main(string[] args)
    {
        var problem = new ProblemB();
        problem.Solve();
    }

    public void Solve()
    {
        var X = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var ans = 0;

        //200^4 = 1.6 * 10^9
        for (int i = 0; i < 200; i++)
        {
            if (i * i * i * i == X)
            {
                ans = i;
                break;
            }
        }

        Console.WriteLine(ans);
    }
}
