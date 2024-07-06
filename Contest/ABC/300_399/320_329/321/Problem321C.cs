using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC321;

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
        var K = _reader.NextLong();

        var dp = new long[11, 10];
        dp[1, 0] = 1;
        for (int i = 1; i < 10; i++)
        {
            dp[1, i] = dp[1, i - 1] + 1;
        }

        for (int i = 2; i < 11; i++)
        {
            dp[i, i - 1] = 1;

            for (int j = i; j < 10; j++)
            {
                dp[i, j] = dp[i, j - 1] + dp[i - 1, j - 1];
            }
        }

        var digit = 1;
        var total = -1L;
        for (int i = 1; i < 11; i++)
        {
            if (total + dp[i, 9] >= K)
            {
                digit = i;
                break;
            }

            total += dp[i, 9];
        }

        var remainder = K - total;

        var numList = new List<int>();

        var currentDigit = digit;
        while (currentDigit > 0)
        {
            for (int i = 0; i < 10; i++)
            {
                if (dp[currentDigit, i] >= remainder)
                {
                    numList.Add(i);

                    var index = Math.Max(i - 1, 0);
                    remainder -= dp[currentDigit, index];
                    currentDigit--;
                    break;
                }
            }
        }

        var ans = string.Join(string.Empty, numList);
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
