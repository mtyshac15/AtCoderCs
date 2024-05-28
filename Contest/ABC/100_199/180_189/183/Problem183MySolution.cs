using AtCoderCs.Common.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC183;

public class MySolution
{
    private Reader _reader;
    private Writer _writer;

    public MySolution()
    {
        _reader = new Reader(Console.In);
        _writer = new Writer(Console.Out);
    }

    public void OldD()
    {
        var N = _reader.NextInt();
        var W = _reader.NextInt();

        var S = new List<int>();
        var T = new List<int>();
        var P = new List<int>();
        for (int i = 0; i < N; i++)
        {
            S.Add(_reader.NextInt());
            T.Add(_reader.NextInt());
            P.Add(_reader.NextInt());
        }

        //増減を記録
        var heater = new SortedDictionary<int, long>();
        for (int i = 0; i < N; i++)
        {
            if (heater.ContainsKey(S[i]))
            {
                heater[S[i]] += P[i];
            }
            else
            {
                heater.Add(S[i], P[i]);
            }

            if (heater.ContainsKey(T[i]))
            {
                heater[T[i]] -= P[i];
            }
            else
            {
                heater.Add(T[i], P[i] * (-1));
            }
        }

        //集計
        var water = new List<long>() { heater.Values.FirstOrDefault() };
        foreach (var keyValue in heater.Skip(1))
        {
            water.Add(water[water.Count - 1] + keyValue.Value);
        }

        var ans = water.All(x => x <= W);
        _writer.WriteYesOrNo(ans);
    }

    public void OldD2()
    {
        var N = _reader.NextInt();
        var W = _reader.NextInt();

        var S = new List<int>();
        var T = new List<int>();
        var P = new List<int>();
        for (int i = 0; i < N; i++)
        {
            S.Add(_reader.NextInt());
            T.Add(_reader.NextInt());
            P.Add(_reader.NextInt());
        }

        var table = new long[T.Max() + 1];
        for (var i = 0; i < N; i++)
        {
            table[S[i]] += P[i];
            table[T[i]] -= P[i];
        }

        //集計
        for (var i = 0; i < table.Length; i++)
        {
            table[i + 1] += table[i];
            if (table[i] > W)
            {
                _writer.WriteYesOrNo(false);
                return;
            }
        }

        _writer.WriteYesOrNo(true);
    }
}
