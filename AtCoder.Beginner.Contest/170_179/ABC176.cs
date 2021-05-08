using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XXX
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {
            var (N, X, T) = IOLibrary.ReadInt3();
            var times = (N + X - 1) / X;
            var t = times * T;
            IOLibrary.WriteLine(t);
        }

        public override void SolveB()
        {
            var input = IOLibrary.ReadLine();
            ModInt.Init(9);
            ModInt sum = 0;

            foreach (var c in input)
            {
                var num = int.Parse(c.ToString());
                sum += num;
            }

            var ans = sum == 0;
            IOLibrary.WriteLine(IOLibrary.ToYesOrNo(ans));
        }

        public override void SolveC()
        {
            var N = IOLibrary.ReadInt();
            var A = IOLibrary.ReadLongArray();

            var ans = 0L;
            var maxNum = 0L;

            for (var i = 0; i < N; i++)
            {
                maxNum = Math.Max(maxNum, A[i]);
                ans += maxNum - A[i];
            }

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

