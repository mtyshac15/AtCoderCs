using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC339;

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
        var N = _reader.NextInt();

        var grid = new char[H, W];
        for (int i = 0; i < H; i++)
        {
            for (int j = 0; j < W; j++)
            {
                grid[i, j] = '.';
            }
        }

        var currentI = 0;
        var currentJ = 0;

        var directionI = -1;
        var directionJ = 0;

        for (var i = 0; i < N; i++)
        {
            var tempI = directionI;
            var tempJ = directionJ;

            if (grid[currentI, currentJ] == '.')
            {
                grid[currentI, currentJ] = '#';

                //[0. 1]
                //[-1 0]

                directionI = tempJ;
                directionJ = -tempI;
            }
            else
            {
                grid[currentI, currentJ] = '.';

                //[0. -1]
                //[1 0]

                directionI = -tempJ;
                directionJ = tempI;
            }

            currentI += directionI + H;
            currentI %= H;
            currentJ += directionJ + W;
            currentJ %= W;
        }

        var strtBuilder = new StringBuilder();

        //行、列
        var row = grid.GetLength(0);
        var col = grid.GetLength(1);

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                strtBuilder.Append(grid[i, j]);
            }
            strtBuilder.AppendLine();
        }

        _writer.WriteLine(strtBuilder.ToString());
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
