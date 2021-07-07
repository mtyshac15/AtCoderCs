using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem033
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var (H, W) = IOLibrary.ReadInt2();
            if (H == 1 || W == 1)
            {
                var ans = H * W;
                IOLibrary.WriteLine(ans);
            }
            else
            {
                var ans = ((H + 1) / 2) * ((W + 1) / 2);
                IOLibrary.WriteLine(ans);
            }
        }
    }
}
