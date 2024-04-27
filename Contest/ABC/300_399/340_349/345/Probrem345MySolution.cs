using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC345;

public class MySolution
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public void OldC()
    {
        var S = _reader.ReadLine().Trim();

        var dic = new Dictionary<char, int>();
        for (int i = 0; i < S.Length; i++)
        {
            if (!dic.ContainsKey(S[i]))
            {
                dic.Add(S[i], 1);
            }
            else
            {
                dic[S[i]]++;
            }
        }

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
