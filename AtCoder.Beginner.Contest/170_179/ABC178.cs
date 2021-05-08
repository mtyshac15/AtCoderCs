using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC178
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {
            var x = IOLibrary.ReadInt();
            IOLibrary.WriteLine(1 - x);
        }

        public override void SolveB()
        {
            var (a, b, c, d) = IOLibrary.ReadLong4();

            var x = new long[] { a, b };
            var y = new long[] { c, d };

            //直積
            var xy = x.SelectMany(n => y,
                                 (ex, ey) => ex * ey);

            IOLibrary.WriteLine(xy.Max());
        }

        public override void SolveC()
        {
            var N = IOLibrary.ReadLong();

            var all = ModInt.Pow(10, N);

            //0を含まない
            var not0 = ModInt.Pow(9, N);

            //9を含まない
            var not9 = not0;

            //0と9を含まない
            var not0Or9 = ModInt.Pow(8, N);

            var ans = all - not0 - not9 + not0Or9;
            IOLibrary.WriteLine(ans);
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

