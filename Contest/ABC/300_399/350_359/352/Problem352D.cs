using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC352;

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

    public ProblemD(TextReader reader, TextWriter writer)
    {
        _reader = new Reader(reader);
        _writer = new Writer(writer);
    }

    /// <summary>
    /// Permutation Subsequence
    /// </summary>
    public void Solve()
    {
        var N = _reader.NextInt();
        var K = _reader.NextInt();

        var P = _reader.NextIntArray();
        var sortedP = P.Select((p, i) => (p, i)).OrderBy(x => x.p).ToArray();

        var set = new SortedSet<int>();

        var ans = int.MaxValue;
        var prevIndex = 0;

        for (int i = 0; i < N; i++)
        {
            var current = sortedP[i];
            set.Add(current.i);

            if (set.Count == K + 1)
            {
                var prev = sortedP[prevIndex];
                set.Remove(prev.i);
                prevIndex++;
            }

            if (set.Count == K)
            {
                ans = Math.Min(set.Max - set.Min, ans);
            }
        }

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
}
