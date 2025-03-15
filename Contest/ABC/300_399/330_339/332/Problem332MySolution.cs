using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC332;

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
        var N = _reader.NextInt();
        var M = _reader.NextInt();
        var S = _reader.Next();

        var newS = S.ToCharArray().Append('0');

        var shirts = new List<(int Plain, int Logo)>();

        var all = 0;
        var logo = 0;

        foreach (var c in newS)
        {
            switch (c)
            {
                case '0':
                    if (all > 0)
                    {
                        shirts.Add((all, logo));

                        all = 0;
                        logo = 0;
                    }
                    break;

                case '1':
                    all++;
                    break;

                case '2':
                    all++;
                    logo++;
                    break;
            }
        }

        var ans = 0;
        foreach (var item in shirts)
        {
            //無地の枚数
            var plain = Math.Max(item.Plain - M, 0);

            //必要枚数
            var count = Math.Max(plain, item.Logo);
            ans = Math.Max(count, ans);
        }

        _writer.WriteLine(ans);
    }
}
