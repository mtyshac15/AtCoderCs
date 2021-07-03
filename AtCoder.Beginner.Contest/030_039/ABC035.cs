using AtCoder.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ABC035
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {

        }

        public override void SolveB()
        {

        }

        public override void SolveC()
        {

        }

        private struct Edge
        {
            public Edge(int to, long cost)
            {
                this.To = to;
                this.Cost = cost;
            }

            public int To { get; }

            public long Cost { get; }
        }

        public override void SolveD()
        {
            var (N, M, T) = IOLibrary.ReadInt3();
            var A = IOLibrary.ReadIntArray();

            //隣接リストを作成
            var graph = new List<Edge>[N];
            var reverseGraph = new List<Edge>[N];
            for (int i = 0; i < N; i++)
            {
                graph[i] = new List<Edge>();
                reverseGraph[i] = new List<Edge>();
            }

            for (int i = 0; i < M; i++)
            {
                var (a, b, c) = IOLibrary.ReadInt3();
                graph[a - 1].Add(new Edge(b - 1, c));

                //逆向きのグラフ
                reverseGraph[b - 1].Add(new Edge(a - 1, c));
            }

            //1からkへの最短時間
            var toArray = this.Dijkstra(graph,  0);

            //iから1への最短時間
            var fromArray = this.Dijkstra(reverseGraph,  0);

            var ans = 0L;
            for (int i = 0; i < N; i++)
            {
                var time = T - toArray[i] - fromArray[i];
                if (time >= 0)
                {
                    var gold = A[i] * time;
                    ans = Math.Max(gold, ans);
                }
            }

            IOLibrary.WriteLine(ans);
        }

        private IList<long> Dijkstra(IList<IList<Edge>> graph, int startIndex)
        {
            var n = graph.Count;
            var toArray = Enumerable.Repeat(long.MaxValue, n).ToArray();

            //最短時間が確定したノード
            var used = new bool[n];

            var currentIndex = startIndex;
            used[currentIndex] = true;
            toArray[currentIndex] = 0;

            while (used.Any(flag => !flag))
            {
                foreach (var edge in graph[currentIndex])
                {
                    var cost = toArray[currentIndex] + edge.Cost;
                    toArray[edge.To] = Math.Min(cost, toArray[edge.To]);
                }

                //最小のノードを探索
                var minNode = -1;
                var minCost = long.MaxValue;
                for (int i = 0; i < n; i++)
                {
                    if (!used[i] && toArray[i] < minCost)
                    {
                        minNode = i;
                        minCost = toArray[i];
                    }
                }

                //探索済みに追加
                if (minNode != -1)
                {
                    used[minNode] = true;
                    currentIndex = minNode;
                }
            }

            return toArray;
        }

        public override void SolveE()
        {

        }

        public override void SolveF()
        {

        }
    }
}

