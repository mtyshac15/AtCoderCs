using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC348;

public class ProblemC
{
    public static void Main(string[] args)
    {
        var problem = new ProblemC();
        problem.Solve();
    }

    /// <summary>
    /// Colorful Beans
    /// </summary>
    public void Solve()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var AC = new int[N, 2];

        for (int i = 0; i < N; i++)
        {
            var input = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            AC[i, 0] = input[0];
            AC[i, 1] = input[1];
        }

        var dic = new SortedDictionary<int, int>();
        dic.Add(AC[0, 1], AC[0, 0]);

        var valueArray = new List<int>();

        for (int i = 1; i < N; i++)
        {
            var A = AC[i, 0];
            var C = AC[i, 1];

            if (!dic.ContainsKey(C))
            {
                //色が異なる場合追加
                dic.Add(C, A);
            }
            else
            {
                //色が同じものがある場合、おいしさの低い方を選ぶ
                if (A < dic[C])
                {
                    dic[C] = A;
                }
            }
        }

        var ans = dic.Values.Max();
        Console.WriteLine(ans);
    }
}
