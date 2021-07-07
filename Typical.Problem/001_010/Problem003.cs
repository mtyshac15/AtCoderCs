using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem003
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var N = IOLibrary.ReadInt();

            //隣接リストを作成
            var graph = new List<int>[N];
            for (int i = 0; i < N; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < N - 1; i++)
            {
                var (A, B) = IOLibrary.ReadInt2();
                graph[A - 1].Add(B - 1);
                graph[B - 1].Add(A - 1);
            }

            //グラフから頂点sを一つ選ぶ
            int s = 0;
            for (int i = 0; i < N; i++)
            {
                if (graph[i].Count == 1)
                {
                    s = i;
                    break;
                }
            }

            //sから距離が最大の頂点をvを算出
            var lengthArray = new int[N];
            var seen = new bool[N];
            this.Dfs(graph, s, lengthArray, seen);
            var v = this.GetFarthestVertex(s, lengthArray);

            //vからもっとも離れた点の距離を算出
            lengthArray = new int[N];
            seen = new bool[N];
            this.Dfs(graph, v, lengthArray, seen);
            var maxLength = lengthArray.Max();
            var ans = maxLength + 1;
            IOLibrary.WriteLine(ans);
        }

        private void Dfs(IList<IList<int>> graph, int v, int[] length, bool[] seen)
        {
            //vを探索済み
            seen[v] = true;

            //vに隣接しているノードを取得
            foreach (var nextV in graph[v])
            {
                if (!seen[nextV])
                {
                    //探索済みでなかったら、距離を加算
                    length[nextV] = length[v] + 1;
                    this.Dfs(graph, nextV, length, seen);
                }
            }
        }

        private int GetFarthestVertex(int v, int[] lengthArray)
        {
            var ans = v;

            //vから距離が最大のノードを取得
            var maxLength = 0;
            for (int i = 0; i < lengthArray.Length; i++)
            {
                var length = lengthArray[i];
                if (length > maxLength)
                {
                    maxLength = length;
                    ans = i;
                }
            }

            return ans;
        }
    }
}
