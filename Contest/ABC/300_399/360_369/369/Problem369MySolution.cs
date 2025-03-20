using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.AB369;

public class MySolution
{
    private Reader _reader;
    private Writer _writer;

    public MySolution()
    {
        _reader = new Reader(Console.In);
        _writer = new Writer(Console.Out);
    }

    public void OldD()
    {
        var N = _reader.Int();

        var A = new List<int>() { 0 };
        for (int i = 0; i < N; i++)
        {
            A.Add(_reader.Int());
        }

        var dpOdd = new long[N + 1];
        var dpEven = new long[N + 1];

        dpOdd[0] = -1;
        dpEven[0] = -1;

        dpOdd[1] = A[1];
        dpEven[1] = -1;

        for (int i = 2; i <= N; i++)
        {
            // 奇数匹目の場合
            {
                var prevEsc = Math.Max(dpOdd[i - 1] - A[i - 1], 0);
                dpOdd[i] = Math.Max(dpEven[i - 1], prevEsc) + A[i];
            }

            // 偶数匹目の場合
            {
                var prevEsc = Math.Max(dpEven[i - 1] - A[i - 1] * 2, 0);
                dpEven[i] = Math.Max(dpOdd[i - 1], prevEsc) + A[i] * 2;
            }
        }

        var ans = Math.Max(dpOdd[N], dpEven[N]);
        _writer.WriteLine(ans);
    }
}
