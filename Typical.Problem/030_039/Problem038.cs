using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem038
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var (A, B) = IOLibrary.ReadLong2();

            var max = 1000000000000000000;
            var gcd = MathLibrary.GCD(A, B);

            var r = B / gcd;
            if (r > max / A)
            {
                IOLibrary.WriteLine("Large");
            }
            else
            {
                var ans = A * r;
                IOLibrary.WriteLine(ans);
            }
        }

        private void OldSolve()
        {
            var (A, B) = IOLibrary.ReadLong2();

            var max = 1000000000000000000;
            var gcd = MathLibrary.GCD(A, B);

            var digitA = MathLibrary.Digits(A);

            var gcdB = B / gcd;
            var digitB = MathLibrary.Digits(gcdB);

            if (digitA + digitB - 2 > 18)
            {
                IOLibrary.WriteLine("Large");
                return;
            }

            //最高位の数
            var logNum = Math.Log10(A) + Math.Log10(gcdB) - 18;
            if (logNum > Math.Log10(2))
            {
                IOLibrary.WriteLine("Large");
                return;
            }

            var ans = A * gcdB;
            if (ans > max)
            {
                IOLibrary.WriteLine("Large");
            }
            else
            {
                IOLibrary.WriteLine(ans);
            }
        }
    }
}
