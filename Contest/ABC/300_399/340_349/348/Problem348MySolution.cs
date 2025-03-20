using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC348;

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
        var N = _reader.Int();

        var strBuilder = new StringBuilder();
        for (int i = 0; i < N; i++)
        {
            if ((i + 1) % 3 == 0)
            {
                strBuilder.Append('x');
            }
            else
            {
                strBuilder.Append('o');
            }
        }

        var ans = strBuilder.ToString();
        _writer.WriteLine(ans);
    }
}
