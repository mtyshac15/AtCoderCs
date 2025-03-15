using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC345;

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
        var S = _reader.Next();

        var dic = S.GroupBy(x => x)
            .ToDictionary(x => x.Key, x => x.Count());

        var ans = 0L;
        for (int i = 0; i < S.Length; i++)
        {
            var str = S[i];
            dic[str]--;
            if (dic[str] == 0)
            {
                dic.Remove(str);
            }

            var length = S.Length - i - 1;

            if (dic.ContainsKey(str))
            {
                //strと同じ文字と入れ替えた場合の数を除く
                if (i == 0)
                {
                    ans += length - dic[str] + 1;
                }
                else
                {
                    ans += length - dic[str];
                }
            }
            else
            {
                ans += length;
            }
        }

        _writer.WriteLine(ans);
    }
}
