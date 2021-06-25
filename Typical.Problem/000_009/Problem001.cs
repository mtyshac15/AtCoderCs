using AtCoder.Common;
using System;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem01
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var (N, L) = IOLibrary.ReadLong2();
            var K = IOLibrary.ReadLong();
            var A = IOLibrary.ReadLongArray();

            var collection = A.Prepend(0).Append(L).FloorDiff();
            var ans = collection.Sort().Skip(N - K).FirstOrDefault();
            IOLibrary.WriteLine(ans);
        }
    }
}
