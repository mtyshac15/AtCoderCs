using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC323;

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

        var S = new string[N];
        for (int i = 0; i < N; i++)
        {
            S[i] = _reader.Str();
        }

        var array = new int[N];
        for (int i = 0; i < N; i++)
        {
            for (int j = i + 1; j < N; j++)
            {
                if (S[i][j] == 'o')
                {
                    array[i]++;
                }
                else
                {
                    array[j]++;
                }
            }
        }

        var list = new List<int>();

        for (int win = N; win >= 0; win--)
        {
            for (int i = 0; i < N; i++)
            {
                if (array[i] == win)
                {
                    list.Add(i + 1);
                }
            }
        }

        var ans = string.Join(" ", list);
        _writer.WriteLine(ans);
    }
}
