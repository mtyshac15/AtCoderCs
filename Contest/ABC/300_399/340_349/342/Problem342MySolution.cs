using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC342;

public class MySolution
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public void OldC()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var S = _reader.ReadLine().Trim();
        var Q = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var c = new char[Q];
        var d = new char[Q];

        for (int i = 0; i < Q; i++)
        {
            var cd = _reader.ReadLine().Trim().Split().Select(char.Parse).ToArray();
            c[i] = cd[0];
            d[i] = cd[1];
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
