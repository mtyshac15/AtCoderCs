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
        var N = _reader.Int();
        var D = _reader.Int();
        var H = _reader.Int();

        var d = new List<int>();
        var h = new List<int>();
        for (int i = 0; i < N; i++)
        {
            d.Add(_reader.Int());
            h.Add(_reader.Int());
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

    public void OldC()
    {
        var N = _reader.Int();

        var dic = new Dictionary<int, int[]>();
        for (int i = 0; i < N; i++)
        {
            dic[i] = _reader.IntArray();
        }

        var ng = 1000000001;
        var ok = 0;

        while (Math.Abs(ok - ng) > 1)
        {
            var middle = ok + (ng - ok) / 2;

            var judge = new List<bool[]>();
            for (int i = 0; i < N; i++)
            {
                var item = dic[i].Select(x => x >= middle).ToArray();
                if (!judge.Any(array => array.SequenceEqual(item)))
                {
                    judge.Add(item);
                }
            }

            var isOk = false;
            if (judge.Count <= 3)
            {
                var ability = new bool[5];
                foreach (var item in judge)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        ability[i] |= item[i];
                    }
                }

                isOk = ability.All(x => x == true);
            }
            else
            {
                foreach (var indexes in AtCoderCs.Contest.ABC396.ProblemD.MathLibrary.GetCombinationIndexCollection(Enumerable.Range(0, judge.Count), 3))
                {
                    var ability = new bool[5];

                    var people = indexes.Select(x => judge[x]).ToArray();
                    foreach (var person in people)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            ability[i] |= person[i];
                        }
                    }

                    if (ability.All(x => x == true))
                    {
                        isOk = true;
                        break;
                    }
                }
            }

            if (isOk)
            {
                ok = middle;
            }
            else
            {
                ng = middle;
            }
        }

        var ans = ok;
        _writer.WriteLine(ans);
    }

    public void OldD()
    {
        var S = _reader.Str();
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
