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

            //タップがn個のとき、差込口は A*n - (n-1)
            // (B-1)/(A-1)
            var ans = (B - 1 + A - 1 - 1) / (A - 1);
            Console.WriteLine(ans);
        }

        private void OldSolveB()
        {
            var (A, B) = IOLibrary.ReadInt2();
            if (B == 1)
            {
                // タップは不要
                Console.WriteLine(0);
                return;
            }

            //タップがn個のとき、差込口は A*n - (n-1)
            //((B-1) + (A-1) - 1)/(A-1)
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

