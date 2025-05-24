using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC385;

public class MySolution
{
    private Reader _reader;
    private Writer _writer;

    public MySolution()
    {
        _reader = new Reader(Console.In);
        _writer = new Writer(Console.Out);
    }

    public void OldC()
    {
        var N = _reader.Int();
        var H = _reader.IntArray();

        var maxCount = 1;

        for (int interval = 1; interval < N; interval++)
        {
            for (int startIndex = 0; startIndex < interval; startIndex++)
            {
                var count = 1;

                var index = startIndex;
                var nextIndex = index + interval;

                var prevH = H[index];

                // intervalの間隔で 同じ差分が連続しているかを調べる
                while (nextIndex < N)
                {
                    var nextH = H[nextIndex];
                    if (nextH == prevH)
                    {
                        count++;
                    }
                    else
                    {
                        maxCount = Math.Max(count, maxCount);
                        count = 1;
                    }

                    prevH = nextH;
                    index = nextIndex;
                    nextIndex += interval;
                }

                maxCount = Math.Max(count, maxCount);
            }
        }

        var ans = maxCount;
        _writer.WriteLine(ans);
    }
}
