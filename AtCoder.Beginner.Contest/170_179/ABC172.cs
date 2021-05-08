using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC172
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {
            var a = IOLibrary.ReadInt();
            var ans = a + a * a + a * a * a;
            IOLibrary.WriteLine(ans);
        }

        public override void SolveB()
        {
            var S = IOLibrary.ReadLine();
            var T = IOLibrary.ReadLine();
            var ans = S.Zip(T, (s, t) => (s != t) ? 1 : 0).Sum();
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

