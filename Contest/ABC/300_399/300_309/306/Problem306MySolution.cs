using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC306;

public class MySolution
{
    private Reader _reader;
    private Writer _writer;

    public MySolution()
    {
        _reader = new Reader(Console.In);
        _writer = new Writer(Console.Out);
    }

    public void OldB()
    {
        var A = _reader.IntArray();

        var total = 0UL;
        var mask = 1UL;

        for (int i = 0; i < A.Length; i++)
        {
            total += (uint)A[i] * mask;
            mask = mask << 1;
        }

        var ans = total;
        _writer.WriteLine(ans);
    }
}
