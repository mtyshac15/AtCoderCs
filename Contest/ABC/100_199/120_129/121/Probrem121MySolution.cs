using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC121;

public class MySolution
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public void OldC()
    {
        var NM = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NM[0];
        var M = NM[1];

        var A = new int[N];
        var B = new int[N];

        for (int i = 0; i < N; i++)
        {
            var AB = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            A[i] = AB[0];
            B[i] = AB[1];
        }

        var array = A.Zip(B, (a, b) => (a, b)).ToArray();
        Array.Sort(array, (x, y) => x.a - y.a);

        //最小額のものから買えるだけ買う
        var count = 0;
        var ans = 0L;

        for (var i = 0; i < N; i++)
        {
            var a = array[i].a;
            var b = array[i].b;

            var num = Math.Min(b, M - count);
            ans += (long)a * num;
            count += num;

            if (count == M)
            {
                break;
            }
        }

        _writer.WriteLine(ans);
    }

    public void QuickSort()
    {
        //クイックソート
        Action<(int Index, long Key)[], int, int> quickSort = null;
        quickSort = (array, left, right) =>
        {
            if (right - left <= 1)
            {
                return;
            }

            var midleIndex = left + (right - left) / 2;

            var tmpArray = new[] { array[left].Key, array[midleIndex].Key, array[right].Key };

            //中央値を求める
            Array.Sort(tmpArray);
            var pivot = tmpArray[1];
            //pivot = array[midleIndex].key;

            //pivotと右端を入れ替え
            (array[midleIndex], array[right - 1]) = (array[right - 1], array[midleIndex]);

            //ソート
            //基準より大きい値の位置を左から探索
            var l = left;
            for (int i = left; i < right - 1; i++)
            {
                if (array[i].Key < pivot)
                {
                    (array[l], array[i]) = (array[i], array[l]);
                    l++;
                }
            }

            if (Math.Abs(l - left) == 0)
            {
                l = midleIndex;
            }

            //pivotを戻す
            (array[l], array[right - 1]) = (array[right - 1], array[l]);

            //左側をソート
            quickSort(array, left, l);

            //右側をソート
            quickSort(array, l + 1, right);
        };
    }
}
