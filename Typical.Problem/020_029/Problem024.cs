using AtCoder.Common;
using System;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem024
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var (N, K) = IOLibrary.ReadInt2();
            var A = IOLibrary.ReadIntArray();
            var B = IOLibrary.ReadIntArray();

            //最短回数
            var minCount = A.Zip(B, (a, b) => Math.Abs((long)a - b)).Sum();
            if (minCount > K)
            {
                IOLibrary.WriteYesOrNo(false);
                return;
            }

            var remaider = K - minCount;
            IOLibrary.WriteYesOrNo(remaider % 2 == 0);
        }
    }
}
