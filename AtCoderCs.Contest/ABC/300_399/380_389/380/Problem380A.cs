﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC380.ProblemA;

public class ProblemA
{
    private Reader _reader;
    private Writer _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemA(Console.In, Console.Out);
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemA(TextReader textReader, TextWriter textWriter)
    {
        _reader = new Reader(textReader);
        _writer = new Writer(textWriter);
    }

    public void Solve()
    {
        var S = _reader.Next();

        var ans = S.Count(x => x == '1') == 1 && S.Count(x => x == '2') == 2 && S.Count(x => x == '3') == 3;
        _writer.WriteYesOrNo(ans);
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
        _line = Array.Empty<string>();
    }

    private string NextLine()
    {
        var line = _reader.ReadLine() ?? string.Empty;
        return line.Trim();
    }

    public string Str()
    {
        if (_index < _line.Length)
        {
            return _line[_index++];
        }

        _line = this.StrArray();
        if (!_line.Any())
        {
            return this.Str();
        }

        _index = 0;
        return _line[_index++];
    }

    public int Int()
    {
        return int.Parse(this.Str());
    }

    public long Long()
    {
        return long.Parse(this.Str());
    }

    public string[] StrArray()
    {
        return this.NextLine().Split(_cs, StringSplitOptions.RemoveEmptyEntries);
    }

    public int[] IntArray()
    {
        return this.StrArray().Select(int.Parse).ToArray();
    }

    public long[] LongArray()
    {
        return this.StrArray().Select(long.Parse).ToArray();
    }
}

class Writer
{
    private TextWriter _writer;

    public Writer(TextWriter writer)
    {
        _writer = writer;
    }

    public void WriteLine(object? value = null)
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
