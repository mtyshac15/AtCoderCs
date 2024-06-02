using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC356;

public class ProblemC
{
    private Reader _reader;
    private Writer _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemC();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemC()
      : this(Console.In, Console.Out)
    {
    }

    public ProblemC(TextReader textReader, TextWriter textWriter)
    {
        _reader = new Reader(textReader);
        _writer = new Writer(textWriter);
    }

    public void Solve()
    {
        var N = _reader.NextInt();
        var M = _reader.NextInt();
        var K = _reader.NextInt();

        var A = new List<ISet<int>>();
        var R = new List<char>();

        for (int i = 0; i < M; i++)
        {
            var C = _reader.NextInt();

            var set = new HashSet<int>();
            for (int j = 0; j < C; j++)
            {
                set.Add(_reader.NextInt());
            }
            A.Add(set);

            R.Add(_reader.Next()[0]);
        }

        var count = 0;
        for (int bit = 0; bit < (1 << N); bit++)
        {
            var trueKey = new List<bool>();
            for (int i = 0; i < N; i++)
            {
                //本物の鍵
                var isTrueKey = ((bit >> i) & 1) == 1;
                trueKey.Add(isTrueKey);
            }

            //テスト
            var result = true;
            for (int i = 0; i < M; i++)
            {
                //選んだ鍵の組合せのうち、何本含まれているか
                var matchCount = 0;
                for (int p = 0; p < N; p++)
                {
                    if (trueKey[p]
                        && A[i].Contains(p + 1))
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

    #region "IO"
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
}
