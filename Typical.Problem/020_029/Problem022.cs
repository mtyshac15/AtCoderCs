using AtCoder.Common;
using System;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem022
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var (A, B, C) = IOLibrary.ReadLong3();

            //一辺の長さ
            var length = MathLibrary.GCD(A, B, C);

            var a = A / length - 1;
            var b = B / length - 1;
            var c = C / length - 1;
            var count = a + b + c;

            IOLibrary.WriteLine(count);
        }
    }
}
