using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC156;

public class MySolution
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public void OldC()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var X = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        //Xの平均に近い整数
        var P = (int)(X.Average() + 0.5);

        var sumSquare = 0L;
        for (var i = 0; i < N; i++)
        {
            sumSquare += (X[i] - P) * (X[i] - P);
        }

        _writer.WriteLine(sumSquare);
    }
}
