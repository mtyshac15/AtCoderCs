using AtCoder.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem048
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var (N, K) = IOLibrary.ReadInt2();

            var A = new int[N];
            var B = new int[N];
            for (int i = 0; i < N; i++)
            {
                var (a, b) = IOLibrary.ReadInt2();
                A[i] = a;
                B[i] = b;
            }

            var sub = A.Zip(B, (a, b) => a - b);

            var array = B.Concat(sub);
            var sortedArray = array.Sort().Reverse().ToArray();

            var ans = 0L;
            for (int i = 0; i < K; i++)
            {
                ans += sortedArray[i];
            }

            IOLibrary.WriteLine(ans);
        }
    }
}
