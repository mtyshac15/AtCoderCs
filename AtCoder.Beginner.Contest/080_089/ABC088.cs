using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC088
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {

        }

        public override void SolveB()
        {
            var N = IOLibrary.ReadInt();
            var a = IOLibrary.ReadIntArray();
            var sortedA = a.Sort();

            var ans = 0;
            var sign = 1;
            for (int i = N - 1; i >= 0; i--)
            {
                ans += sign * sortedA[i];
                sign *= -1;
            }

            Console.WriteLine(ans);
        }

        private void OldSolveB()
        {
            var N = IOLibrary.ReadInt();
            var a = IOLibrary.ReadIntArray();
            var sortedA = a.Sort()
                           .Reverse()
                           .Select((a, index) => new
                           {
                               Value = a,
                               Index = index,
                           });

            var AliceSum = sortedA.Where(a => a.Index % 2 == 0).Sum(a => a.Value);
            var BobSum = sortedA.Where(a => a.Index % 2 != 0).Sum(a => a.Value);

            var ans = AliceSum - BobSum;
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

