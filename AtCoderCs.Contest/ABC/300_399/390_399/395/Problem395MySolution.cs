using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC395;

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

        var dic = new Dictionary<int, IList<int>>();

        foreach (var item in A.Select((a, i) => (a, i)))
        {
            if (!dic.ContainsKey(item.a))
            {
                dic.Add(item.a, new List<int>() { item.i });
            }
            else
            {
                dic[item.a].Add(item.i);
            }
        }

        var min = int.MaxValue;
        foreach (var list in dic.Values.Where(x => x.Count >= 2))
        {
            // 階差
            var floos = list.Skip(1).Zip(list, (e1, e2) => e1 - e2 + 1);
            min = Math.Min(floos.Min(), min);
        }

        var ans = min == int.MaxValue ? -1 : min;
        _writer.WriteLine(ans);
    }
}
