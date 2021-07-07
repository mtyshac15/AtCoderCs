using AtCoder.Common;
using System;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem001
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var (N, L) = IOLibrary.ReadLong2();
            var K = IOLibrary.ReadLong();
            var A = IOLibrary.ReadLongArray();

            //階差
            var collection = A.Prepend(0).Append(L).FloorDiff();

            var ok = 0L;
            var ng = L;

            Func<long, bool> isOk = (x) =>
            {
                //分割数
                var count = 0L;
                var length = 0L;
                foreach (var item in collection)
                {
                    length += item;
                    if (length >= x)
                    {
                        //長さがxに達した場合はそこで切る
                        count++;
                        length = 0;
                    }
                }

                return count >= K + 1;
            };

            var ans = MathLibrary.BinarySearch(ok, ng, isOk);
            IOLibrary.WriteLine(ans);
        }
    }
}
