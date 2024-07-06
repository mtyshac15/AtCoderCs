using AtCoderCs.Common.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC361;

public class MySolution
{
    private Reader _reader;
    private Writer _writer;

    public MySolution()
    {
        _reader = new Reader(Console.In);
        _writer = new Writer(Console.Out);
    }

    public void OldC()
    {
        var N = _reader.NextInt();
        var K = _reader.NextInt();
        var A = _reader.NextIntArray();

        Array.Sort(A);
        var floor = new List<int>();

        for (int i = 1; i < N; i++)
        {
            floor.Add(A[i] - A[i - 1]);
        }

        var floorSum = new List<int>() { 0 };
        for (int i = 0; i < floor.Count; i++)
        {
            floorSum.Add(floorSum[floorSum.Count - 1] + floor[i]);
        }

        var min = int.MaxValue;
        for (int left = 0; left <= K; left++)
        {
            var leftSum = floorSum[left] - floorSum[0];

            var right = floorSum.Count - 1 - (K - left);
            var rightSum = floorSum[floorSum.Count - 1] - floorSum[right];

            var sum = floorSum[floorSum.Count - 1] - rightSum - leftSum;
            min = Math.Min(sum, min);
        }

        var ans = min;
        _writer.WriteLine(ans);
    }
}
