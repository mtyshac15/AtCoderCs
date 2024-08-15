using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC206
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {
            var N = IOLibrary.ReadInt();

            var total = (int)(N * 1.08m);

            var a = 206;
            if (total < a)
            {
                IOLibrary.WriteLine("Yay!");
            }
            else if (total == a)
            {
                IOLibrary.WriteLine("so-so");
            }
            else
            {
                IOLibrary.WriteLine(":(");
            }
        }

        public override void SolveB()
        {
            var N = IOLibrary.ReadLong();
            var total = 0L;
            var ans = 0L;
            for (int i = 1; ; i++)
            {
                total += i;
                ans++;

                if (total >= N)
                {
                    break;
                }
            }

            IOLibrary.WriteLine(ans);
        }

        public override void SolveC()
        {
            var N = IOLibrary.ReadLong();
            var A = IOLibrary.ReadLongArray();

            var dic = A.GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());

            long ans = N * (N - 1) / 2;
            foreach (var item in dic.Values)
            {
                var duplicate = item * (item - 1) / 2;
                ans -= duplicate;
            }

            IOLibrary.WriteLine(ans);
        }

        public override void SolveD()
        {
        }

        public override void SolveE()
        {

        }

        public override void SolveF()
        {

        }
    }
}
