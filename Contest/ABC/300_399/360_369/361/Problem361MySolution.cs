using AtCoderCs.Common.Models;
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
        var N = _reader.Int();
        var K = _reader.Int();
        var A = _reader.IntArray();

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

    public void OldC2()
    {
        var N = _reader.Int();
        var K = _reader.Int();
        var A = _reader.IntArray();

        Array.Sort(A);

        //連続したN-K個の数の最大値と最小値を計算
        var min = int.MaxValue;
        for (int i = 0; i < K + 1; i++)
        {
            var sub = A[i + N - K - 1] - A[i];
            min = Math.Min(sub, min);
        }

        var ans = min;
        _writer.WriteLine(ans);
    }
}
