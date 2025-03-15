using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABCLike.ZONE2021;

public class MySolution
{
    private Reader _reader;
    private Writer _writer;

    public MySolution()
    {
        _reader = new Reader(Console.In);
        _writer = new Writer(Console.Out);
    }

    public void SolveB()
    {
        var N = _reader.NextInt();
        var D = _reader.NextInt();
        var H = _reader.NextInt();

        var d = new List<int>();
        var h = new List<int>();
        for (int i = 0; i < N; i++)
        {
            d.Add(_reader.NextInt());
            h.Add(_reader.NextInt());
        }

        var max = 0m;

        for (int i = 0; i < N; i++)
        {
            var a = (decimal)(H - h[i]) / (D - d[i]);
            var y = a * (-d[i]) + h[i];

            max = Math.Max(y, max);
        }

        var ans = max;
        _writer.WriteLine(ans);
    }

    public void SolveD()
    {
        var S = _reader.Next();
        var T = new LinkedList<char>();
        var isReverse = false;

        foreach (var c in S)
        {
            if (c == 'R')
            {
                isReverse = !isReverse;
            }
            else
            {
                if (isReverse)
                {
                    T.AddFirst(c);
                }
                else
                {
                    T.AddLast(c);
                }
            }
        }

        var ansT = new List<string>();
        foreach (var t in T)
        {
            var lastT = ansT.LastOrDefault();
            var strT = t.ToString();
            if (lastT == strT)
            {
                ansT.RemoveAt(ansT.Count - 1);
            }
            else
            {
                ansT.Add(strT);
            }
        }

        if (isReverse)
        {
            ansT.Reverse();
        }

        var ansStr = string.Concat(ansT);
        _writer.WriteLine(ansStr);
    }
}
