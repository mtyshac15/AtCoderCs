using AtCoderCs.Common.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC364;

public class MySolution
{
    private Reader _reader;
    private Writer _writer;

    public MySolution()
    {
        _reader = new Reader(Console.In);
        _writer = new Writer(Console.Out);
    }

    public void OldD()
    {
        var N = _reader.NextInt();
        var Q = _reader.NextInt();
        var a = _reader.NextIntArray();

        var b = new List<int>();
        var k = new List<int>();
        for (int i = 0; i < Q; i++)
        {
            b.Add(_reader.NextInt());
            k.Add(_reader.NextInt());
        }

        Array.Sort(a);

        Func<int, int, int> f = (int bj, int x) =>
        {
            //bj-x から bj+xに範囲にあるaiの個数を求める

            var min = 0;
            {
                var ng = -1;
                var ok = a.Length;
                while (Math.Abs(ok - ng) > 1)
                {
                    var middle = ng + (ok - ng) / 2;
                    if (a[middle] >= bj - x)
                    {
                        ok = middle;
                    }
                    else
                    {
                        ng = middle;
                    }
                }

                min = ok;
            }

            var max = 0;
            {
                var ng = a.Length;
                var ok = -1;
                while (Math.Abs(ok - ng) > 1)
                {
                    var middle = ok + (ng - ok) / 2;
                    if (a[middle] <= bj + x)
                    {
                        ok = middle;
                    }
                    else
                    {
                        ng = middle;
                    }
                }

                max = ok;
            }

            return max - min + 1;
        };

        var ansBuilder = new StringBuilder();

        for (int j = 0; j < Q; j++)
        {
            var left = Math.Abs(b[j] - a[0]);
            var right = Math.Abs(b[j] - a[a.Length - 1]);
            var max = Math.Max(left, right);

            var ng = -1;
            var ok = max + 1;

            while (Math.Abs(ok - ng) > 1)
            {
                var middle = ng + (ok - ng) / 2;
                var count = f(b[j], middle);
                if (count >= k[j])
                {
                    ok = middle;
                }
                else
                {
                    ng = middle;
                }
            }

            ansBuilder.AppendLine($"{ok}");
        }

        var ans = ansBuilder.ToString();
        _writer.WriteLine(ans);
    }
}
