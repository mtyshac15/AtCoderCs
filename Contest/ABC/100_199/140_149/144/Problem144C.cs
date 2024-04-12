using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC144;

public class ProblemC
{
    public static void Main(string[] args)
    {
        var problem = new ProblemC();
        problem.Solve();
    }

    /// <summary>
    /// Walk on Multiplication Table
    /// </summary>
    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(long.Parse).ToArray()[0];

        var ans = long.MaxValue;

        //√Nまで探索
        for (long i = 1L; i * i <= N; i++)
        {
            // i*j=N が成り立つ場合のみ有効
            var j = N / i;
            if (i * j == N)
            {
                var d = (i - 1) + (j - 1);
                ans = Math.Min(d, ans);
            }
        }

        Console.WriteLine(ans);
    }
}
