using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC292;

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
        var Q = _reader.Int();

        var c = new List<int>();
        var x = new List<int>();
        for (int i = 0; i < Q; i++)
        {
            c.Add(_reader.Int());
            x.Add(_reader.Int());
        }

        var players = Enumerable.Range(0, N + 1)
            .ToDictionary(x => x, x => 0);

        var ansBuilder = new StringBuilder();

        for (int i = 0; i < Q; i++)
        {
            switch (c[i])
            {
                case 1:
                    players[x[i]] += 1;
                    break;

                case 2:
                    players[x[i]] += 2;
                    break;

                case 3:
                    ansBuilder.AppendLine(Writer.ToYesOrNo(players[x[i]] >= 2));
                    break;
            }
        }

        var ans = ansBuilder.ToString();
        _writer.WriteLine(ans);
    }
}
