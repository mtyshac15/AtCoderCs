using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC335;

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
        var N = _reader.NextInt();
        var Q = _reader.NextInt();

        var query1 = new List<int>();
        var query2 = new List<string>();

        for (int i = 0; i < Q; i++)
        {
            query1.Add(_reader.NextInt());
            query2.Add(_reader.Next());
        }

        var headX = 1;
        var headY = 0;

        var headXList = new List<int>();
        var headYList = new List<int>();

        var moveCount = 0;

        var ansBuilder = new StringBuilder();
        for (int i = 0; i < Q; i++)
        {
            if (query1[i] == 1)
            {
                switch (query2[i])
                {
                    case "L":
                        headX--;
                        break;

                    case "R":
                        headX++;
                        break;

                    case "U":
                        headY++;
                        break;

                    case "D":
                        headY--;
                        break;
                }

                moveCount++;
                headXList.Add(headX);
                headYList.Add(headY);
            }
            else
            {
                var p = int.Parse(query2[i]);

                var x = headX;
                var y = headY;
                if (moveCount < p)
                {
                    x = p - moveCount;
                    y = 0;
                }
                else
                {
                    x = headXList[moveCount - p];
                    y = headYList[moveCount - p];
                }

                ansBuilder.AppendLine($"{x} {y}");
            }
        }

        var ans = ansBuilder.ToString();
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
