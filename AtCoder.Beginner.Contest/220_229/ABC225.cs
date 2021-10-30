using AtCoder.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ABC225
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {
            var S = IOLibrary.ReadLine();
            var group = S.GroupBy(s => s);
            var count = group.Count();

            var ans = 6;
            if (count == 1)
            {
                ans = 1;
            }
            else if (count == 2)
            {
                ans = 3;
            }

            IOLibrary.WriteLine(ans);
        }

        public override void SolveB()
        {
            var N = IOLibrary.ReadInt();
            var graph = MathLibrary.GetGraph(N);

            for (int i = 0; i < N - 1; i++)
            {
                var (a, b) = IOLibrary.ReadInt2();
                graph[a - 1].Add(b - 1);
                graph[b - 1].Add(a - 1);
            }

            foreach (var list in graph)
            {
                if (list.Count == N - 1)
                {
                    IOLibrary.WriteYesOrNo(true);
                    return;
                }
            }

            IOLibrary.WriteYesOrNo(false);
        }

        public override void SolveC()
        {
            var (N, M) = IOLibrary.ReadLong2();
            var B = IOLibrary.ReadLong2DArray(N);

            var row = (B[0][0] + 6) / 7;

            var col = B[0][0] % 7;
            if (col == 0)
            {
                col = 7;
            }

            for (int n = 0; n < N; n++)
            {
                for (int m = 0; m < M; m++)
                {
                    var i = n + row;
                    var j = m + col;
                    if (j > 7)
                    {
                        IOLibrary.WriteYesOrNo(false);
                        return;
                    }

                    var num = (i - 1) * 7 + j;

                    if (B[n][m] != num)
                    {
                        IOLibrary.WriteYesOrNo(false);
                        return;
                    }
                }
            }

            IOLibrary.WriteYesOrNo(true);
        }

        public override void SolveD()
        {
            var (N, Q) = IOLibrary.ReadInt2();
            var graph = MathLibrary.GetGraph(N);
            var reverseGraph = MathLibrary.GetGraph(N);
            for (int i = 0; i < Q; i++)
            {
                var query = IOLibrary.ReadStringArray();
                var c = int.Parse(query[0]);
                if (c == 1)
                {
                    var x = int.Parse(query[1]);
                    var y = int.Parse(query[2]);

                    graph[x - 1].Add(y - 1);
                    reverseGraph[y - 1].Add(x - 1);
                }
                else if (c == 2)
                {
                    var x = int.Parse(query[1]);
                    var y = int.Parse(query[2]);

                    graph[x - 1].Remove(y - 1);
                    reverseGraph[y - 1].Remove(x - 1);
                }
                else if (c == 3)
                {
                    var x = int.Parse(query[1]);

                    var start = x - 1;
                    while (reverseGraph[start].Count > 0)
                    {
                        start = reverseGraph[start].FirstOrDefault();
                    }

                    var list = new List<int>();
                    list.Add(start + 1);

                    var node = start;
                    while (graph[node].Count > 0)
                    {
                        node = graph[node].FirstOrDefault();
                        list.Add(node + 1);
                    }

                    IOLibrary.WriteLine($"{list.Count} {string.Join(" ", list)}");
                }
            }
        }

        public override void SolveE()
        {

        }

        public override void SolveF()
        {

        }

        public override void SolveG()
        {

        }

        public override void SolveH()
        {

        }
    }
}

