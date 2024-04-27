using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC194;

public class MySolution
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public void OldA()
    {
        var AB = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var milkSolids = AB[0] + AB[1];
        var milkFat = AB[1];
        if (milkSolids >= 15 && milkFat >= 8)
        {
            _writer.WriteLine(1);
        }
        else if (milkSolids >= 10 && milkFat >= 3)
        {
            _writer.WriteLine(2);
        }
        else if (milkSolids >= 3)
        {
            _writer.WriteLine(3);
        }
        else
        {
            _writer.WriteLine(4);
        }
    }

    public void OldB()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var AB = new int[N][];
        for (int i = 0; i < N; i++)
        {
            AB[i] = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        }

        var indexA = 0;
        var minA = int.MaxValue;

        for (var i = 0; i < N; i++)
        {
            var a = AB[i][0];
            if (a < minA)
            {
                minA = a;
                indexA = i;
            }
        }

        var minB = int.MaxValue;
        for (var i = 0; i < N; i++)
        {
            if (i != indexA)
            {
                var b = AB[i][1];
                minB = Math.Min(b, minB);
            }
        }

        var min = Math.Max(minA, minB);

        //一人がA,Bを行った場合
        var minSum = AB.Select(item => item[0] + item[1]).Min();
        min = Math.Min(minSum, min);

        _writer.WriteLine(min);
    }
}
