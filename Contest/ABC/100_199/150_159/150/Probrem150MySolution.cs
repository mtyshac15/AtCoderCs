using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC150;

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
        var N = _reader.NextInt();
        var P = _reader.NextIntArray();
        var Q = _reader.NextIntArray();

        var factorial = new int[N + 1];
        factorial[0] = 1;
        for (int i = 1; i < N + 1; i++)
        {
            factorial[i] = i * factorial[i - 1];
        }

        var a = 1;
        var list = Enumerable.Range(1, N).ToList();
        for (int i = 0; i < N; i++)
        {
            var index = list.IndexOf(P[i]);
            var num = factorial[N - i - 1];

            a += index * num;
            list.Remove(P[i]);
        }

        var b = 1;
        list = Enumerable.Range(1, N).ToList();
        for (int i = 0; i < N; i++)
        {
            var index = list.IndexOf(Q[i]);
            var num = factorial[N - i - 1];

            b += index * num;
            list.Remove(Q[i]);
        }

        var ans = Math.Abs(a - b);
        _writer.WriteLine(ans);
    }

    #region "IO"
    public class Reader
    {
        private TextReader _reader;
        private int _index;
        private string[] _line;

        char[] _cs = new char[] { ' ' };

        public Reader()
            : this(Console.In)
        {
        }

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

        public Writer()
           : this(Console.Out)
        {
        }

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
