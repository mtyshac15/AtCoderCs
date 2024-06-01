using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Training.ATC001;

public class ProblemA
{
    private Reader _reader;
    private Writer _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemA();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemA()
        : this(Console.In, Console.Out)
    {
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

        var c = new List<string>();
        for (int i = 0; i < H; i++)
        {
            c.Add(_reader.Next());
        }

        var sh = 0;
        var sw = 0;
        var gh = 0;
        var gw = 0;

        for (int h = 0; h < H; h++)
        {
            for (int w = 0; w < W; w++)
            {
                if (c[h][w] == 's')
                {
                    sh = h;
                    sw = w;
                }
                else if (c[h][w] == 'g')
                {
                    gh = h;
                    gw = w;
                }
            }
        }

        var seen = new bool[H, W];

        var dh = new int[] { 0, 1, 0, -1 };
        var dw = new int[] { 1, 0, -1, 0 };

        var stack = new Stack<(int H, int W)>();
        stack.Push((sh, sw));
        seen[sh, sw] = true;

        while (stack.Any())
        {
            var cell = stack.Pop();

            if (c[cell.H][cell.W] != '#')
            {
                if (cell.H == gh && cell.W == gw)
                {
                    break;
                }

                for (int i = 0; i < 4; i++)
                {
                    var nextH = cell.H + dh[i];
                    var nextW = cell.W + dw[i];

                    if (nextH >= 0 && nextH < H
                        && nextW >= 0 && nextW < W)
                    {
                        if (!seen[nextH, nextW])
                        {
                            seen[nextH, nextW] = true;
                            stack.Push((nextH, nextW));
                        }
                    }
                }
            }
        }

        var ans = seen[gh, gw];
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
