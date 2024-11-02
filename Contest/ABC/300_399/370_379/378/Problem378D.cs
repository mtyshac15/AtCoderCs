using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC378;

public class ProblemD
{
    private Reader _reader;
    private Writer _writer;

    //隣接4方向
    private int[] _dh = new int[] { 0, 1, 0, -1 };
    private int[] _dw = new int[] { 1, 0, -1, 0 };


    private int _H;
    private int _W;
    private int _K;
    private List<string> _S;

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

    public ProblemD(TextReader textReader, TextWriter textWriter)
    {
        _reader = new Reader(textReader);
        _writer = new Writer(textWriter);
    }

    public void Solve()
    {
        _H = _reader.NextInt();
        _W = _reader.NextInt();
        _K = _reader.NextInt();

        _S = new List<string>();
        for (int i = 0; i < _H; i++)
        {
            _S.Add(_reader.Next());
        }

        var count = 0L;
        for (var h = 0; h < _H; h++)
        {
            for (int w = 0; w < _W; w++)
            {
                if (_S[h][w] == '.')
                {
                    var seen = new bool[_H, _W];
                    count += this.Search(h, w, 0, seen, 0);
                }
            }
        }

        var ans = count;
        _writer.WriteLine(ans);
    }

    private int Search(int h, int w, int step, bool[,] seen, int count)
    {
        if (step == _K)
        {
            return count + 1;
        }

        seen[h, w] = true;

        var resultCount = count;
        for (int i = 0; i < 4; i++)
        {
            var nextH = h + _dh[i];
            var nextW = w + _dw[i];

            if (nextH >= 0 && nextH < _H
                && nextW >= 0 && nextW < _W
                && _S[nextH][nextW] == '.'
                && !seen[nextH, nextW])
            {
                resultCount += this.Search(nextH, nextW, step + 1, seen, count);
            }
        }

        // 訪れなかったことにする
        seen[h, w] = false;
        return resultCount;
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
