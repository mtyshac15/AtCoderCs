using AtCoder.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem052
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var N = IOLibrary.ReadInt();

            var ans = 1L;
            for (int i = 0; i < N; i++)
            {
                var A = IOLibrary.ReadIntArray();
                ans *= A.Sum();
                ans %= ModInt.MOD;
            }

            IOLibrary.WriteLine(ans);
        }
    }
}
