using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC380;

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
        var K = _reader.NextInt();
        var S = _reader.Next();

        var S0 = string.Concat(S, "0");

        // K-1番目
        var jStartIndex = -1;
        var jEndtIndex = -1;

        // K番目
        var kStartIndex = -1;
        var kEndtIndex = -1;

        var isOne = false;

        var count = 0;
        for (int i = 0; i < S0.Length; i++)
        {
            if (!isOne)
            {
                if (S0[i] == '1')
                {
                    isOne = true;

                    count++;
                    if (count == K - 1)
                    {
                        jStartIndex = i;
                    }
                    else if (count == K)
                    {
                        kStartIndex = i;
                    }
                }
            }
            else
            {
                if (S0[i] == '0')
                {
                    isOne = false;

                    if (count == K - 1)
                    {
                        jEndtIndex = i;
                    }
                    else if (count == K)
                    {
                        kEndtIndex = i;
                    }
                }
            }
        }

        var ansBuilder = new StringBuilder();
        ansBuilder.Append(S0.AsSpan(0, jStartIndex));
        ansBuilder.Append(S0.AsSpan(kStartIndex, kEndtIndex - kStartIndex));
        ansBuilder.Append(S0.AsSpan(jStartIndex, jEndtIndex - jStartIndex));
        ansBuilder.Append(S0.AsSpan(jEndtIndex, kStartIndex - jEndtIndex));
        ansBuilder.Append(S0.AsSpan(kEndtIndex, S0.Length - 1 - kEndtIndex));

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
