using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC349;

public class ProblemC
{
    public static void Main(string[] args)
    {
        var problem = new ProblemC();
        problem.Solve();
    }

    public void Solve()
    {
        var S = Console.ReadLine().Trim();
        var T = Console.ReadLine().Trim();

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
        foreach (var index0 in indexDic[0])
        {
            var index1 = ProblemC.BinarySearch(indexDic[1], index0);
            if (index1 < indexDic[1].Count && indexDic[1][index1] > index0)
            {
                ans = true;
                break;
            }
        }

        //末尾がSに含まれている、または末尾がx
        if (ans)
        {
            var ans2 = false;
            foreach (var index1 in indexDic[1])
            {
                var index2 = ProblemC.BinarySearch(indexDic[2], index1);
                if (index2 < indexDic[2].Count && indexDic[2][index2] > index1)
                {
                    ans2 = true;
                    break;
                }
            }

            ans = ans & (ans2 || t[2] == 'x');
        }

        Console.WriteLine(ProblemC.ToYesOrNo(ans));
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

    public static string ToYesOrNo(bool value)
    {
        return value ? $"Yes" : $"No";
    }
}
