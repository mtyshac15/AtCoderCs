using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC270;

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
        var X = _reader.NextInt();
        var Y = _reader.NextInt();
        var Z = _reader.NextInt();

        if (Math.Sign(X) != Math.Sign(Y))
        {
            // ゴールと壁が逆方向の場合
            _writer.WriteLine(Math.Abs(X));
            return;
        }
        else if (Math.Abs(X) < Math.Abs(Y))
        {
            // ゴールが壁の手前にある場合
            _writer.WriteLine(Math.Abs(X));
            return;
        }
        else if (Math.Sign(Z) != Math.Sign(Y))
        {
            // ゴールが壁の向こう側にあり、
            // かつ 壁と異なる方向にハンマーがある場合
            _writer.WriteLine(Math.Abs(Z) * 2 + Math.Abs(X));
            return;
        }
        else if (Math.Abs(Z) < Math.Abs(Y))
        {
            // 壁と同じ方向にハンマーがあり、かつ壁の手前にある場合
            _writer.WriteLine(Math.Abs(X));
            return;
        }

        _writer.WriteLine(-1);
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
