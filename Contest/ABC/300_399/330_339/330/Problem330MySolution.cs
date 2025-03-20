using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC330;

public class MySolution
{
    private Reader _reader;
    private Writer _writer;

    public MySolution()
    {
        _reader = new Reader(Console.In);
        _writer = new Writer(Console.Out);
    }

    public void OldB()
    {
        var N = _reader.Int();
        var L = _reader.Int();
        var R = _reader.Int();

        var A = _reader.IntArray();

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
