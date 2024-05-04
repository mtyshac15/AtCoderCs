using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC352;

public class MySolution
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public void OldC()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var A = new int[N];
        var B = new int[N];

        for (int i = 0; i < N; i++)
        {
            var AB = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            A[i] = AB[0];
            B[i] = AB[1];
        }

        var array = A.Select((a, i) => (a, i))
                    .Zip(B, (a, b) => new
                    {
                        Index = a.i,
                        A = a.a,
                        B = b,
                        Head = b - a.a
                    }).ToArray();

        var max = array.MaxBy(x => x.Head);

        var ans = (long)max.B;
        for (int i = 0; i < N; i++)
        {
            if (i != max.Index)
            {
                ans += array[i].A;
            }
        }

        _writer.WriteLine(ans);
    }
}
