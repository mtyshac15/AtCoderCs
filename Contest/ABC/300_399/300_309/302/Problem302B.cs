using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC302;

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
        var H = _reader.NextInt();
        var W = _reader.NextInt();

        var S = new List<string>();
        for (int i = 0; i < H; i++)
        {
            S.Add(_reader.Next());
        }

        //—×Ú8•ûŒü
        var dr = new int[] { 0, 1, 1, 1, 0, -1, -1, -1 };
        var dc = new int[] { 1, 1, 0, -1, -1, -1, 0, 1 };

        var A = "snuke";

        for (int h = 0; h < H; h++)
        {
            for (int w = 0; w < W; w++)
            {
                if (S[h][w] == A[0])
                {
                    for (int direction = 0; direction < 8; direction++)
                    {
                        var isMatch = true;

                        var ansList = new List<string>();

                        for (int distance = 0; distance < A.Length; distance++)
                        {
                            var r = h + dr[direction] * distance;
                            var c = w + dc[direction] * distance;

                            if (r >= 0 && r < H
                                && c >= 0 && c < W
                                && S[r][c] == A[distance])
                            {
                                ansList.Add($"{r + 1} {c + 1}");
                            }
                            else
                            {
                                isMatch = false;
                                break;
                            }
                        }

                        if (isMatch)
                        {
                            var ans = string.Join(Environment.NewLine, ansList);
                            _writer.WriteLine(ans);
                            return;
                        }
                    }
                }
            }
        }
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
