using AtCoder.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem078
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var (N, M) = IOLibrary.ReadInt2();

            //隣接リストを作成
            var graph = new List<int>[N];
            for (int i = 0; i < N; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < M; i++)
            {
                var (a, b) = IOLibrary.ReadInt2();
                graph[a - 1].Add(b - 1);
                graph[b - 1].Add(a - 1);
            }

            var ans = 0;
            for (int i = 0; i < N; i++)
            {
                var v = graph[i];
                v.Sort();
                var count = v.UpperBound(i);
                if (count == 1)
                {
                    ans++;
                }
            }

            IOLibrary.WriteLine(ans);
        }
    }
}
