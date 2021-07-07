using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem046
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var N = IOLibrary.ReadInt();

            var mod = 46;
            var A = IOLibrary.ReadIntArray();
            var B = IOLibrary.ReadIntArray();
            var C = IOLibrary.ReadIntArray();

            var sortedA = A.Select(x => x % mod).ToList();
            sortedA.Sort();

            var sortedB = B.Select(x => x % mod).ToList();
            sortedB.Sort();

            var sortedC = C.Select(x => x % mod).ToList();
            sortedC.Sort();

            var ans = 0L;

            for (int a = 0; a < mod; a++)
            {
                for (int b = 0; b < mod; b++)
                {
                    for (int c = 0; c < mod; c++)
                    {
                        var sum = a + b + c;
                        if (sum % mod == 0)
                        {
                            var countA = sortedA.LowerBound(a + 1) - sortedA.LowerBound(a);
                            var countB = sortedB.LowerBound(b + 1) - sortedB.LowerBound(b);
                            var countC = sortedC.LowerBound(c + 1) - sortedC.LowerBound(c);

                            var count = 1L;
                            count *= countA;
                            count *= countB;
                            count *= countC;
                            ans += count;
                        }
                    }
                }
            }

            IOLibrary.WriteLine(ans);
        }
    }
}
