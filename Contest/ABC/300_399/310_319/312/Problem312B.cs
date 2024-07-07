using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC312;

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

    /// <summary>
    /// TaK Code
    /// </summary>
    public void Solve()
    {
        var N = _reader.NextInt();
        var M = _reader.NextInt();

        var S = new List<string>();
        for (int i = 0; i < N; i++)
        {
            S.Add(_reader.Next());
        }

        var ansBuilder = new StringBuilder();

        for (int i = 0; i < N - 8; i++)
        {
            for (int j = 0; j < M - 8; j++)
            {
                if (this.IsTakCode(S, i, j))
                {
                    ansBuilder.AppendLine($"{i + 1} {j + 1}");
                }
            }
        }

        var ans = ansBuilder.ToString();
        _writer.WriteLine(ans);
    }

    private bool IsTakCode(IReadOnlyList<string> S, int i, int j)
    {
        for (int dx = 0; dx < 3; dx++)
        {
            for (int dy = 0; dy < 3; dy++)
            {
                //左上 黒
                if (S[i + dx][j + dy] != '#')
                {
                    return false;
                }

                //右下 黒
                if (S[i + 8 - dx][j + 8 - dy] != '#')
                {
                    return false;
                }
            }

            //白
            if (S[i + dx][j + 3] != '.')
            {
                return false;
            }

            if (S[i + 8 - dx][j + 5] != '.')
            {
                return false;
            }
        }

        for (int dy = 0; dy < 4; dy++)
        {
            //左上 白
            if (S[i + 3][j + dy] != '.')
            {
                return false;
            }

            //右下 白
            if (S[i + 5][j + 8 - dy] != '.')
            {
                return false;
            }
        }

        return true;
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
