using AtCoderCs.Common.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC329;

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
        var N = _reader.NextInt();
        var A = _reader.NextIntArray();

        var array = A.Distinct().ToArray();
        Array.Sort(array);

        var ans = array[array.Length - 2];
        _writer.WriteLine(ans);
    }
}
