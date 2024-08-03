using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC361;

public class ProblemF
{
    private Reader _reader;
    private Writer _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemF();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemF()
        : this(Console.In, Console.Out)
    {
    }

    public ProblemF(TextReader textReader, TextWriter textWriter)
    {
        _reader = new Reader(textReader);
        _writer = new Writer(textWriter);
    }

    public void Solve()
    {
        var N = _reader.NextLong();

        var primeB = new List<int>() { 2 };
        for (int b = 3; b < 60; b++)
        {
            var isPrime = true;
            if (b % 2 == 0)
            {
                isPrime = false;
            }
            else
            {
                for (int i = 3; i * i <= b; i += 2)
                {
                    if (i != b && b % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            }

            if (isPrime)
            {
                primeB.Add(b);
            }
        }

        var count = 1L;
        foreach (var b in primeB)
        {
            var ok = 1L;
            var ng = (long)int.MaxValue;

            while (Math.Abs(ok - ng) > 1)
            {
                var middle = (ok + ng) / 2;

                var isOk = true;
                var product = 1L;
                for (int i = 0; i < b; i++)
                {
                    product *= middle;
                    if (product > N)
                    {
                        isOk = false;
                        break;
                    }
                }

                if (isOk)
                {
                    ok = middle;
                }
                else
                {
                    ng = middle;
                }
            }

            count += ok - 1;
        }

        var ans = count;
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
