using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC349;

public class ProblemC
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemC();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemC()
    {
    }

    public ProblemC(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void Solve()
    {
        var S = _reader.ReadLine().Trim();
        var T = _reader.ReadLine().Trim();

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
            var index1 = ProblemC.BinarySearch(indexDic[1], index0);
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
                var index2 = ProblemC.BinarySearch(indexDic[2], index1);
                if (index2 < indexDic[2].Count)
                {
                    ans2 = true;
                    break;
                }
            }

            ans = ans & (ans2 || t[2] == 'x');
        }

        _writer.WriteLine(IOLibrary.ToYesOrNo(ans));
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

    public static class IOLibrary
    {
        public static string ToYesOrNo(bool value)
        {
            return value ? $"Yes" : $"No";
        }
    }
}
