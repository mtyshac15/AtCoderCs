using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC333;

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

        var sortedList = new SortedList<long, long>();
        foreach (var indexes in MathLibrary.GetCombinationIndexCollection(Enumerable.Range(0, 12), 3, true))
        {
            var sum = 0L;
            for (int i = 0; i < 3; i++)
            {
                //レピュニットを作成
                var repunitStr = string.Join("", Enumerable.Repeat("1", indexes[i] + 1).ToArray());
                var repunit = long.Parse(repunitStr);
                sum += repunit;
            }

            sortedList.TryAdd(sum, sum);
        }

        var ans = sortedList.Values[N - 1];
        _writer.WriteLine(ans);
    }

    static class MathLibrary
    {
        public static IEnumerable<int[]> GetCombinationIndexCollection(IEnumerable<int> collection, int k, bool withRepetition)
        {
            if (k == 1)
            {
                foreach (var item in collection)
                {
                    yield return new int[] { item };
                }
                yield break;
            }

            foreach (var item in collection)
            {
                var searchedArray = new int[] { item };
                var unsearchedArray = withRepetition ? collection : collection.SkipWhile(x => !x.Equals(item)).Skip(1).ToArray();
                foreach (var searchedItem in MathLibrary.GetCombinationIndexCollection(unsearchedArray, k - 1, withRepetition))
                {
                    yield return searchedArray.Concat(searchedItem).ToArray();
                }
            }
        }
    }
}
