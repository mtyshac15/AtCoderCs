using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC177
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {
            var (D, T, S) = IOLibrary.ReadInt3();
            var ans = S * T >= D;
            IOLibrary.WriteLine(IOLibrary.ToYesOrNo(ans));
        }

        public override void SolveB()
        {
            var S = IOLibrary.ReadLine();
            var T = IOLibrary.ReadLine();

            var ans = T.Length;

            for (var sIndex = 0; sIndex < S.Length - T.Length + 1; sIndex++)
            {
                var count = 0;
                for (var tIndex = 0; tIndex < T.Length; tIndex++)
                {
                    if (T[tIndex] != S[sIndex + tIndex])
                    {
                        count++;
                    }
                }

                ans = Math.Min(ans, count);
            }

            IOLibrary.WriteLine(ans);
        }

        public override void SolveC()
        {
            var N = IOLibrary.ReadInt();
            var A = IOLibrary.ReadLongArray();

            var partSumList = new List<ModInt>() { 0 };

            foreach (var a in A)
            {
                var sum = partSumList[partSumList.Count - 1] + a;
                partSumList.Add(sum);
            }

            ModInt ans = 0;
            for (var i = 0; i < N - 1; i++)
            {
                ModInt ai = A[i];
                // i+1からN番目までの和
                var sum = partSumList[partSumList.Count - 1] - partSumList[i + 1];

                ans += ai * sum;
            }

            IOLibrary.WriteLine(ans);
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

