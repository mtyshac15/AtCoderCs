using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC390;

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
        var H = _reader.NextInt();
        var W = _reader.NextInt();

        var S = new List<string>();
        for (int i = 0; i < H; i++)
        {
            S.Add(_reader.Next());
        }

        var left = W + 1;
        var right = -1;
        var top = H + 1;
        var bottom = -1;

        for (int h = 0; h < H; h++)
        {
            for (int w = 0; w < W; w++)
            {
                if (S[h][w] == '#')
                {
                    left = Math.Min(w, left);
                    top = Math.Min(h, top);
                }
            }
        }

        for (int h = H - 1; h >= 0; h--)
        {
            for (int w = W - 1; w >= 0; w--)
            {
                if (S[h][w] == '#')
                {
                    right = Math.Max(w, right);
                    bottom = Math.Max(h, bottom);
                }
            }
        }

        var isRectangle = true;

        for (int h = top; h <= bottom; h++)
        {
            for (int w = left; w <= right; w++)
            {
                if (S[h][w] == '.')
                {
                    isRectangle = false;
                    break;
                }
            }

            if (!isRectangle)
            {
                break;
            }
        }

        var ans = isRectangle;
        _writer.WriteYesOrNo(ans);
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
