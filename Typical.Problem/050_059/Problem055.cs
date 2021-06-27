using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem055
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var (N, P, Q) = IOLibrary.ReadInt3();
            var A = IOLibrary.ReadIntArray();

            ModInt.Init(P);
            var modIntA = A.Select(a => (ModInt)a).ToArray();

            var count = 0L;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    for (int k = 0; k < j; k++)
                    {
                        for (int l = 0; l < k; l++)
                        {
                            for (int m = 0; m < l; m++)
                            {
                                var product = modIntA[i] * modIntA[j] * modIntA[k] * modIntA[l] * modIntA[m];
                                if (product == Q)
                                {
                                    count++;
                                }
                            }
                        }
                    }
                }
            }

            IOLibrary.WriteLine(count);
        }

        private void OldSolve()
        {
            var (N, P, Q) = IOLibrary.ReadInt3();
            var A = IOLibrary.ReadIntArray();

            ModInt.Init(P);
            var modIntA = A.Select(a => (ModInt)a).ToArray();
            var count = 0L;
            foreach (var indexList in MathLibrary.GetCombinationIndexCollection(N, 5))
            {
                ModInt product = 1;
                foreach (var index in indexList)
                {
                    product *= modIntA[index];
                }

                if (product == Q)
                {
                    count++;
                }
            }

            IOLibrary.WriteLine(count);
        }

        private void OldSolve2()
        {
            var (N, P, Q) = IOLibrary.ReadInt3();
            var A = IOLibrary.ReadIntArray();

            var source = Enumerable.Range(0, N);
            ModInt.Init(P);
            var modIntA = A.Select(a => (ModInt)a).ToArray();

            var totalCount = 0L;
            foreach (var indexList in MathLibrary.GetCombinationIndexCollection(N, 4))
            {
                ModInt product = 1;
                foreach (var index in indexList)
                {
                    product *= modIntA[index];
                }

                var rIndexList = source.Except(indexList);
                var count = rIndexList.Count(x => x * product == Q);
                totalCount += count;
            }

            totalCount /= 5;
            IOLibrary.WriteLine(totalCount);
        }
    }
}
