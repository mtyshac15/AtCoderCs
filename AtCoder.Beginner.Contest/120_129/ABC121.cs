using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC121
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {

        }

        public override void SolveB()
        {
            var (N, M, C) = IOLibrary.ReadInt3();
            var B = IOLibrary.ReadIntArray();
            var A = IOLibrary.ReadInt2DArray(N);

            var count = 0;
            for (var i = 0; i < N; i++)
            {
                var sum = C;
                for (var j = 0; j < M; j++)
                {
                    sum += A[i][j] * B[j];
                }

                if (sum > 0)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        public override void SolveC()
        {

        }

        public override void SolveD()
        {

        }

        public override void SolveE()
        {

        }

        public override void SolveF()
        {

        }
    }
}

