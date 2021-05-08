using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC171
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {
            var a = IOLibrary.ReadLine();
            var ans = char.IsUpper(a[0]) ? "A" : "a";
            IOLibrary.WriteLine(ans);
        }

        public override void SolveB()
        {
            var (N, K) = IOLibrary.ReadInt2();
            var p = IOLibrary.ReadIntArray();
            var total = p.Sort().Take(K).Sum();
            IOLibrary.WriteLine(total);
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

