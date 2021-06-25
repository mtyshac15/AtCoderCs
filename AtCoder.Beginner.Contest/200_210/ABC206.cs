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

            var dictionary = new Dictionary<long, long>();

            long ans = N * (N - 1) / 2;
            foreach (var item in A)
            {
                if (!dictionary.ContainsKey(item))
                {
                    dictionary.Add(item, 1);
                }
                else
                {
                    dictionary[item]++;
                }
            }

            foreach (var item in dictionary.Values)
            {
                var dupulicate = item * (item - 1) / 2;
                ans -= dupulicate;
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
