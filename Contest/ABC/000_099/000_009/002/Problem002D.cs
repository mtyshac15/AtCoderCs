using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC002;

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

    #region "IO"
    public class Reader
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

        public string Next()
        {
            if (_index < _line.Length)
            {
                return _line[_index++];
            }

            _line = this.NextArray();
            if (!_line.Any())
            {
                return this.Next();
            }

            _index = 0;
            return _line[_index++];
        }

        public int NextInt()
        {
            return int.Parse(this.Next());
        }

        public long NextLong()
        {
            return long.Parse(this.Next());
        }

        public string[] NextArray()
        {
            return this.NextLine().Split(_cs, StringSplitOptions.RemoveEmptyEntries);
        }

        public int[] NextIntArray()
        {
            return this.NextArray().Select(int.Parse).ToArray();
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
