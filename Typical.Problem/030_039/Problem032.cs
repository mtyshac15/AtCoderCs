using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem032
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var N = IOLibrary.ReadInt();
            var A = IOLibrary.ReadInt2DArray(N, N);
            var M = IOLibrary.ReadInt();
            var XY = IOLibrary.ReadInt2DArray(M, 2);

            var isHate = new bool[N, N];
            for (int i = 0; i < M; i++)
            {
                isHate[XY[i, 0] - 1, XY[i, 1] - 1] = true;
                isHate[XY[i, 1] - 1, XY[i, 0] - 1] = true;
            }

            var min = long.MaxValue;

            foreach (var indexArray in MathLibrary.AllPermutation(N))
            {
                var total = 0L;
                var hasPath = true;
                var zone = 0;
                for (int i = 0; i < indexArray.Count; i++)
                {
                    var current = indexArray[i];
                    total += A[current, zone];
                    zone++;

                    if (i < indexArray.Count - 1)
                    {
                        var next = indexArray[i + 1];
                        if (isHate[current, next])
                        {
                            hasPath = false;
                            break;
                        }
                    }
                }

                if (hasPath)
                {
                    min = Math.Min(total, min);
                }
            }

            var ans = (min == long.MaxValue) ? -1 : min;
            IOLibrary.WriteLine(ans);
        }
    }
}
