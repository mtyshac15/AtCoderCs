using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ARC110
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {
            var N = IOLibrary.ReadInt();
            var list = Enumerable.Range(1, N);
            var ans = MathLibrary.LCM(list);
            Console.WriteLine(ans + 1);
        }

        public override void SolveB()
        {
            var N = IOLibrary.ReadInt();
            var T = IOLibrary.ReadLine();

            var num = 10000000000;

            if (N == 1)
            {
                if (T == "0")
                {
                    IOLibrary.WriteLine(num);
                }
                else
                {
                    IOLibrary.WriteLine(2 * num);
                }
                return;
            }
            else if (N == 2)
            {
                if (T == "00")
                {
                    IOLibrary.WriteLine(0);
                }
                if (T == "10"
                    || T == "11")
                {
                    IOLibrary.WriteLine(num);
                }
                else
                {
                    IOLibrary.WriteLine(num - 1);
                }
                return;
            }

            //最初の3文字を取得
            var str = T.Substring(0, 3);

            if (!str.Contains("0")
                || !str.Contains("1")
                || str.Contains("00")
                || str.Contains("010"))
            {
                IOLibrary.WriteLine(0);
                return;
            }

            //3文字の繰り返しかどうか
            for (var i = 0; i < N / 3; i++)
            {
                if (str[0] != T[3 * i]
                    || str[1] != T[3 * i + 1]
                    || str[2] != T[3 * i + 2])
                {
                    IOLibrary.WriteLine(0);
                    return;
                }
            }

            var q = N / 3;
            for (var i = 0; i < N % 3; i++)
            {
                if (str[i] != T[3 * q + i])
                {
                    IOLibrary.WriteLine(0);
                }
            }

            //開始位置
            var numOfTimes = num / q;
            var startIndex = "110110".IndexOf(str);
            if (startIndex == 0)
            {
                IOLibrary.WriteLine(numOfTimes);
            }
            else
            {
                IOLibrary.WriteLine(numOfTimes - 1);
            }
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

