using AtCoder.Common;
using System;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem010
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var N = IOLibrary.ReadInt();
            var CP = IOLibrary.ReadInt2DArray(N, 2);
            var Q = IOLibrary.ReadInt();
            var LR = IOLibrary.ReadInt2DArray(Q, 2);

            var classScore = new long[2, N + 1];

            //集計
            for (int i = 1; i <= N; i++)
            {
                var c = CP[i - 1, 0];
                var p = CP[i - 1, 1];
                classScore[c - 1, i] = p;

                classScore[0, i] += classScore[0, i - 1];
                classScore[1, i] += classScore[1, i - 1];
            }

            for (int i = 0; i < Q; i++)
            {
                var l = LR[i, 0];
                var r = LR[i, 1];

                var A = classScore[0, r] - classScore[0, l - 1];
                var B = classScore[1, r] - classScore[1, l - 1];

                IOLibrary.WriteLine($"{A} {B}");
            }
        }
    }
}
