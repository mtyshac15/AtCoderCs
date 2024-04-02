using AtCoder.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ABC212
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {
        }

        public override void SolveB()
        {
        }

        public override void SolveC()
        {
            var (N, M) = IOLibrary.ReadInt2();
            var A = IOLibrary.ReadLongArray();
            var B = IOLibrary.ReadLongArray();

            var sortedA = A.Distinct().ToArray().Sort();
            var sortedB = B.Distinct().ToArray().Sort();

            var ans = long.MaxValue;

            for (int i = 0; i < sortedA.Length; i++)
            {
                var a = sortedA[i];
                var index = MathLibrary.LowerBound(sortedB, a);

                {
                    var prevIndex = Math.Max(index - 1, 0);
                    var sub = Math.Abs(a - sortedB[prevIndex]);
                    ans = Math.Min(sub, ans);
                }

                {
                    var nextIndex = Math.Min(index, sortedB.Length - 1);
                    var sub = Math.Abs(a - sortedB[nextIndex]);
                    ans = Math.Min(sub, ans);
                }
            }

            IOLibrary.WriteLine(ans);
        }

        public override void SolveD()
        {
            var Q = IOLibrary.ReadInt();

            var array = new long[Q];
            var p2InsdexList = new List<int>();

            var subList = new List<long>();

            for (int i = 0; i < Q; i++)
            {
                var query = IOLibrary.ReadLine();
                var p = int.Parse(query[0].ToString());
                if (p == 1)
                {
                    var X = int.Parse(query[1].ToString());
                    array[i] = X;
                }
                else if (p == 2)
                {
                    var X = int.Parse(query[1].ToString());
                    array[i] = -X;
                    p2InsdexList.Add(i);
                }
                else if (p == 3)
                {
                    //集計
                }

            }
        }

        public override void SolveE()
        {

        }

        public override void SolveF()
        {

        }

        public override void SolveG()
        {

        }

        public override void SolveH()
        {

        }
    }
}

