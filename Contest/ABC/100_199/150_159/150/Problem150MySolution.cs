using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC150;

public class MySolution
{
    private Reader _reader;
    private Writer _writer;

    public MySolution()
    {
        _reader = new Reader(Console.In);
        _writer = new Writer(Console.Out);
    }

    public void OldC()
    {
        var N = _reader.NextInt();
        var P = _reader.NextIntArray();
        var Q = _reader.NextIntArray();

        var factorial = new int[N + 1];
        factorial[0] = 1;
        for (int i = 1; i < N + 1; i++)
        {
            factorial[i] = i * factorial[i - 1];
        }

        var a = 1;
        var list = Enumerable.Range(1, N).ToList();
        for (int i = 0; i < N; i++)
        {
            var index = list.IndexOf(P[i]);
            var num = factorial[N - i - 1];

            a += index * num;
            list.Remove(P[i]);
        }

        var b = 1;
        list = Enumerable.Range(1, N).ToList();
        for (int i = 0; i < N; i++)
        {
            var index = list.IndexOf(Q[i]);
            var num = factorial[N - i - 1];

            b += index * num;
            list.Remove(Q[i]);
        }

        var ans = Math.Abs(a - b);
        _writer.WriteLine(ans);
    }
}
