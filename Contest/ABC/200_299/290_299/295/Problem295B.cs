using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC295;

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
        var R = _reader.NextInt();
        var C = _reader.NextInt();

        var B = new List<IList<char>>();
        for (int i = 0; i < R; i++)
        {
            B.Add(_reader.Next().ToCharArray());
        }

        var afterB = new List<IList<char>>();
        for (int i = 0; i < R; i++)
        {
            afterB.Add(B[i].ToList());
        }

        for (int i = 0; i < R; i++)
        {
            for (int j = 0; j < C; j++)
            {
                if (B[i][j] != '.' && B[i][j] != '#')
                {
                    var num = int.Parse(B[i][j].ToString());

                    for (int r = -num; r <= num; r++)
                    {
                        if (i + r >= 0 && i + r < R)
                        {
                            for (int c = -num + Math.Abs(r); c <= num - Math.Abs(r); c++)
                            {
                                if (j + c >= 0 && j + c < C)
                                {
                                    afterB[i + r][j + c] = '.';
                                }
                            }
                        }
                    }
                }
            }
        }

        var ans = string.Join(Environment.NewLine, afterB.Select(x => string.Concat(x)));
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
