using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC338;

public class MySolution
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public void OldC()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var Q = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var A = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var B = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        //Aを最大まで作った場合
        var maxA = int.MaxValue;
        for (int i = 0; i < N; i++)
        {
            if (A[i] != 0)
            {
                maxA = Math.Min(Q[i] / A[i], maxA);
            }
        }

        //残りの材料
        var remainderQ = Q.Zip(A, (q, a) => q - a * maxA).ToArray();

        var countB = int.MaxValue;
        for (int i = 0; i < N; i++)
        {
            if (B[i] != 0)
            {
                countB = Math.Min(remainderQ[i] / B[i], countB);
            }
        }

        var total = maxA + countB;

        //Aを1人分ずつ減らし、その分Bを作る
        for (int i = 1; i <= maxA; i++)
        {
            countB = int.MaxValue;
            for (int j = 0; j < N; j++)
            {
                var q = remainderQ[j] + A[j] * i;

                if (B[j] != 0)
                {
                    countB = Math.Min(q / B[j], countB);
                }
            }

            total = Math.Max(total, maxA - i + countB);
        }
    }
}
