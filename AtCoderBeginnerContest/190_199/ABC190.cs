using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC190
{
    public class Problem : ProblemBase
    {
        /// <summary>
        /// 
        /// </summary>
        public override void SolveA()
        {
            var (A, B, C) = IOLibrary.ReadInt3();

            if (A == B)
            {
                var winner = (C == 0) ? "Aoki" : "Takahashi";
                IOLibrary.WriteLine(winner);
            }
            else
            {
                var winner = (A < B) ? "Aoki" : "Takahashi";
                IOLibrary.WriteLine(winner);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveB()
        {
            var (N, S, D) = IOLibrary.ReadLong3();
            for (var i = 0; i < N; i++)
            {
                var (x, y) = IOLibrary.ReadLong2();
                if (x < S && y > D)
                {
                    IOLibrary.WriteLine(IOLibrary.ToYesOrNo(true));
                    return;
                }
            }

            IOLibrary.WriteLine(IOLibrary.ToYesOrNo(false));
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveC()
        {
            var (N, M) = IOLibrary.ReadInt2();
            var AB = IOLibrary.ReadInt2DArray(M, 2);
            var K = IOLibrary.ReadInt();
            var CD = IOLibrary.ReadInt2DArray(K, 2);

            var maxCount = 0;

            for (var bit = 0; bit < (1 << K); bit++)
            {
                var dish = new int[N];
                for (var i = 0; i < K; i++)
                {
                    var index = MathLibrary.TestBit(bit, i) ? 1 : 0;
                    var cd = CD[i, index] - 1;
                    dish[cd]++;
                }

                //集計
                var count = 0;
                for (var i = 0; i < M; i++)
                {
                    var a = AB[i, 0] - 1;
                    var b = AB[i, 1] - 1;

                    if (dish[a] > 0 && dish[b] > 0)
                    {
                        count++;
                    }
                }

                maxCount = Math.Max(maxCount, count);
            }

            Console.WriteLine(maxCount);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveD()
        {
            var N = IOLibrary.ReadLong();
            var ng = 2 * (long)Math.Sqrt(N);
            var ok = 0L;

            //1+・・・+k<=Nを満たす最大のkを求める
            while (Math.Abs(ok - ng) > 1)
            {
                var middle = ok + (ng - ok) / 2;
                //1からkまでの和
                var sum = middle * (middle + 1) / 2;
                if (sum <= N + 1)
                {
                    ok = middle;
                }
                else
                {
                    ng = middle;
                }
            }

            var maxNum = ok;
            var count = 0;

            for (var num = 1; num <= maxNum; num++)
            {
                var a = N / num - 1;

                for (var middle = a - 1; middle <= a + 1; middle++)
                {
                    var end = middle + num / 2;
                    var sum = end * (end + 1) / 2 - (end - num) * (end - num + 1) / 2;
                    if (sum == N)
                    {
                        count += 2;
                    }
                }
            }

            Console.WriteLine(count);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveE()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveF()
        {

        }
    }
}