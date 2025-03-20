using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.AB228;

public class MySolution
{
    private Reader _reader;
    private Writer _writer;

    public MySolution()
    {
        _reader = new Reader(Console.In);
        _writer = new Writer(Console.Out);
    }

    public void OldA()
    {
        var S = _reader.Int();
        var T = _reader.Int();
        var X = _reader.Int();

        var on = S;
        var off = T > S ? T : T + 24;

        var ans = X >= on && X < off || X + 24 >= on && X + 24 < off;
        _writer.WriteYesOrNo(ans);
    }
}
