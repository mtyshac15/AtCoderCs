using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC396.ProblemD;

public class ProblemD
{
    private Reader _reader;
    private Writer _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemD();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemD()
        : this(Console.In, Console.Out)
    {
    }

    public ProblemD(TextReader textReader, TextWriter textWriter)
    {
        _reader = new Reader(textReader);
        _writer = new Writer(textWriter);
    }

    public void Solve()
    {
        var N = _reader.Int();
        var M = _reader.Int();

        var graph = new Dictionary<int, long>[N + 1];
        for (int i = 0; i < N + 1; i++)
        {
            graph[i] = new Dictionary<int, long>();
        }

        for (int i = 0; i < M; i++)
        {
            var u = _reader.Int();
            var v = _reader.Int();
            var w = _reader.Long();

            graph[u][v] = w;
            graph[v][u] = w;
        }

        var min = long.MaxValue;
        var nodes = Enumerable.Range(2, N - 2).ToArray();

        for (int count = 0; count <= nodes.Length; count++)
        {
            foreach (var relay in MathLibrary.GetCombinationIndexCollection(nodes, count))
            {
                do
                {
                    var route = relay.Prepend(1).Append(N).ToArray();
                    // 到達可能か
                    var isConnected = true;

                    var sum = 0L;
                    for (int i = 0; i < route.Length - 1; i++)
                    {
                        var node = route[i];
                        var next = route[i + 1];

                        if (graph[node].ContainsKey(next))
                        {
                            sum ^= graph[node][next];
                        }
                        else
                        {
                            // 到達不可
                            isConnected = false;
                            break;
                        }
                    }

                    if (isConnected)
                    {
                        min = Math.Min(sum, min);
                    }
                }
                while (MathLibrary.NextPermutation(relay));
            }
        }

        var ans = min;
        _writer.WriteLine(ans);
    }
}

#region
static class MathLibrary
{
    public static IEnumerable<int[]> GetCombinationIndexCollection(IEnumerable<int> collection, int k, bool withRepetition = false)
    {
        if (k == 0)
        {
            yield return new int[] { };
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

    public static bool NextPermutation<T>(T[] array)
        where T : IComparable<T>
    {
        var isOk = false;

        //array[i]<array[i+1]を満たす最大のiを求める
        var i = array.Length - 2;
        for (; i >= 0; i--)
        {
            if (array[i].CompareTo(array[i + 1]) < 0)
            {
                isOk = true;
                break;
            }
        }

        //全ての要素が降順の場合終了
        if (!isOk)
        {
            return false;
        }

        //array[i]<array[j]を満たす最大のjを求める
        int j = array.Length - 1;
        for (; ; j--)
        {
            if (array[i].CompareTo(array[j]) < 0)
            {
                break;
            }
        }

        //iの要素とjの要素を交換
        var tmp = array[i];
        array[i] = array[j];
        array[j] = tmp;

        //i以降の要素を反転させる
        Array.Reverse(array, i + 1, array.Length - (i + 1));

        return true;
    }

}

class Reader
{
    private TextReader _reader;
    private int _index;
    private string[] _line;

    private char[] _cs = new char[] { ' ' };

    public Reader(TextReader reader)
    {
        _reader = reader;
        _index = 0;
        _line = new string[0];
    }

    private string NextLine()
    {
        return _reader.ReadLine().Trim();
    }

    public string Str()
    {
        if (_index < _line.Length)
        {
            return _line[_index++];
        }

        _line = this.StrArray();
        if (!_line.Any())
        {
            return this.Str();
        }

        _index = 0;
        return _line[_index++];
    }

    public int Int()
    {
        return int.Parse(this.Str());
    }

    public long Long()
    {
        return long.Parse(this.Str());
    }

    public string[] StrArray()
    {
        return this.NextLine().Split(_cs, StringSplitOptions.RemoveEmptyEntries);
    }

    public int[] IntArray()
    {
        return this.StrArray().Select(int.Parse).ToArray();
    }

    public long[] LongArray()
    {
        return this.StrArray().Select(long.Parse).ToArray();
    }
}

class Writer
{
    private TextWriter _writer;

    public Writer(TextWriter writer)
    {
        _writer = writer;
    }

    public void WriteLine(object value = null)
    {
        _writer.WriteLine(value);
    }

    public void WriteYesOrNo(bool value)
    {
        this.WriteLine(Writer.ToYesOrNo(value));
    }

    public static string ToYesOrNo(bool value)
    {
        return value ? $"Yes" : $"No";
    }
}
#endregion
