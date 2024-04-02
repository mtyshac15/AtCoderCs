using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC225
{
    public class ProblemB
    {
        public static void Main(string[] args)
        {
            var problem = new ProblemB();
            problem.Solve();
        }

        /// <summary>
        /// Star or Not
        /// </summary>
        public void Solve()
        {
            var input = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            var N = input[0];

            // 各ノードの次数を数える
            var count = new int[N + 1];

            var tree = new Dictionary<int, int>();

            for (int i = 0; i < N - 1; i++)
            {
                var tmp = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
                var a = tmp[0];
                var b = tmp[1];

                count[a]++;
                count[b]++;
            }

            //最大の辺を持つノードの辺の本数がN-1のときスター
            var isStar = count.Max() == N - 1;
            Console.WriteLine(ProblemB.ToYesOrNo(isStar));
        }

        public static string ToYesOrNo(bool value)
        {
            return value ? $"Yes" : $"No";
        }
    }
}
