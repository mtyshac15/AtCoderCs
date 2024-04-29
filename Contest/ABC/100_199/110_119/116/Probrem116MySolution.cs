using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC116;

public class MySolution
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public void OldB()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var h = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var ans = h.Zip(h.Prepend(0), (e1, e2) => e1 - e2)
                   .Where(e => e > 0)
                   .Sum();

        _writer.WriteLine(ans);
    }
}
