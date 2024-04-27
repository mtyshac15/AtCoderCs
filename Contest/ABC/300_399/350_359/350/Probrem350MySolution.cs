using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC350;

public class MySolution
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public void OldA()
    {
        var S = _reader.ReadLine().Trim();
        var numStr = string.Join(string.Empty, S[S.Length - 3], S[S.Length - 2], S[S.Length - 1]);
        var number = int.Parse(numStr);

        var ans = false;
        if (number == 316)
        {
            ans = false;
        }
        else
        {
            ans = 1 <= number && number < 350;
        }

        _writer.WriteLine(IOLibrary.ToYesOrNo(ans));
    }

    public void OldB()
    {
        var NQ = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NQ[0];
        var Q = NQ[1];

        var T = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var teeth = Enumerable.Repeat(1, N).ToArray();

        for (int i = 0; i < Q; i++)
        {
            var hole = T[i];
            if (teeth[hole - 1] == 1)
            {
                teeth[hole - 1] = 0;
            }
            else if (teeth[hole - 1] == 0)
            {
                teeth[hole - 1] = 1;
            }
        }

        var ans = teeth.Sum();
        _writer.WriteLine(ans);
    }

    public static class IOLibrary
    {
        public static string ToYesOrNo(bool value)
        {
            return value ? $"Yes" : $"No";
        }
    }
}
