using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC378;

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
        var N = _reader.Int();
        var q = new List<int>() { 0 };
        var r = new List<int>() { 0 };
        for (int i = 0; i < N; i++)
        {
            q.Add(_reader.Int());
            r.Add(_reader.Int());
        }

        var Q = _reader.Int();
        var t = new List<int>();
        var d = new List<int>();
        for (int i = 0; i < Q; i++)
        {
            t.Add(_reader.Int());
            d.Add(_reader.Int());
        }

        var ansList = new List<int>();
        for (int i = 0; i < Q; i++)
        {
            var remainder = d[i] % q[t[i]];
            var day = d[i] + r[t[i]] - remainder;

            if (remainder > r[t[i]])
            {
                day += q[t[i]];
            }

            ansList.Add(day);
        }

        var ans = string.Join(Environment.NewLine, ansList);
        _writer.WriteLine(ans);
    }

    public void OldC()
    {
        var N = _reader.Int();
        var A = _reader.IntArray();

        var dic = new Dictionary<int, List<int>>();
        for (int i = 0; i < N; i++)
        {
            if (!dic.ContainsKey(A[i]))
            {
                var list = new List<int>() { i };
                dic.Add(A[i], list);
            }
            else
            {
                dic[A[i]].Add(i);
            }
        }

        var B = new List<int>();
        for (int i = 0; i < N; i++)
        {
            var list = dic[A[i]];
            var min = list.First();
            if (min == i)
            {
                B.Add(-1);
            }
            else
            {
                var ng = list.Count;
                var ok = 0;

                while (Math.Abs(ok - ng) > 1)
                {
                    var middle = ok + (ng - ok) / 2;
                    if (list[middle] < i)
                    {
                        ok = middle;
                    }
                    else
                    {
                        ng = middle;
                    }
                }

                B.Add(list[ok] + 1);
            }
        }

        var ans = string.Join(" ", B);
        _writer.WriteLine(ans);
    }
}
