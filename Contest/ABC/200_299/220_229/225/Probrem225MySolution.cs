using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderCs.Contest.ABC225;

public class MySolution
{
    public void OldB()
    {
        var input = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = input[0];

        // 各ノードの次数を数える
        var tree = new Dictionary<int, int>();

        for (int i = 0; i < N - 1; i++)
        {
            var tmp = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            var a = tmp[0];
            var b = tmp[1];

            if (!tree.ContainsKey(a))
            {
                tree.Add(a, 1);
            }
            else
            {
                tree[a]++;
            }

            if (!tree.ContainsKey(b))
            {
                tree.Add(b, 1);
            }
            else
            {
                tree[b]++;
            }
        }

        //最大の辺を持つノードの辺の本数がN-1のときスター
        var isStar = tree.Values.Max() == N - 1;
        Console.WriteLine(MySolution.ToYesOrNo(isStar));
    }

    public void OldB2()
    {
        var input = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = input[0];

        //隣接リストを作成
        var graph = new List<IList<int>>();
        for (int i = 0; i < N + 1; i++)
        {
            graph.Add(new List<int>());
        }

        for (int i = 0; i < N - 1; i++)
        {
            var tmp = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            var a = tmp[0];
            var b = tmp[1];

            graph[a].Add(b);
            graph[b].Add(a);
        }

        foreach (var list in graph)
        {
            // 隣接するノードの個数がN-1個のノードが存在した場合はスター
            if (list.Count == N - 1)
            {
                Console.WriteLine(MySolution.ToYesOrNo(true));
                return;
            }
        }

        Console.WriteLine(MySolution.ToYesOrNo(false));
    }

    public static string ToYesOrNo(bool value)
    {
        return value ? $"Yes" : $"No";
    }
}
