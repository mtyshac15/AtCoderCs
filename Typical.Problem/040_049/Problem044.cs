using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem044
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var (N, Q) = IOLibrary.ReadInt2();
            var A = IOLibrary.ReadLongArray();

            var indexArray = Enumerable.Range(0, N).ToArray();
            var shift = 0;
            for (int i = 0; i < Q; i++)
            {
                var (T, x, y) = IOLibrary.ReadInt3();

                if (T == 1)
                {
                    var indexX = (x - 1 + shift) % N;
                    var indexY = (y - 1 + shift) % N;

                    //xとyを入れ替え
                    var tmp = indexArray[indexX];
                    indexArray[indexX] = indexArray[indexY];
                    indexArray[indexY] = tmp;
                }
                else if (T == 2)
                {
                    shift--;
                    shift = (shift + N) % N;
                }
                else if (T == 3)
                {
                    var indexX = (x - 1 + shift) % N;
                    var index = indexArray[indexX];
                    IOLibrary.WriteLine(A[index]);
                }
            }
        }
    }
}
