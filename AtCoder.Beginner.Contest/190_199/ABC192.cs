using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC192
{
    public class Problem : ProblemBase
    {
        /// <summary>
        /// 
        /// </summary>
        public override void SolveA()
        {
            var x = IOLibrary.ReadInt();
            var ans = 100 - x % 100;
            Console.WriteLine(ans);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveB()
        {
            var S = IOLibrary.ReadLine();
            for (var i = 0; i < S.Length; i++)
            {
                var str = S[i];
                if ((i + 1 & 1) == 1)
                {
                    if (Char.IsUpper(str))
                    {
                        IOLibrary.WriteYesOrNo(false);
                        return;
                    }
                }
                else
                {
                    if (!Char.IsUpper(str))
                    {
                        IOLibrary.WriteYesOrNo(false);
                        return;
                    }
                }
            }

            IOLibrary.WriteYesOrNo(true);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveC()
        {
            var (N, K) = IOLibrary.ReadLong2();

            Func<long, long> f = (x) =>
            {
                var array = x.ToString()
                             .Select(str => int.Parse(str.ToString()))
                             .ToArray();
                var sortedArray = array.Sort();

                var num1 = long.Parse(string.Join("", sortedArray.Reverse()));
                var num2 = long.Parse(string.Join("", sortedArray));
                var num = num1 - num2;
                return num;
            };

            var ans = N;
            for (var i = 0; i < K; i++)
            {
                ans = f(ans);
            }

            IOLibrary.WriteLine(ans);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveD()
        {
            var X = IOLibrary.ReadLine();
            var M = IOLibrary.ReadLong();

            if (X.Length == 1)
            {
                var x = int.Parse(X);
                var ans = (x <= M) ? 1 : 0;
                IOLibrary.WriteLine(ans);
                return;
            }

            var d = X.Select(str => long.Parse(str.ToString()))
                     .Max();

            Func<long, bool> isOk = (n) =>
            {
                //Mをn進表記に変換
                var Y = new List<long>();
                var m = M;

                while (m > 0)
                {
                    Y.Add(m % n);
                    m /= n;
                }

                Y.Reverse();

                if (Y.Count != X.Length)
                {
                    return (Y.Count > X.Length);
                }

                if (Y.Count == X.Length)
                {
                    for (var i = 0; i < X.Length; i++)
                    {
                        var x = long.Parse(X[i].ToString());
                        var y = Y[i];
                        if (x != y)
                        {
                            return (x < y);
                        }
                    }
                }

                return true;
            };

            var ok = d;
            var ng = long.MaxValue;
            var maxNum = MathLibrary.BinarySearch(ok, ng, isOk);

            var count = maxNum - d;
            IOLibrary.WriteLine(count);
        }

        #region 

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public override void SolveE()
        {
            var (N, M, X, Y) = IOLibrary.ReadInt4();

        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveF()
        {

        }
    }
}