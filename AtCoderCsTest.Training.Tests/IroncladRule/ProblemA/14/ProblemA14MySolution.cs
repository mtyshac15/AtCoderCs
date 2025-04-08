using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Training.Tests.A14;

public class MySolution
{
    private Reader _reader;
    private Writer _writer;

    public MySolution()
    {
        _reader = new Reader(Console.In);
        _writer = new Writer(Console.Out);
    }

    public void Solve()
    {
        var N = _reader.Int();
        var K = _reader.Int();
        var A = _reader.IntArray();
        var B = _reader.IntArray();
        var C = _reader.IntArray();
        var D = _reader.IntArray();

        var P = new List<int>();
        var Q = new List<int>();
        for (var i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                P.Add(A[i] + B[j]);
                Q.Add(C[i] + D[j]);
            }
        }

        P = P.Order().ToList();
        Q = Q.Order().ToList();

        // 二分探索
        var ans = false;
        for (int i = 0; i < P.Count; i++)
        {
            var num = Q.BinarySearch(K - P[i]);
            if (num > 0)
            {
                ans = true;
                break;
            }
        }

        _writer.WriteYesOrNo(ans);
    }
}
