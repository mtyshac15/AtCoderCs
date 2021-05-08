using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC194
{
    public class Problem : ProblemBase
    {
        /// <summary>
        /// 
        /// </summary>
        public override void SolveA()
        {
            var (A, B) = IOLibrary.ReadInt2();
            var milkSolids = A + B;
            var milkFat = B;
            if (milkSolids >= 15 && milkFat >= 8)
            {
                IOLibrary.WriteLine(1);
            }
            else if (milkSolids >= 10 && milkFat >= 3)
            {
                IOLibrary.WriteLine(2);
            }
            else if (milkSolids >= 3)
            {
                IOLibrary.WriteLine(3);
            }
            else
            {
                IOLibrary.WriteLine(4);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveB()
        {
            var N = IOLibrary.ReadInt();

            var AB = IOLibrary.ReadInt2DArray(N);

            var indexA = 0;
            var minA = int.MaxValue;

            for (var i = 0; i < N; i++)
            {
                var a = AB[i][0];
                if(a < minA)
                {
                    minA = a;
                    indexA = i;
                }
            }

            var minB = int.MaxValue;
            for (var i = 0; i < N; i++)
            {
                if(i != indexA)
                {
                    var b = AB[i][1];
                    minB = Math.Min(b, minB);
                }
            }

            var min = Math.Max(minA, minB);

            //一人がA,Bを行った場合
            var minSum = AB.Select(item => item[0] + item[1]).Min();
            min = Math.Min(minSum, min);

            IOLibrary.WriteLine(min);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveC()
        {

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