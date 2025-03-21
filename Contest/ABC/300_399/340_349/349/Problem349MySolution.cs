﻿using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC349;

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
        var S = _reader.Next();
        var T = _reader.Next();

        var t = T.ToLower();

        var indexDic = new Dictionary<int, IList<int>>()
        {
            {0, new List<int>()},
            {1, new List<int>()},
            {2, new List<int>()},
        };

        for (int i = 0; i < S.Length; i++)
        {
            if (S[i] == t[0])
            {
                indexDic[0].Add(i);
            }

            if (S[i] == t[1])
            {
                indexDic[1].Add(i);
            }

            if (S[i] == t[2])
            {
                indexDic[2].Add(i);
            }
        }

        var ans = false;

        var index1List = new List<int>();
        foreach (var index0 in indexDic[0])
        {
            var index1 = MySolution.BinarySearch(indexDic[1], index0);
            if (index1 < indexDic[1].Count)
            {
                ans = true;
                index1List.Add(indexDic[1][index1]);
            }
        }

        //末尾がSに含まれている、または末尾がx
        if (ans)
        {
            var ans2 = false;
            foreach (var index1 in index1List)
            {
                var index2 = MySolution.BinarySearch(indexDic[2], index1);
                if (index2 < indexDic[2].Count)
                {
                    ans2 = true;
                    break;
                }
            }

            ans = ans & (ans2 || t[2] == 'x');
        }

        _writer.WriteYesOrNo(ans);
    }

    public static int BinarySearch(IList<int> sortedList, int key)
    {
        var ng = -1;
        var ok = sortedList.Count;

        while (Math.Abs(ok - ng) > 1)
        {
            var middle = ng + (ok - ng) / 2;
            if (sortedList[middle] <= key)
            {
                ng = middle;
            }
            else
            {
                ok = middle;
            }
        }

        return ok;
    }
}
