using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderCs.Contest.ABC330;

public class MySolution
{
    public void OldB()
    {
        var NLR = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NLR[0];
        var L = NLR[1];
        var R = NLR[2];

        var A = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var ansList = new List<int>();
        for (int i = 0; i < N; i++)
        {
            // L <= Ai <= Rのとき、∣Y−Ai|の最小値は0
            var YA = 0;
            if (A[i] < L || A[i] > R)
            {
                YA = Math.Min(Math.Abs(L - A[i]), Math.Abs(R - A[i]));
            }

            // |L-Ai|、|R-Ai|と、|Y-Ai|を比較
            var XL = Math.Abs(L - A[i]);
            var XR = Math.Abs(R - A[i]);

            if (XL <= YA)
            {
                ansList.Add(L);
            }
            else if (XR <= YA)
            {
                ansList.Add(R);
            }
            else
            {
                ansList.Add(A[i]);
            }
        }

        var ans = string.Join(" ", ansList);
        Console.WriteLine(ans);
    }

    public long OldC(long D)
    {
        var rootD = (long)Math.Sqrt(D) + 1;

        var ans = long.MaxValue;

        for (var x = 1L; x <= rootD; x++)
        {
            var top = rootD;
            var bottom = 1L;

            while (Math.Abs(top - bottom) > 1)
            {
                var middle = bottom + (top - bottom) / 2;

                var target = x * x + middle * middle - D;
                if (target > 0)
                {
                    //円の外側
                    top = middle;
                }
                else
                {
                    //円の内側
                    bottom = middle;
                }
            }

            {
                // 円の内側の点
                var value = Math.Abs(x * x + bottom * bottom - D);
                ans = long.Min(ans, value);
            }

            {
                //円の外側の点
                var value = Math.Abs(x * x + top * top - D);
                ans = long.Min(ans, value);
            }
        }

        return ans;
    }

}
