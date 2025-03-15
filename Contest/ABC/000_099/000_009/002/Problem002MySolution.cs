using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC002;

public class MySolution
{
    private Reader _reader;
    private Writer _writer;

    public MySolution()
    {
        _reader = new Reader(Console.In);
        _writer = new Writer(Console.Out);
    }

    public void OldD()
    {
        var N = _reader.NextInt();
        var M = _reader.NextInt();

        var graph = new List<int>[N + 1];
        for (int i = 0; i < graph.Length; i++)
        {
            graph[i] = new List<int>();
        }

        for (int i = 0; i < M; i++)
        {
            var x = _reader.NextInt();
            var y = _reader.NextInt();

            graph[x].Add(y);
            graph[y].Add(x);
        }

        var maxCount = 0;

        var indexCellection = Enumerable.Range(1, N).ToArray();
        for (int count = 1; count <= N; count++)
        {
            //N個の点からcountだけ選ぶ組み合わせを列挙
            foreach (var indexes in MathLibrary.GetCombinationIndexCollection(indexCellection, count, false))
            {
                //完全グラフかどうか
                var isComplete = true;
                foreach (var node in indexes)
                {
                    var others = indexes.Except(new int[] { node });
                    if (!others.All(x => graph[node].Contains(x)))
                    {
                        //辺が存在しない2点が存在した場合
                        isComplete = false;
                        break;
                    }
                }

                if (isComplete)
                {
                    maxCount = Math.Max(count, maxCount);
                }
            }
        }

        var ans = maxCount;
        _writer.WriteLine(ans);
    }

    static class MathLibrary
    {
        public static IEnumerable<int[]> GetCombinationIndexCollection(IEnumerable<int> collection, int k, bool withRepetition)
        {
            if (k == 0)
            {
                yield return Array.Empty<int>();
            }

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
