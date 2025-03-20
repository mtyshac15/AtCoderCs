using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC356;

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
        var M = _reader.Int();
        var K = _reader.Int();

        var A = new List<ISet<int>>();
        var R = new List<char>();

        for (int i = 0; i < M; i++)
        {
            var C = _reader.Int();

            var set = new HashSet<int>();
            for (int j = 0; j < C; j++)
            {
                set.Add(_reader.Int());
            }
            A.Add(set);

            R.Add(_reader.Str()[0]);
        }

        var count = 0;
        var indexCollection = Enumerable.Range(1, N).ToArray();

        //N本の鍵からK本以上を選択
        for (int genuine = K; genuine <= N; genuine++)
        {
            foreach (var indexes in MathLibrary.GetCombinationIndexCollection(indexCollection, genuine, false))
            {
                //テストの結果と一致するか
                var result = true;
                for (int i = 0; i < M; i++)
                {
                    //選んだ鍵の組合せのうち、何本含まれているか
                    var matchCount = 0;
                    foreach (var key in indexes)
                    {
                        if (A[i].Contains(key))
                        {
                            matchCount++;
                        }
                    }

                    if (R[i] == 'o')
                    {
                        if (matchCount < K)
                        {
                            result = false;
                            break;
                        }
                    }
                    else if (R[i] == 'x')
                    {
                        if (matchCount >= K)
                        {
                            result = false;
                            break;
                        }
                    }
                }

                if (result)
                {
                    count++;
                }
            }
        }

        var ans = count;
        _writer.WriteLine(ans);
    }

    #region
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
    #endregion
}
