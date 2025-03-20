using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC326;

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
        var M = _reader.Int();
        var A = _reader.IntArray();
        Array.Sort(A);

        var present = new SortedDictionary<int, int>();
        for (int i = 0; i < N; i++)
        {
            if (present.ContainsKey(A[i]))
            {
                present[A[i]]++;
            }
            else
            {
                present.Add(A[i], 1);
            }
        }

        //集計
        var firstKeyValue = present.FirstOrDefault();
        var totalCount = new SortedDictionary<int, int>()
        {
            { -1, 0 },
            { firstKeyValue.Key, firstKeyValue.Value },
        };

        var preValue = firstKeyValue.Value;
        foreach (var keyValue in present.Skip(1))
        {
            var totalValue = preValue + keyValue.Value;
            totalCount.Add(keyValue.Key, totalValue);
            preValue = totalValue;
        }

        var max = 0;
        for (int i = 0; i < N; i++)
        {
            var end = A[i] + M;

            var ok = i - 1;
            var ng = present.Count;

            while (Math.Abs(ng - ok) > 1)
            {
                var middle = ok + (ng - ok) / 2;
                if (A[middle] < end)
                {
                    ok = middle;
                }
                else
                {
                    ng = middle;
                }
            }

            var count = totalCount[A[ok]] - totalCount[A[i]] + present[A[i]];
            max = Math.Max(count, max);
        }

        var ans = max;
        _writer.WriteLine(ans);
    }
}
