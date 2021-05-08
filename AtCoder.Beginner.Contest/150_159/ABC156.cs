using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC156
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
            var N = IOLibrary.ReadInt();
            var X = IOLibrary.ReadIntArray();

            //Xの平均に近い整数
            var P = (int)(X.Average() + 0.5);

            var sumSquare = 0L;
            for (var i = 0; i < N; i++)
            {
                sumSquare += (X[i] - P) * (X[i] - P);
            }

            IOLibrary.WriteLine(sumSquare);
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

