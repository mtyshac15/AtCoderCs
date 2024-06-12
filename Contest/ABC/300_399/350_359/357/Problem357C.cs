using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC357;

public class ProblemC
{
    private Reader _reader;
    private Writer _writer;

    private IDictionary<int, IList<string>> _carpet;

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
        var N = _reader.NextInt();
        _carpet = new Dictionary<int, IList<string>>();

        var grid = this.Carpet(N);
        var ansBuilder = new StringBuilder();
        foreach (var line in grid)
        {
            ansBuilder.AppendLine(line);
        }
        var ans = ansBuilder.ToString();
        _writer.WriteLine(ans);
    }

    private IList<string> Carpet(int K)
    {
        if (_carpet.ContainsKey(K))
        {
            return _carpet[K];
        }

        if (K == 0)
        {
            _carpet.Add(K, new string[] { "#" });
        }
        else
        {
            var block = 1;
            for (int i = 0; i < K; i++)
            {
                block *= 3;
            }

            var grid = new string[block, block];

            var section = 1;
            for (int i = 0; i < K - 1; i++)
            {
                section *= 3;
            }

            var cellGrid = this.Carpet(K - 1);

            for (int w = 0; w < 3; w++)
            {
                for (int h = 0; h < 3; h++)
                {
                    if (h == 1 && w == 1)
                    {
                        for (int i = 0; i < section; i++)
                        {
                            for (int j = 0; j < section; j++)
                            {
                                var row = w * section + i;
                                var col = h * section + j;
                                grid[row, col] = ".";
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < section; i++)
                        {
                            for (int j = 0; j < section; j++)
                            {
                                var row = w * section + i;
                                var col = h * section + j;
                                grid[row, col] = cellGrid[i][j].ToString();
                            }
                        }
                    }
                }
            }

            var ansGrid = new List<string>();
            for (int w = 0; w < block; w++)
            {
                var line = new List<string>();
                for (int h = 0; h < block; h++)
                {
                    line.Add(grid[w, h]);
                }
                ansGrid.Add(string.Join(string.Empty, line));
            }

            _carpet.Add(K, ansGrid);
        }
        return _carpet[K];
    }

    #region "IO"
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
