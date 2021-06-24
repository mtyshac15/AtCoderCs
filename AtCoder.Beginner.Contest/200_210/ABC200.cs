using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC200
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {
            var N = IOLibrary.ReadInt();
            var ans = (N + 100 - 1) / 100;
            IOLibrary.WriteLine(ans);
        }

        public override void SolveB()
        {
            var (N, K) = IOLibrary.ReadInt2();
            long ans = N;
            for (int i = 0; i < K; i++)
            {
                if (ans % 200 == 0)
                {
                    ans /= 200;
                }
                else
                {
                    ans = ans * 1000 + 200;
                }
            }
            IOLibrary.WriteLine(ans);
        }

        public override void SolveC()
        {
            var N = IOLibrary.ReadInt();
            var A = IOLibrary.ReadLongArray();

            var array = new long[200];

            foreach (var a in A)
            {
                var index = a % 200;
                array[index]++;
            }

            var ans = 0L;

            foreach (var a in array)
            {
                var count = a * (a - 1) / 2;
                ans += count;
            }

            IOLibrary.WriteLine(ans);
        }

        public override void SolveD()
        {
            var N = IOLibrary.ReadInt();
            var A = IOLibrary.ReadLongArray();

            var BList = new List<int>[200];

            var count = Math.Min(N, 8);
            for (int i = 0; i < (1 << count); i++)
            {
                var index = 0L;
                var B = new List<int>();

                for (int j = 0; j < count; j++)
                {
                    if (MathLibrary.TestBit(i, j))
                    {
                        B.Add(j + 1);
                        index += A[j];
                        index %= 200;
                    }
                }

                if(BList[index]?.Count > 0)
                {
                    IOLibrary.WriteLine($"Yes");
                    IOLibrary.WriteLine($"{B.Count} {string.Join(" ", B)}");
                    var C = BList[index];
                    IOLibrary.WriteLine($"{C.Count} {string.Join(" ", C)}");
                    return;
                }
                else
                {
                    BList[index] = B;
                }
            }

            IOLibrary.WriteLine($"No");
        }

        public override void SolveE()
        {

        }

        public override void SolveF()
        {

        }
    }
}

