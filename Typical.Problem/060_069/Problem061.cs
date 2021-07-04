using AtCoder.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem061
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var Q = IOLibrary.ReadInt();
            var tx = IOLibrary.ReadInt2DArray(Q);

            var array = new int[2 * Q];

            var topIndex = Q;
            var tailIndex = topIndex;

            for (int i = 0; i < Q; i++)
            {
                var t = tx[i][0];
                var x = tx[i][1];
                if (t == 1)
                {
                    topIndex--;
                    array[topIndex] = x;
                }
                else if (t == 2)
                {
                    array[tailIndex] = x;
                    tailIndex++;
                }
                else if (t == 3)
                {
                    IOLibrary.WriteLine(array[topIndex + x - 1]);
                }
            }
        }
    }
}
