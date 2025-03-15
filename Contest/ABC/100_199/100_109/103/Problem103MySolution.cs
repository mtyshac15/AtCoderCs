using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC103;

public class MySolution
{
    private Reader _reader;
    private Writer _writer;

    public MySolution()
    {
        _reader = new Reader(Console.In);
        _writer = new Writer(Console.Out);
    }

    public void OldA()
    {
        var A = _reader.NextIntArray();

        var time = new List<int>();
        for (int i = 0; i < A.Length; i++)
        {
            var nextI = (i + 1) % A.Length;
            time.Add(Math.Abs(A[i] - A[nextI]));
        }

        var ans = time.Sum() - time.Max();
        _writer.WriteLine(ans);
    }
}
