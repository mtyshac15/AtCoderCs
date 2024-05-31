using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC325;

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
        var S = new string[H];
        for (int i = 0; i < H; i++)
        {
            S[i] = _reader.Next();
        }

        //隣接8方向
        var dh = new int[] { 0, 1, 1, 1, 0, -1, -1, -1 };
        var dw = new int[] { 1, 1, 0, -1, -1, -1, 0, 1 };

        var seen = new int[H, W];
        for (int h = 0; h < H; h++)
        {
            for (int w = 0; w < W; w++)
            {
                seen[h, w] = -1;
            }
        }

        var sensor = 0;
        var stack = new Stack<(int H, int W)>();

        for (int h = 0; h < H; h++)
        {
            for (int w = 0; w < W; w++)
            {
                if (seen[h, w] == -1)
                {
                    if (S[h][w] == '#')
                    {
                        sensor++;
                        seen[h, w] = sensor;
                        stack.Push((h, w));
                    }
                    else
                    {
                        seen[h, w] = 0;
                    }

                    //隣接するセンサーを探索
                    while (stack.Any())
                    {
                        var cell = stack.Pop();

                        for (var i = 0; i < 8; i++)
                        {
                            var nextH = cell.H + dh[i];
                            var nextW = cell.W + dw[i];

                            if (nextH >= 0 && nextH < H
                                && nextW >= 0 && nextW < W)
                            {
                                if (seen[nextH, nextW] == -1)
                                {
                                    if (S[nextH][nextW] == '#')
                                    {
                                        seen[nextH, nextW] = sensor;
                                        stack.Push((nextH, nextW));
                                    }
                                    else
                                    {
                                        seen[nextH, nextW] = 0;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        var ans = sensor;
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
