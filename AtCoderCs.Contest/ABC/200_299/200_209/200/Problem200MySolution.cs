using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC200;

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
        var A = _reader.IntArray();

        var BList = new List<int>[200];

        var count = Math.Min(N, 8);
        for (int i = 0; i < (1 << count); i++)
        {
            var index = 0;
            var B = new List<int>();

            for (int bit = 0; bit < count; bit++)
            {
                if (((i >> bit) & 1) == 1)
                {
                    B.Add(bit + 1);
                    index += A[bit];
                    index %= 200;
                }
            }

            if (BList[index].Any())
            {
                _writer.WriteLine($"Yes");
                _writer.WriteLine($"{B.Count} {string.Join(" ", B)}");
                var C = BList[index];
                _writer.WriteLine($"{C.Count} {string.Join(" ", C)}");
                return;
            }
            else
            {
                BList[index] = B;
            }
        }

        _writer.WriteLine($"No");
    }
}
