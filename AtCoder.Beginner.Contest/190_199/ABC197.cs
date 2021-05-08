using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC197
{
    public class Problem : ProblemBase
    {
        /// <summary>
        /// 
        /// </summary>
        public override void SolveA()
        {
            var S = IOLibrary.ReadLine();
            IOLibrary.WriteLine(S[1].ToString() + S[2].ToString() + S[0].ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveB()
        {
            var (H, W, X, Y) = IOLibrary.ReadInt4();
            var S = IOLibrary.ReadStringArray(H);

            var x = X - 1;
            var y = Y - 1;

            var count = 1;

            //上
            for (var h = x - 1; h >= 0; h--)
            {
                if (S[h][y] == '#')
                {
                    break;
                }
                count++;
            }

            //下
            for (var h = x + 1; h < H; h++)
            {
                if (S[h][y] == '#')
                {
                    break;
                }
                count++;
            }

            //左
            for (var w = y - 1; w >= 0; w--)
            {
                if (S[x][w] == '#')
                {
                    break;
                }
                count++;
            }

            //右
            for (var w = y + 1; w < W; w++)
            {
                if (S[x][w] == '#')
                {
                    break;
                }
                count++;
            }

            IOLibrary.WriteLine(count);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveC()
        {
            var N = IOLibrary.ReadInt();
            var A = IOLibrary.ReadLongArray();

            var min = long.MaxValue;
            for (var i = 0; i < 1 << (N - 1); i++)
            {
                var or = 0L;
                var xor = 0L;
                for (var j = 0; j <= N; j++)
                {
                    if (j < N)
                    {
                        or |= A[j];
                    }

                    if (j == N || MathLibrary.TestBit(i, j))
                    {
                        xor ^= or;
                        or = 0;
                    }
                }

                min = Math.Min(xor, min);
            }

            IOLibrary.WriteLine(min);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveD()
        {
            var N = IOLibrary.ReadInt();

            var (x0, y0) = IOLibrary.ReadInt2();
            var (xn, yn) = IOLibrary.ReadInt2();

            var centerX = ((double)x0 + xn) / 2;
            var centerY = ((double)y0 + yn) / 2;

            var vectorX = x0 - centerX;
            var vectorY = y0 - centerY;

            var theta = 2 * Math.PI / N;

            var x1 = Math.Cos(theta) * vectorX - Math.Sin(theta) * vectorY + centerX;
            var y1 = Math.Sin(theta) * vectorX + Math.Cos(theta) * vectorY + centerY;

            IOLibrary.WriteLine($"{x1} {y1}");
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveE()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveF()
        {

        }
    }
}