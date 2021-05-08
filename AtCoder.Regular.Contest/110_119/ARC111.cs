using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ARC111
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {
            var (N, M) = IOLibrary.ReadLong2();
            ModInt.Init((int)(M * M));
            var product = ModInt.Pow(10, N);
            var ans = product.ToInt() / M;
            IOLibrary.WriteLine(ans);
        }

        public override void SolveB()
        {
            var N = IOLibrary.ReadInt();

            var abArray = IOLibrary.ReadInt2DArray(N);

            var max = 400000;
            var sum = new int[max];

            var ans = 0;
            for (var i = 0; i < N; i++)
            {
                var (a, b) = IOLibrary.ReadInt2();

                if (sum[a] == 0)
                {
                    ans++;
                }
                else if (sum[b] == 0)
                {
                    ans++;
                }
            }

            Console.WriteLine(ans);
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

