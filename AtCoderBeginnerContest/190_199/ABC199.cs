using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC199
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {
            var (A, B, C) = IOLibrary.ReadInt3();
            IOLibrary.WriteYesOrNo((A * A + B * B < C * C));
        }

        public override void SolveB()
        {
            var N = IOLibrary.ReadInt();
            var A = IOLibrary.ReadIntArray();
            var B = IOLibrary.ReadIntArray();

            var min = A.Max();
            var max = B.Min();

            var count = Math.Max(max - min + 1, 0);
            IOLibrary.WriteLine(count);
        }

        public override void SolveC()
        {
            var N = IOLibrary.ReadInt();
            var S = IOLibrary.ReadLine();
            var Q = IOLibrary.ReadInt();

            var isReverse = false;

            var ansCharArray = S.ToCharArray();
            for (var i = 0; i < Q; i++)
            {
                var (T, A, B) = IOLibrary.ReadInt3();
                if (T == 1)
                {
                    var a = A - 1;
                    var b = B - 1;

                    if (isReverse)
                    {
                        a = (a + N) % (2 * N);
                        b = (b + N) % (2 * N);
                    }

                    var tmpA = ansCharArray[a];
                    var tmpB = ansCharArray[b];
                    ansCharArray[a] = tmpB;
                    ansCharArray[b] = tmpA;
                }
                else
                {
                    isReverse = !isReverse;
                }
            }

            if (isReverse)
            {
                var firstHalf = ansCharArray.Take(N);
                var latterhalf = ansCharArray.Skip(N).Take(N);
                ansCharArray = latterhalf.Concat(firstHalf).ToArray();
            }

            var ans = new String(ansCharArray);
            Console.WriteLine(ansCharArray);
        }

        public override void SolveD()
        {
            var (N, M) = IOLibrary.ReadInt2();

        }

        public override void SolveE()
        {

        }

        public override void SolveF()
        {

        }
    }
}

