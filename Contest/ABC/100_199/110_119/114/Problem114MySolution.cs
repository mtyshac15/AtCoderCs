using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC114;

public class MySolution
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public void OldC()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var digits = N.ToString().Length;

        var numArray = new int[] { 3, 5, 7 };
        var bitArray = new int[] { 0, 1, 2 };

        var ans = 0;
        Action<long, int> func = null;
        func = (currentNum, bit) =>
        {
            if (currentNum > N)
            {
                return;
            }

            if (bitArray.All(x => (bit & (1 << x)) > 0))
            {
                ans++;
            }

            for (int i = 0; i < numArray.Length; i++)
            {
                var num = numArray[i];
                var nextNum = currentNum * 10 + num;
                var nextBit = bit | (1 << i);
                func(nextNum, nextBit);
            }
        };

        func(0, 0);

        _writer.WriteLine(ans);
    }
}
