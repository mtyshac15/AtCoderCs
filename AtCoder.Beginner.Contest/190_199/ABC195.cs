using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC195
{
    public class Problem : ProblemBase
    {
        /// <summary>
        /// 
        /// </summary>
        public override void SolveA()
        {
            var (M, H) = IOLibrary.ReadInt2();
            IOLibrary.WriteYesOrNo(H % M == 0);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveB()
        {
            var (A, B, W) = IOLibrary.ReadInt3();

            var min = (W * 1000 + B - 1) / B;
            var max = W * 1000 / A;

            if (min <= max)
            {
                IOLibrary.WriteLine($"{min} {max}");
            }
            else
            {
                IOLibrary.WriteLine($"UNSATISFIABLE");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveC()
        {
            var N = IOLibrary.ReadLong();

            var ans = 0L;

            var digits = N.Digits();
            var maxCommaCount = (digits - 1) / 3;
            for (var i = 1; i <= maxCommaCount; i++)
            {
                var min = MathLibrary.Pow(1000, i);
                var max = MathLibrary.Pow(1000, i + 1) - 1;
                max = Math.Min(max, N);
                ans += i * (max - min + 1);
            }

            IOLibrary.WriteLine(ans);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveD()
        {

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