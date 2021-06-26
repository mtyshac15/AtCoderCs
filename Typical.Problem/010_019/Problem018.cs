using AtCoder.Common;
using System;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem018
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var T = IOLibrary.ReadLong();
            var (L, X, Y) = IOLibrary.ReadLong3();
            var Q = IOLibrary.ReadInt();
            var E = IOLibrary.ReadIntArray(Q);

            foreach (var e in E)
            {
                //e分後の高さ
                var rad = 2 * Math.PI * e / T;
                var z = L / 2.0 * (1 - Math.Cos(rad));
                var y = (-1) * L / 2.0 * Math.Sin(rad);

                //像との距離
                var distance = Math.Sqrt(X * X + (Y - y) * (Y - y));

                var andRad = Math.Atan2(z, distance);
                var ans = andRad * 180 / Math.PI;
                IOLibrary.WriteLine(ans);
            }
        }
    }
}
