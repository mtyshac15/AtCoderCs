using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC173
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {
            var N = IOLibrary.ReadInt();
            var money = 1000;
            var bills = (N + money - 1) / money;
            var change = money * bills - N;
            Console.WriteLine(change);
        }

        public override void SolveB()
        {
            var N = IOLibrary.ReadInt();
            var S = IOLibrary.ReadStringArray(N);

            var results = new string[]
            {
            $"AC",
            $"WA",
            $"TLE",
            $"RE",
            };

            var table = results.GroupJoin(S,
                                          r => r,
                                          c => c,
                                          (r, cArray) => new
                                          {
                                              Reult = r,
                                              Count = (cArray?.Count()).GetValueOrDefault(),
                                          });

            foreach (var item in table)
            {
                IOLibrary.WriteLine($"{item.Reult} x {item.Count}");
            }
        }

        public override void SolveC()
        {
            var (H, W, K) = IOLibrary.ReadInt3();
            var grid = IOLibrary.ReadStringArray(H);

            var ans = 0;

            for (var row = 0; row < (1 << H); row++)
            {
                for (var col = 0; col < (1 << W); col++)
                {
                    var black = 0;

                    for (var h = 0; h < H; h++)
                    {
                        for (var w = 0; w < W; w++)
                        {
                            if (MathLibrary.TestBit(row, h)
                                && MathLibrary.TestBit(col, w)
                                && grid[h][w] == '#')
                            {
                                black++;
                            }
                        }
                    }

                    if (black == K)
                    {
                        ans++;
                    }
                }
            }

            Console.WriteLine(ans);
        }

        public override void SolveD()
        {
            var N = IOLibrary.ReadInt();
            var A = IOLibrary.ReadLongArray();

            var sortedA = A.Sort().Reverse().ToArray();

            var ans = 0m;

            for (int i = 1; i < N; i++)
            {
                ans += sortedA[i / 2];
            }

            IOLibrary.WriteLine(ans);
        }

        public override void SolveE()
        {

        }

        public override void SolveF()
        {

        }
    }
}

