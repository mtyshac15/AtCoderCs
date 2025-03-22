using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC376;

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
        var Q = _reader.Int();

        var H = new List<string>();
        var T = new List<int>();
        for (int i = 0; i < Q; i++)
        {
            H.Add(_reader.Str());
            T.Add(_reader.Int());
        }

        var total = 0;
        var currentL = 1;
        var currentR = 2;

        for (int i = 0; i < Q; i++)
        {
            var hand = H[i];
            var after = T[i];

            if (hand == "L")
            {
                var clockwise = 0;
                var reverse = 0;

                // 時計回り
                {
                    var current = currentL;
                    while (current != after)
                    {
                        if (current == currentR)
                        {
                            clockwise = int.MaxValue;
                            break;
                        }

                        current++;
                        if (current == N + 1)
                        {
                            current = 1;
                        }

                        clockwise++;
                    }
                }

                // 反時計回り
                {
                    var current = currentL;
                    while (current != after)
                    {
                        if (current == currentR)
                        {
                            reverse = int.MaxValue;
                            break;
                        }

                        current--;
                        if (current == 0)
                        {
                            current = N;
                        }

                        reverse++;
                    }
                }

                total += Math.Min(clockwise, reverse);
                currentL = after;
            }
            else
            {
                var clockwise = 0;
                var reverse = 0;

                // 時計回り
                {
                    var current = currentR;
                    while (current != after)
                    {

                        if (current == currentL)
                        {
                            clockwise = int.MaxValue;
                            break;
                        }

                        current++;
                        if (current == N + 1)
                        {
                            current = 1;
                        }

                        clockwise++;
                    }
                }

                // 反時計回り
                {
                    var current = currentR;
                    while (current != after)
                    {
                        if (current == currentL)
                        {
                            reverse = int.MaxValue;
                            break;
                        }

                        current--;
                        if (current == 0)
                        {
                            current = N;
                        }

                        reverse++;
                    }
                }

                total += Math.Min(clockwise, reverse);
                currentR = after;
            }
        }
        var ans = total;
        _writer.WriteLine(ans);
    }

    public void OldC()
    {
        var N = _reader.Int();
        var A = _reader.IntArray();
        var B = _reader.IntArray();

        Array.Sort(A);
        Array.Sort(B);

        var isOk = (int key) =>
        {
            var addB = B.Append(key).ToArray();
            Array.Sort(addB);

            for (int i = 0; i < N; i++)
            {
                if (A[i] > addB[i])
                {
                    return false;
                }
            }

            return true;
        };

        // 二分探索
        var ok = int.MaxValue;
        var ng = 0;

        while (Math.Abs(ok - ng) > 0)
        {
            var middle = ng + (ok - ng) / 2;
            if (isOk(middle))
            {
                ok = middle;
            }
            else
            {
                ng = middle;
            }
        }

        var ans = -1;
        if (ok < int.MaxValue)
        {
            ans = ok;
        }

        _writer.WriteLine(ans);
    }
}
