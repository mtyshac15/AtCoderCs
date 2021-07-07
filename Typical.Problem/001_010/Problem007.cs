using AtCoder.Common;
using System;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem007
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var N = IOLibrary.ReadInt();
            var A = IOLibrary.ReadLongArray();
            var Q = IOLibrary.ReadInt();
            var B = IOLibrary.ReadLongArray(Q);

            var sortedA = A.Sort();

            for (int j = 0; j < Q; j++)
            {
                long b = B[j];
                long index = MathLibrary.LowerBound(sortedA, b);

                long leftIndex = Math.Max(index - 1, 0);
                long left = Math.Abs(b - sortedA[leftIndex]);

                long rightIndex = Math.Min(index, sortedA.Length - 1);
                long right = Math.Abs(b - sortedA[rightIndex]); ;
                long min = Math.Min(left, right);

                IOLibrary.WriteLine(min);
            }
        }
    }
}
