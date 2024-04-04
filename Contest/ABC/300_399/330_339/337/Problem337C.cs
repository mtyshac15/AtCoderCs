using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC337;

public class ProblemC
{
    public static void Main(string[] args)
    {
        var problem = new ProblemC();
        problem.Solve();
    }

    /// <summary>
    /// Lining Up 2
    /// </summary>
    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var A = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        //最後尾を検索
        var set = new HashSet<int>(A);

        var tail = 0;
        for (int i = 1; i <= N; i++)
        {
            if (!set.Contains(i))
            {
                //1からNのうち、Aに存在しない人が最後尾
                tail = i;
            }
        }

        var result = new int[N];
        result[N - 1] = tail;

        for (int index = 1; index < N; index++)
        {
            var currentI = result[N - index];

            //前
            var prevI = A[currentI - 1];
            result[N - index - 1] = prevI;
        }

        var ans = string.Join(" ", result);
        Console.WriteLine(ans);
    }
}
