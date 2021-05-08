using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC175
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {
            var S = IOLibrary.ReadLine();

            var count = 0;
            var strR = "R";
            for (var i = 0; i < S.Length; i++)
            {
                //Rがi+1回連続した文字列を含むか
                if (!S.Contains(strR))
                {
                    IOLibrary.WriteLine(count);
                    return;
                }
                else
                {
                    count++;
                    strR += "R";
                }
            }

            IOLibrary.WriteLine(count);
        }

        public override void SolveB()
        {
            var N = IOLibrary.ReadInt();
            var L = IOLibrary.ReadIntArray();
            var sortedL = L.Sort();

            if (N < 3)
            {
                Console.WriteLine(0);
                return;
            }

            var count = 0;
            foreach (var combinationIndex in MathLibrary.GetCombinationIndexCollection(N, 3))
            {
                var i = combinationIndex[0];
                var j = combinationIndex[1];
                var k = combinationIndex[2];

                if (sortedL[i] != sortedL[j]
                    && sortedL[j] != sortedL[k]
                    && sortedL[i] + sortedL[j] > sortedL[k])
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        public override void SolveC()
        {
            var (X, K, D) = IOLibrary.ReadLong3();

            //原点の方向へ移動する回数
            var startX = Math.Abs(X);

            var count = startX / D;
            var remainder = startX - D * K;
            if (count > K)
            {
                //同じ方向へK回移動
                IOLibrary.WriteLine(remainder);
                return;
            }

            var remainingNum = K - count;
            var currentX = startX - D * count;

            if (remainingNum % 2 == 0)
            {
                //残り回数が偶数の場合
                //正の方向と負の方向に同じ回数だけ移動
                IOLibrary.WriteLine(currentX);
            }
            else
            {
                //残り回数が偶数の場合
                //1度だけ原点の方向へD移動し、
                //残りを正の方向と負の方向に同じ回数だけ移動
                currentX = Math.Abs(currentX - D);
                IOLibrary.WriteLine(currentX);
            }
        }

        public override void SolveD()
        {

        }

        public override void SolveE()
        {

        }

        public override void SolveF()
        {

        }
    }
}

