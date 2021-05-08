using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ARC113
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {
            var K = IOLibrary.ReadInt();

            var counts = new long[3];

            //a=b=c
            for (var a = 1; a * a * a <= K; a++)
            {
                counts[0]++;
            }

            //a=b
            for (var a = 1; a * a <= K; a++)
            {
                var minC = 1;
                var maxC = K / (a * a);

                var count = maxC - minC + 1;
                if (minC <= a && maxC >= a)
                {
                    count--;
                }

                counts[1] += count * 3;
            }

            //a<b<c
            for (var a = 1; a * a <= K; a++)
            {
                for (var b = a + 1; a * b <= K; b++)
                {
                    var minC = b + 1;
                    var maxC = K / (a * b);
                    if (maxC > b)
                    {
                        counts[2] += (maxC - minC + 1) * 6;
                    }
                }
            }

            IOLibrary.WriteLine(counts.Sum());
        }

        public override void SolveB()
        {
            var (A, B, C) = IOLibrary.ReadLong3();

            var list = new List<int>();

            ModInt.Init(10);
            ModInt a = A;

            ModInt num = 1;
            for (var i = 0; i < 10; i++)
            {
                num *= a;

                if (list.Contains(num.ToInt()))
                {
                    break;
                }

                list.Add(num.ToInt());
            }

            ModInt.Init(list.Count);
            var exp = ModInt.Pow(B, C);

            var index = (exp - 1).ToInt();
            var ans = list[index];
            IOLibrary.WriteLine(ans);
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

