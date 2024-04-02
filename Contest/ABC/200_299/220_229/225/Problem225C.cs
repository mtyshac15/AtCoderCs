using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC225
{
    public class ProblemC
    {
        public static void Main(string[] args)
        {
            var problem = new ProblemC();
            problem.Solve();
        }

        /// <summary>
        /// Calendar Validator
        /// </summary>
        public void Solve()
        {
            var input = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            var N = input[0];
            var M = input[1];

            var B = new int[N, M];

            for (var i = 0; i < N; i++)
            {
                var tmp = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

                for (var j = 0; j < M; j++)
                {
                    B[i, j] = tmp[j];
                }
            }

            //1行目を判定
            for (var col = 0; col < M; col++)
            {
                var num = B[0, col] % 7;

                //7で割った余りが0の数が、右端でない場合はNo
                if (num == 0
                    && col != M - 1)
                {
                    Console.WriteLine(ProblemC.ToYesOrNo(false));
                    return;
                }
            }

            //行方向 公差1の等差数列
            for (int row = 0; row < N; row++)
            {
                var num = B[row, 0];
                for (int col = 1; col < M; col++)
                {
                    var sub = B[row, col] - num;
                    if (sub != 1)
                    {
                        Console.WriteLine(ProblemC.ToYesOrNo(false));
                        return;
                    }

                    num = B[row, col];
                }
            }

            //列方向 公差7の等差数列
            for (int col = 0; col < M; col++)
            {
                var num = B[0, col];
                for (int row = 1; row < N; row++)
                {
                    var sub = B[row, col] - num;
                    if (sub != 7)
                    {
                        Console.WriteLine(ProblemC.ToYesOrNo(false));
                        return;
                    }

                    num = B[row, col];
                }
            }

            Console.WriteLine(ProblemC.ToYesOrNo(true));
        }

        public static string ToYesOrNo(bool value)
        {
            return value ? $"Yes" : $"No";
        }
    }
}
