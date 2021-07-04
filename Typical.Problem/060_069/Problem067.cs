using AtCoder.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem067
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var str = IOLibrary.ReadStringArray();
            var N = str[0].ToCharArray();
            var K = int.Parse(str[1]);

            var eighth = N.Select(x => long.Parse(x.ToString())).Reverse().ToArray();
            for (int i = 0; i < K; i++)
            {
                var dec = 0L;

                //10進数に変換
                for (int j = 0; j < eighth.Length; j++)
                {
                    dec += eighth[j] * MathLibrary.Pow(8, j);
                }

                //9進数に変換
                var ninth = MathLibrary.ConvertBasis(dec, 9);
                for (int j = 0; j < ninth.Count; j++)
                {
                    if (ninth[j] == 8)
                    {
                        ninth[j] = 5;
                    }
                }

                eighth = ninth.ToArray();
            }

            var ans = string.Join("", eighth.Reverse());
            IOLibrary.WriteLine(ans);
        }
    }
}
