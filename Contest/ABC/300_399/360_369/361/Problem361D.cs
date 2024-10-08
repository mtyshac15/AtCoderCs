﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC361;

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
        var N = _reader.NextInt();
        var S = _reader.Next();
        var T = _reader.Next();

        var start = S + "..";
        var goal = T + "..";

        var bCountS = S.Count(x => x == 'B');
        var bCountT = T.Count(x => x == 'B');

        if (bCountS != bCountT)
        {
            _writer.WriteLine(-1);
            return;
        }

        var seen = new Dictionary<string, int>()
        {
            { start, 0 }
        };

        var queue = new Queue<string>();
        queue.Enqueue(start);

        while (queue.Any())
        {
            var current = queue.Dequeue();
            if (current == goal)
            {
                break;
            }

            //入れ替える2コマを順に探索
            for (int x = 0; x < N + 1; x++)
            {
                //xとx+1にともに石が置かれていない場合に交換可能
                var span = current.AsSpan(x, 2);
                if (span[0] != '.' && span[1] != '.')
                {
                    var breakIndex = current.IndexOf('.');

                    var nextList = current.ToList();
                    nextList[breakIndex] = current[x];
                    nextList[breakIndex + 1] = current[x + 1];
                    nextList[x] = '.';
                    nextList[x + 1] = '.';

                    var next = string.Join(string.Empty, nextList);
                    if (!seen.ContainsKey(next))
                    {
                        seen.Add(next, seen[current] + 1);
                        queue.Enqueue(next);
                    }
                }
            }
        }

        var ans = -1;
        if (seen.ContainsKey(goal))
        {
            ans = seen[goal];
        }

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
