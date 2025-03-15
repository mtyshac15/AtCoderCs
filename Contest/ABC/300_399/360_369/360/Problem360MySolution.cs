using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC360;

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
        var A = _reader.NextIntArray();
        var W = _reader.NextIntArray();

        var dictionary = new Dictionary<int, List<int>>();
        for (int i = 0; i < N; i++)
        {
            if (!dictionary.ContainsKey(A[i]))
            {
                dictionary.Add(A[i], new List<int>() { W[i] });
            }
            else
            {
                dictionary[A[i]].Add(W[i]);
            }
        }

        var total = 0L;
        foreach (var boxes in dictionary.Values.Where(x => x.Count >= 2))
        {
            boxes.Sort();
            var moveBoxes = boxes.Take(boxes.Count - 1);
            total += moveBoxes.Sum();
        }

        var ans = total;
        _writer.WriteLine(ans);
    }
}
