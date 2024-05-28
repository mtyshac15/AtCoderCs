using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC323;

public class MySolution
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public void OldB()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var S = new string[N];
        for (int i = 0; i < N; i++)
        {
            S[i] = _reader.ReadLine().Trim();
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
