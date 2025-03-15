using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC342;

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
        var S = _reader.Next();
        var Q = _reader.NextInt();

        var c = new List<char>();
        var d = new List<char>();

        for (int i = 0; i < Q; i++)
        {
            c.Add(_reader.Next()[0]);
            d.Add(_reader.Next()[0]);
        }

        var converter = new Dictionary<char, char>();

#if false
        for (int i = 0; i < 26; i++)
        {
            var key = (char)(i + 'a');
            converter.Add(key, key);
        }
#endif

        for (int i = 0; i < Q; i++)
        {
            if (!converter.ContainsKey(c[i]))
            {
                converter.Add(c[i], d[i]);
            }

            foreach (var keyValue in converter.Where(x => x.Value == c[i]))
            {
                converter[keyValue.Key] = d[i];
            }
        }

        var charArray = new char[N];
        for (int i = 0; i < N; i++)
        {
            charArray[i] = converter[S[i]];
        }

        var ans = string.Join(string.Empty, charArray);
        _writer.WriteLine(ans);
    }
}
