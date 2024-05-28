using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC139;

public class MySolution
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public void OldB()
    {
        var AB = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var A = AB[0];
        var B = AB[1];

        if (B == 1)
        {
            // タップは不要
            _writer.WriteLine(0);
            return;
        }

        //タップがn個のとき、差込口は A*n - (n-1)
        //((B-1) + (A-1) - 1)/(A-1)
        var ans = (B - 2) / (A - 1) + 1;
        _writer.WriteLine(ans);
    }
}
