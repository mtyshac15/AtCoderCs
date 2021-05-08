using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC174
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {
            var X = IOLibrary.ReadInt();
            var ans = X >= 30;
            IOLibrary.WriteLine(IOLibrary.ToYesOrNo(ans));
        }

        public override void SolveB()
        {
            var (N, D) = IOLibrary.ReadLong2();
            var pointArray = IOLibrary.ReadLong2DArray(N);

            var count = 0;
            for (var i = 0; i < N; i++)
            {
                var (X, Y) = IOLibrary.ReadLong2();
                var distanceSquare = X * Y + Y * Y;
                if (distanceSquare <= D * D)
                {
                    count++;
                }
            }

            IOLibrary.WriteLine(count);
        }

        public override void SolveC()
        {
            var K = IOLibrary.ReadInt();
            ModInt.Init(K);

            ModInt a = 7;
            for (var i = 1; i <= K; i++)
            {
                if (a == 0)
                {
                    IOLibrary.WriteLine(i);
                    return;
                }

                a = 10 * a + 7;
            }

            IOLibrary.WriteLine(-1);
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

