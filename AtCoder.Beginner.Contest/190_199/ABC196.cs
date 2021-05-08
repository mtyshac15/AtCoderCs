using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC196
{
    public class Problem : ProblemBase
    {
        /// <summary>
        /// 
        /// </summary>
        public override void SolveA()
        {
            var (a, b) = IOLibrary.ReadInt2();
            var (c, d) = IOLibrary.ReadInt2();
            IOLibrary.WriteLine(b - c);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveB()
        {
            var X = IOLibrary.ReadLine();
            var index = X.IndexOf('.');
            if (index == -1)
            {
                IOLibrary.WriteLine(X);
            }
            else
            {
                var str = X.Substring(0, index);
                IOLibrary.WriteLine(str);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveC()
        {
            var N = IOLibrary.ReadLong();

            //上位桁半分
            var nStr = N.ToString();
            var upperNum = long.Parse(nStr.Substring(0, nStr.Length / 2));

            var num = long.Parse(upperNum.ToString() + upperNum.ToString());
            if (num > N)
            {
                upperNum--;
            }

            IOLibrary.WriteLine(upperNum);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveD()
        {
            var (H, W, A, B) = IOLibrary.ReadInt4();

            var hLineList = new List<int[]>();
            for (var h = 0; h < H; h++)
            {
                for (var w = 1; w < W; w++)
                {
                    var line = new int[] { h, w, h + 1, w };
                    hLineList.Add(line);
                }
            }

            var wLineList = new List<int[]>();
            for (var w = 0; w < W; w++)
            {
                for (var h = 1; h < H; h++)
                {
                    var line = new int[] { h, w, h, w + 1 };
                    wLineList.Add(line);
                }
            }


            var allLineNum = hLineList.Count * wLineList.Count;
            var max = MathLibrary.Combination(allLineNum, A);

            var allLine = hLineList.Concat(wLineList);
            var count = 0;
            for (var i = 0; i < max; i++)
            {
                var deleteNum = 0;
                foreach (var line in allLine)
                {
                    if (deleteNum == A)
                    {
                        count++;
                        break;
                    }

                    //線分を削除できるか判定


                }
            }

            IOLibrary.WriteLine(count);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveE()
        {
            var N = IOLibrary.ReadInt();
            var fArray = IOLibrary.ReadLong2DArray(N, 2);
            var Q = IOLibrary.ReadInt();
            var xArray = IOLibrary.ReadLongArray();

            List<Func<long, long, long>> f = new List<Func<long, long, long>>()
            {
                (x, a) => x + a,
                (x, a) => Math.Max(x, a),
                (x, a) => Math.Min(x, a),
            };

            for (var i = 0; i < Q; i++)
            {
                var x = xArray[i];

                var ans = x;
                for (var j = 0; j < N; j++)
                {
                    var a = fArray[j, 0];
                    var t = (int)fArray[j, 1];

                    ans = f[t - 1](ans, a);
                }

                IOLibrary.WriteLine(ans);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveF()
        {

        }
    }
}