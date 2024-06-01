using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Training.Typical.Problem004;

public class Problem
{
    private Reader _reader;
    private Writer _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new Problem();
        problem.Solve();
        Console.Out.Flush();
    }

    public Problem()
          : this(Console.In, Console.Out)
    {
    }

    public Problem(TextReader textReader, TextWriter textWriter)
    {
        _reader = new Reader(textReader);
        _writer = new Writer(textWriter);
    }

    /// <summary>
    /// Cross Sum
    /// </summary>
    public void Solve()
    {
        var H = _reader.NextInt();
        var W = _reader.NextInt();

        var A = new int[H + 1, W + 1];

        for (int h = 0; h < H; h++)
        {
            var input = _reader.NextIntArray();
            for (int w = 0; w < W; w++)
            {
                var a = input[w];
                A[h, w] = a;

                //行ごと、列ごとの和を保持
                A[h, W] += a;
                A[H, w] += a;
            }
        }

        var ansBuilder = new StringBuilder();
        for (int h = 0; h < H; h++)
        {
            var list = new List<int>();
            for (int w = 0; w < W; w++)
            {
                var B = A[h, W] + A[H, w] - A[h, w];
                list.Add(B);
            }

            ansBuilder.AppendLine(string.Join(" ", list));
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
