using AtCoder.Common;
using System;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem020
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var (a, b, c) = IOLibrary.ReadLong3();

            ulong ans = 1;
            ulong uc = (ulong)c;
            for (int i = 0; i < b; i++)
            {
                ans *= uc;
            }
            IOLibrary.WriteYesOrNo((ulong)a < ans);
        }
    }
}
