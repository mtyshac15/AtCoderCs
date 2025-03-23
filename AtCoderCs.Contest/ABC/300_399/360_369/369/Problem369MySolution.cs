using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC369;

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
        var A = _reader.IntArray();

        if (N == 1)
        {
            _writer.WriteLine(1);
            return;
        }

        var floors = A.Zip(A.Skip(1), (a1, a2) => a1 - a2).ToArray();
        var last = floors[floors.Length - 1];
        var prev = floors.First();

        var sum = 1L;

        var count = 1;
        foreach (var sub in floors.Append(last + 1))
        {
            if (prev == sub)
            {
                count++;
            }
            else
            {
                sum += (long)count * (count + 1) / 2;
                sum--;

                count = 2;
            }

            prev = sub;
        }

        var ans = sum;
        _writer.WriteLine(ans);
    }

}
