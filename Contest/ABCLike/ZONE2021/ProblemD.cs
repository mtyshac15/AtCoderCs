using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABCLike.ZONE2021;

public class ProblemD
{
    private Reader _reader;
    private Writer _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemD();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemD()
        : this(Console.In, Console.Out)
    {
    }

    public ProblemD(TextReader textReader, TextWriter textWriter)
    {
        _reader = new Reader(textReader);
        _writer = new Writer(textWriter);
    }

    public void Solve()
    {
        var S = _reader.Next();

        var observe = new List<char>();
        var reverse = new List<char>();

        var isReverse = false;
        foreach (var c in S)
        {
            switch (c)
            {
                case 'R':
                    isReverse = !isReverse;
                    break;

                default:
                    if (!isReverse)
                    {
                        var last = char.MinValue;
                        if (observe.Any())
                        {
                            last = observe[^1];
                        }

                        if (last == c)
                        {
                            observe.RemoveAt(observe.Count - 1);
                        }
                        else
                        {
                            observe.Add(c);
                        }
                    }
                    else
                    {
                        var last = char.MinValue;
                        if (reverse.Any())
                        {
                            last = reverse[^1];
                        }

                        if (last == c)
                        {
                            reverse.RemoveAt(reverse.Count - 1);
                        }
                        else
                        {
                            reverse.Add(c);
                        }
                    }
                    break;
            }
        }

        // 重複の削除
        var index = -1;
        for (int i = 0; i < Math.Min(observe.Count, reverse.Count); i++)
        {
            if (observe[i] != reverse[i])
            {
                break;
            }

            index = i;
        }

        var T = new List<char>();

        if (!isReverse)
        {
            reverse.Reverse();
            T.AddRange(reverse.Take(reverse.Count - 1 - index));
            T.AddRange(observe.Skip(index + 1));
        }
        else
        {
            observe.Reverse();
            T.AddRange(observe.Take(observe.Count - 1 - index));
            T.AddRange(reverse.Skip(index + 1));
        }

        var ans = string.Concat(T);
        _writer.WriteLine(ans);
    }

    #region
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

        public long[] NextLongArray()
        {
            return this.NextArray().Select(long.Parse).ToArray();
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
