using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC253;

public class ProblemC
{
    public static void Main(string[] args)
    {
        var problem = new ProblemC();
        problem.Solve();
    }

    /// <summary>
    /// Max - Min Query
    /// </summary>
    public void Solve()
    {
        var Q = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var dic = new SortedDictionary<int, long>();
        var list = new SortedList<int, int>();

        for (int i = 0; i < Q; i++)
        {
            var query = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            var num = query[0];
            if (num == 1)
            {
                var x = query[1];
                if (dic.ContainsKey(x))
                {
                    dic[x]++;
                }
                else
                {
                    dic.Add(x, 1);
                    list.Add(x, 0);
                }
            }
            else if (num == 2)
            {
                var x = query[1];
                var c = query[2];

                if (dic.ContainsKey(x))
                {
                    if (dic[x] > c)
                    {
                        dic[x] -= c;
                    }
                    else
                    {
                        dic.Remove(x);
                        list.Remove(x);
                    }
                }
            }
            else if (num == 3)
            {
                var ans = list.Keys[list.Count - 1] - list.Keys[0];
                Console.WriteLine(ans);
            }
        }
    }
}
