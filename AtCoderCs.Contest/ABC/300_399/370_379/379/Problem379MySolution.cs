using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC379;

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

        var a = N / 100;
        var b = (N / 10) % 10;
        var c = N % 10;

        var ans = $"{b}{c}{a} {c}{a}{b}";
        _writer.WriteLine(ans);
    }
}
