using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC157
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {

        }

        public override void SolveB()
        {
            var gridNum = 3;
            var A = IOLibrary.ReadInt2DArray(gridNum, gridNum);
            var N = IOLibrary.ReadInt();
            var b = new int[N];
            for (var i = 0; i < N; i++)
            {
                b[i] = IOLibrary.ReadInt();
            }

            var judgeList = new bool[gridNum, gridNum];

            for (var i = 0; i < gridNum; i++)
            {
                for (var j = 0; j < gridNum; j++)
                {
                    //数字をマーク
                    var num = A[i, j];
                    if (b.Contains(num))
                    {
                        judgeList[i, j] = true;
                    }
                }
            }

            //ビンゴかどうかチェック
            //横
            for (var i = 0; i < gridNum; i++)
            {
                if (judgeList[i, 0] & judgeList[i, 1] & judgeList[i, 2])
                {
                    Console.WriteLine(IOLibrary.ToYesOrNo(true));
                    return;
                }
            }

            //縦
            for (var i = 0; i < gridNum; i++)
            {
                if (judgeList[0, i] & judgeList[1, i] & judgeList[2, i])
                {
                    Console.WriteLine(IOLibrary.ToYesOrNo(true));
                    return;
                }
            }

            //ななめ
            if (judgeList[0, 0] & judgeList[1, 1] & judgeList[2, 2]
                || judgeList[0, 2] & judgeList[1, 1] & judgeList[2, 0])
            {
                Console.WriteLine(IOLibrary.ToYesOrNo(true));
                return;
            }

            Console.WriteLine(IOLibrary.ToYesOrNo(false));
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

