using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem008
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var N = IOLibrary.ReadInt();
            var S = IOLibrary.ReadLine();

            int mod = 1000000007;
            string sourceArray = "atcoder";

            var dp = new long[sourceArray.Length + 1][];
            for (int i = 0; i < sourceArray.Length + 1; i++)
            {
                dp[i] = new long[S.Length + 1];
            }

            dp[0][0] = 1;
            for (int i = 0; i < sourceArray.Length + 1; i++)
            {
                for (int j = 0; j < S.Length; j++)
                {
                    dp[i][j + 1] += dp[i][j];
                    if (i < sourceArray.Length && sourceArray[i] == S[j])
                    {
                        //j文字目を取る場合
                        dp[i + 1][j + 1] += dp[i][j];
                    }
                    dp[i][j + 1] %= mod;
                }
            }

            IOLibrary.WriteLine(dp[sourceArray.Length][S.Length]);
        }
    }
}
