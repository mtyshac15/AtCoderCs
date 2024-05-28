using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC327;

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
        var A = new int[9, 9];
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                A[i, j] = _reader.NextInt();
            }
        }

        var ans = this.Check(A);
        _writer.WriteYesOrNo(ans);
    }

    private bool Check(int[,] A)
    {
        //行
        {
            for (int row = 0; row < 9; row++)
            {
                var set = new HashSet<int>();
                for (int col = 0; col < 9; col++)
                {
                    set.Add(A[row, col]);
                }

                if (set.Count < 9)
                {
                    return false;
                }
            }
        }

        {
            //列
            for (int col = 0; col < 9; col++)
            {
                var set = new HashSet<int>();
                for (int row = 0; row < 9; row++)
                {
                    set.Add(A[row, col]);
                }

                if (set.Count < 9)
                {
                    return false;
                }
            }
        }

        {
            //3*3
            for (int cell = 0; cell < 9; cell++)
            {
                var startRow = (cell % 3) * 3;
                var startCol = (cell / 3) * 3;

                var set = new HashSet<int>();
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        set.Add(A[startRow + row, startCol + col]);
                    }
                }

                if (set.Count < 9)
                {
                    return false;
                }
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
