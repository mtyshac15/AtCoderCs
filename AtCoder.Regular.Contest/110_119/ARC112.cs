using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ARC112
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {
            var T = IOLibrary.ReadInt();

            for (var i = 0; i < T; i++)
            {
                var (L, R) = IOLibrary.ReadInt2();

                var ans = 0L;

                if (2 * L <= R)
                {
                    var maxCount = 0L;
                    {
                        var a = R;
                        var minB = L;
                        var maxB = a - minB;
                        maxCount += maxB - minB + 1;
                    }

                    ans += maxCount * (maxCount + 1) / 2;
                }

                IOLibrary.WriteLine(ans);
            }
        }

        public override void SolveB()
        {
            var (B, C) = IOLibrary.ReadLong2();

            var correctedB = B;
            var correctedC = C;

            if (correctedB < 0)
            {
                correctedC--;
                correctedB *= -1;
            }

            var exchange = correctedC;

            //Bより大きい数の個数
            //最初と最後に-1倍
            exchange -= 2;

            //-1を行う回数
            var maxNum = exchange / 2;

            //Bより小さい数の個数
            var rangeArray = new long[3][]
            {
            new long[2],
            new long[2],
            new long[2],
            };

            var minNum = 0L;
            {
                var quotient = correctedC / 2;
                //-1のみ行う場合
                rangeArray[0][1] = correctedB - 1;
                rangeArray[0][0] = Math.Min(correctedB - quotient, correctedB - 1);
            }

            if (correctedC >= 1)
            {
                exchange = correctedC;
                exchange--;
                var quotient = exchange / 2;

                //最初に-1倍する場合
                {
                    rangeArray[1][1] = Math.Min(-correctedB, correctedB - 1);
                    rangeArray[1][0] = Math.Min(-correctedB - quotient, correctedB - 1);
                }

                //最後に-1倍する場合
                {
                    var num = -(correctedB - 1);
                    rangeArray[2][1] = Math.Min(num, correctedB - 1);

                    num = -(correctedB - quotient);
                    rangeArray[2][0] = Math.Min(num, correctedB - 1);
                }
            }

            minNum += rangeArray[0][1] - rangeArray[0][0] + 1;
            if (rangeArray[1][1] == rangeArray[0][0])
            {
                minNum += rangeArray[0][1] - rangeArray[1][0] + 1;
            }
            else if (rangeArray[1][1] < rangeArray[0][0])
            {
                minNum += rangeArray[1][1] - rangeArray[1][0] + 1;
            }
            else
            {
                var duplicate = rangeArray[1][1] - rangeArray[0][0];
                var num = rangeArray[1][1] - rangeArray[1][0] + 1 - duplicate;
                minNum += num;
            }

            if (rangeArray[2][0] < rangeArray[1][0]
                || rangeArray[2][0] > rangeArray[1][1]
                && rangeArray[2][0] < rangeArray[0][0])
            {
                minNum++;
            }

            var count = maxNum + minNum + 1;
            IOLibrary.WriteLine(count);
        }

        public override void SolveC()
        {

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

