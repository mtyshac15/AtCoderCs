using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC267;

public class ProblemC
{
    public static void Main(string[] args)
    {
        var problem = new ProblemC();
        problem.Solve();
    }

    /// <summary>
    /// Index × A(Continuous ver.)
    /// </summary>
    public void Solve()
    {
        var input = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = input[0];
        var M = input[1];

        var A = Console.ReadLine().Trim().Split().Select(long.Parse).ToArray();

        var aSum = new long[N + 1];
        aSum[0] = 0;

        for (int i = 0; i < N; i++)
        {
            aSum[i + 1] = aSum[i] + A[i];
        }

        var bSum = new long[N - M + 1];
        for (int i = 0; i < M; i++)
        {
            bSum[0] += (i + 1) * A[i];
        }

        var bIndex = 1;
        for (int i = M; i < N; i++)
        {
            // Am-1までの和
            var mSum = aSum[i] - aSum[i - M];

            // Am-1までの和を引き、インデックスを一つずつずらす
            // 新しい項とMの積を足す
            bSum[bIndex] = bSum[bIndex - 1] - mSum + M * A[i];
            bIndex++;
        }

        var ans = bSum.Max();

        Console.WriteLine(ans);
    }
}
