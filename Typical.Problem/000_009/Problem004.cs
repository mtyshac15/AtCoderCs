using AtCoder.Common;
using System;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem004
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var (H, W) = IOLibrary.ReadInt2();
            var A = IOLibrary.ReadInt2DArray(H, W);

            var rowArray = new int[H];
            var colArray = new int[W];

            //合計
            for (int h = 0; h < H; h++)
            {
                for (int w = 0; w < W; w++)
                {
                    rowArray[h] += A[h, w];
                    colArray[w] += A[h, w];
                }
            }

            //出力
            for (int h = 0; h < H; h++)
            {
                var ansArray = new int[W];
                for (int w = 0; w < W; w++)
                {
                    ansArray[w] = rowArray[h] + colArray[w] - A[h, w];
                }

                var ans = string.Join(" ", ansArray);
                IOLibrary.WriteLine(ans);
            }
        }
    }
}
