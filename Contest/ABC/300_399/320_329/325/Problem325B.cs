using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC325;

public class ProblemB
{
    public static void Main(string[] args)
    {
        var problem = new ProblemB();
        problem.Solve();
    }

    /// <summary>
    /// World Meeting
    /// </summary>
    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var WX = new int[N, 2];

        for (var i = 0; i < N; i++)
        {
            var array = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            WX[i, 0] = array[0];
            WX[i, 1] = array[1];
        }

        var ans = 0;

        //標準時に換算
        for (int t = 0; t < 24; t++)
        {
            var count = 0;
            for (var i = 0; i < N; i++)
            {
                var start = (t + WX[i, 1]) % 24;
                var end = start + 1;
                if (start >= 9 && end <= 18)
                {
                    count += WX[i, 0];
                }
            }

            ans = Math.Max(count, ans);
        }

        Console.WriteLine(ans);
    }
}
