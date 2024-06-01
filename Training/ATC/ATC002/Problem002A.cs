using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Training.ATC002;

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
        var R = _reader.NextInt();
        var C = _reader.NextInt();

        var sy = _reader.NextInt();
        var sx = _reader.NextInt();

        var gy = _reader.NextInt();
        var gx = _reader.NextInt();

        var c = new List<string>();
        for (int i = 0; i < R; i++)
        {
            c.Add(_reader.Next());
        }

        var seen = new int[R, C];
        for (int y = 0; y < R; y++)
        {
            for (int x = 0; x < C; x++)
            {
                seen[y, x] = -1;
            }
        }

        var dx = new int[] { 1, 0, -1, 0 };
        var dy = new int[] { 0, 1, 0, -1 };

        var queue = new Queue<(int X, int Y)>();
        queue.Enqueue((sx - 1, sy - 1));
        seen[sy - 1, sx - 1] = 0;

        while (queue.Any())
        {
            var cell = queue.Dequeue();

            if (c[cell.Y][cell.X] != '#')
            {
                if (cell.X == gx - 1 && cell.Y == gy - 1)
                {
                    break;
                }

                for (int i = 0; i < 4; i++)
                {
                    var nextX = cell.X + dx[i];
                    var nextY = cell.Y + dy[i];

                    if (nextX >= 0 && nextX < C
                        && nextY >= 0 && nextY < R)
                    {
                        if (seen[nextY, nextX] < 0)
                        {
                            seen[nextY, nextX] = seen[cell.Y, cell.X] + 1;
                            queue.Enqueue((nextX, nextY));
                        }
                    }
                }
            }
        }

        var ans = seen[gy - 1, gx - 1];
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
