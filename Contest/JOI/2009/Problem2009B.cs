using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.JOI2009;

public class ProblemB
{
    private Reader _reader;
    private Writer _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemB();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemB()
        : this(Console.In, Console.Out)
    {
    }

    public ProblemB(TextReader textReader, TextWriter textWriter)
    {
        _reader = new Reader(textReader);
        _writer = new Writer(textWriter);
    }

    public void Solve()
    {
        var length = _reader.NextInt();
        var n = _reader.NextInt();
        var m = _reader.NextInt();

        var d = new List<int>();
        for (int i = 0; i < n - 1; i++)
        {
            d.Add(_reader.NextInt());
        }

        var k = new List<int>();
        for (int i = 0; i < m; i++)
        {
            k.Add(_reader.NextInt());
        }

        var sortedD = new SortedList<int, int>();
        sortedD.Add(0, 1);

        for (int i = 0; i < d.Count; i++)
        {
            sortedD.Add(d[i], i + 1);
        }

        //S1の位置を追加
        sortedD.Add(length, 1);

        var total = 0;
        for (int i = 0; i < m; i++)
        {
            var target = k[i];

            var left = -1;
            var right = sortedD.Count;

            while (Math.Abs(right - left) > 1)
            {
                var middle = left + (right - left) / 2;

                if (sortedD.Keys[middle] <= target)
                {
                    left = middle;
                }
                else
                {
                    right = middle;
                }
            }

            var leftLength = Math.Abs(target - sortedD.Keys[left]);
            var rightLength = Math.Abs(target - sortedD.Keys[left + 1]);

            total += Math.Min(leftLength, rightLength);
        }

        var ans = total;
        _writer.WriteLine(ans);
    }

    #region
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
