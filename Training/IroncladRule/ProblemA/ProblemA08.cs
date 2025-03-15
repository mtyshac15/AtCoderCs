using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Training.A08;

public class ProblemA
{
    private Reader _reader;
    private Writer _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemA(Console.In, Console.Out);
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemA(TextReader textReader, TextWriter textWriter)
    {
        _reader = new Reader(textReader);
        _writer = new Writer(textWriter);
    }

    public void Solve()
    {
        var H = _reader.NextInt();
        var W = _reader.NextInt();

        var X = new int[H, W];
        for (int h = 0; h < H; h++)
        {
            for (int w = 0; w < W; w++)
            {
                X[h, w] = _reader.NextInt();
            }
        }

        var Q = _reader.NextInt();
        var A = new List<int>();
        var B = new List<int>();
        var C = new List<int>();
        var D = new List<int>();

        for (int i = 0; i < Q; i++)
        {
            A.Add(_reader.NextInt());
            B.Add(_reader.NextInt());
            C.Add(_reader.NextInt());
            D.Add(_reader.NextInt());
        }

        var sumX = new int[H + 1, W + 1];

        // 累積和
        for (int h = 0; h < H; h++)
        {
            for (int w = 0; w < W; w++)
            {
                sumX[h + 1, w + 1] = sumX[h + 1, w] + X[h, w];
            }
        }

        for (int w = 0; w < W; w++)
        {
            for (int h = 0; h < H; h++)
            {
                sumX[h + 1, w + 1] += sumX[h, w + 1];
            }
        }

        // 集計
        var ansList = new List<int>();
        for (int i = 0; i < Q; i++)
        {
            var sum = sumX[C[i], D[i]] - sumX[A[i] - 1, D[i]] - sumX[C[i], B[i] - 1] + sumX[A[i] - 1, B[i] - 1];
            ansList.Add(sum);
        }

        var ans = string.Join(Environment.NewLine, ansList);
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

        public long[] NextLongArray()
        {
            return this.NextArray().Select(long.Parse).ToArray();
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
