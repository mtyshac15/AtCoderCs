using System;
using System.Collections.Generic;
using System.IO;
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

    public void OldD()
    {
        var NK = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NK[0];
        var K = NK[1];

        var P = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var sortedP = P.Select((p, i) => (p, i)).OrderBy(x => x.p).ToArray();

        var ascSet = new SortedSet<int>();
        var descSet = new SortedSet<int>();

        var ans = int.MaxValue;
        var prevIndex = 0;

        for (int i = 0; i < N; i++)
        {
            var current = sortedP[i];
            ascSet.Add(current.i);
            descSet.Add(current.i * (-1));

            if (ascSet.Count == K + 1)
            {
                var prev = sortedP[prevIndex];
                ascSet.Remove(prev.i);
                descSet.Remove(prev.i * (-1));
                prevIndex++;
            }

            if (ascSet.Count == K)
            {
                var min = ascSet.FirstOrDefault();
                var max = descSet.FirstOrDefault() * (-1);
                ans = Math.Min(max - min, ans);
            }
        }

        _writer.WriteLine(ans);
    }
}
