using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC292;

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
        var N = _reader.NextInt();
        var Q = _reader.NextInt();

        var c = new List<int>();
        var x = new List<int>();
        for (int i = 0; i < Q; i++)
        {
            c.Add(_reader.NextInt());
            x.Add(_reader.NextInt());
        }

        var players = new Dictionary<int, int>();

        var ansBuilder = new StringBuilder();

        for (int i = 0; i < Q; i++)
        {
            if (!players.ContainsKey(x[i]))
            {
                players.Add(x[i], 0);
            }

            if (c[i] == 3)
            {
                ansBuilder.AppendLine(Writer.ToYesOrNo(players[x[i]] >= 2));
            }
            else
            {
                players[x[i]] += c[i];
            }
        }

        var ans = ansBuilder.ToString();
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
