using AtCoder.Common;
using System;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem013
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var N = IOLibrary.ReadInt();
            var A = IOLibrary.ReadLongArray();
            var B = IOLibrary.ReadLongArray();

            var sortedA = A.Sort();
            var sortedB = B.Sort();
            var ans = sortedA.Zip(sortedB, (a, b) => Math.Abs(a - b)).Sum();
            IOLibrary.WriteLine(ans);
        }
    }
}
