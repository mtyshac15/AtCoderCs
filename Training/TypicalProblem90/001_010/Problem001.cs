﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Training.Typical.Problem001;

public class Problem
{
    private Reader _reader;
    private Writer _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new Problem();
        problem.Solve();
        Console.Out.Flush();
    }

    public Problem()
          : this(Console.In, Console.Out)
    {
    }

    public Problem(TextReader textReader, TextWriter textWriter)
    {
        _reader = new Reader(textReader);
        _writer = new Writer(textWriter);
    }

    public void Solve()
    {
        var N = _reader.NextInt();
        var L = _reader.NextInt();
        var K = _reader.NextInt();
        var A = _reader.NextIntArray();

        var newA = A.Prepend(0).Append(L).ToArray();

        var ok = -1;
        var ng = L + 1;

        while (Math.Abs(ok - ng) > 1)
        {
            var left = Math.Min(ok, ng);
            var right = Math.Max(ok, ng);

            var middle = left + (right - left) / 2;

            var count = 0;

            //前回の切れ目
            var pre = 0;
            for (var i = 1; i < newA.Length; i++)
            {
                if (newA[i] - pre >= middle)
                {
                    pre = newA[i];
                    count++;
                }
            }

            if (count >= K + 1)
            {
                ok = middle;
            }
            else
            {
                ng = middle;
            }
        }

        var ans = ok;
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
