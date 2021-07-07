using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem027
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var N = IOLibrary.ReadInt();
            var S = IOLibrary.ReadStringArray(N);

            var hasSet = new HashSet<string>();
            for (int i = 0; i < N; i++)
            {
                var user = S[i];
                if (!hasSet.Contains(user))
                {
                    hasSet.Add(user);
                    IOLibrary.WriteLine(i + 1);

                }
            }
        }
    }
}
