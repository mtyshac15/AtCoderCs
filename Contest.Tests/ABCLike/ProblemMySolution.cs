using AtCoder.Common;
using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.Tests.ABCLike.ZONE2021;

public class MySolution
{
    private Reader _reader;
    private Writer _writer;

    public MySolution()
    {
        _reader = new Reader(Console.In);
        _writer = new Writer(Console.Out);
    }

    public void SolveC()
    {
        var N = _reader.NextInt();

        var dic = new Dictionary<int, int[]>();
        for (int i = 0; i < N; i++)
        {
            dic[i] = _reader.NextIntArray();
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
                foreach (var indexes in MathLibrary.GetCombinationIndexCollection(Enumerable.Range(0, judge.Count), 3))
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
}
