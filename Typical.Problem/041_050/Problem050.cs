using AtCoder.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem050
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var (N, L) = IOLibrary.ReadInt2();

            ModInt.Init();
            
            ModInt ans = 0L;

            //L段上る回数
            var step = N / L;
            for (int lStep = 0; lStep < step + 1; lStep++)
            {
                //1段上る回数
                var oneStep = N - L * lStep;
                var comb = ModInt.Combination(lStep + oneStep, lStep);
                ans += comb;
            }

            IOLibrary.WriteLine(ans);
        }
    }
}
