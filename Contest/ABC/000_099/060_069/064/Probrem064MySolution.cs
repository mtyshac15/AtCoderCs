using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC064;

public class MySolution
{
    private TextReader _reader;
    private TextWriter _writer;

    public void OldB()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var a = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        Array.Sort(a);

        //階差数列
        var diff = a.Skip(1).Zip(a, (a1, a2) => a1 - a2).ToArray();

        var ans = diff.Sum();
        _writer.WriteLine(ans);
    }
}
