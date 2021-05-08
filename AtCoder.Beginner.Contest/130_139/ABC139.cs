using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC139
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {

        }

        public override void SolveB()
        {
            var (A, B) = IOLibrary.ReadInt2();
            if (B == 1)
            {
                Console.WriteLine(0);
                return;
            }

            var ans = (B - 2) / (A - 1) + 1;
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

