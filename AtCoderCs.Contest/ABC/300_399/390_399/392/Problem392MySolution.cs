using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC392;

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
        var N = _reader.Int();
        var P = _reader.IntArray();
        var Q = _reader.IntArray();

        var dic = new SortedDictionary<int, int>();
        for (int i = 0; i < N; i++)
        {
            dic.Add(Q[i], Q[P[i] - 1]);
        }
        var ans = string.Join(" ", dic.Values);
        _writer.WriteLine(ans);
    }
}
