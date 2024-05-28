using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC350;

public class MySolution
{
    private Reader _reader = new Reader(Console.In);
    private Writer _writer = new Writer(Console.Out);

    public void OldA()
    {
        var S = _reader.Next();
        var numStr = string.Join(string.Empty, S[S.Length - 3], S[S.Length - 2], S[S.Length - 1]);
        var number = int.Parse(numStr);

        var ans = false;
        if (number == 316)
        {
            ans = false;
        }
        else
        {
            ans = 1 <= number && number < 350;
        }

        _writer.WriteYesOrNo(ans);
    }

    public void OldB()
    {
        var N = _reader.NextInt();
        var Q = _reader.NextInt();

        var T = _reader.NextIntArray();

        var teeth = Enumerable.Repeat(1, N).ToArray();

        for (int i = 0; i < Q; i++)
        {
            var hole = T[i];
            if (teeth[hole - 1] == 1)
            {
                teeth[hole - 1] = 0;
            }
            else if (teeth[hole - 1] == 0)
            {
                teeth[hole - 1] = 1;
            }
        }

        var ans = teeth.Sum();
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
