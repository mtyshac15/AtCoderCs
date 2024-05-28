using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC188;

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
        var C = _reader.NextInt();

        var a = new List<int>();
        var b = new List<int>();
        var c = new List<int>();
        for (int i = 0; i < N; i++)
        {
            a.Add(_reader.NextInt());
            b.Add(_reader.NextInt());
            c.Add(_reader.NextInt());
        }

        //‘Œ¸‚ð‹L˜^
        var prime = new SortedDictionary<int, long>();
        for (int i = 0; i < N; i++)
        {
            if (prime.ContainsKey(a[i]))
            {
                prime[a[i]] += c[i];
            }
            else
            {
                prime.Add(a[i], c[i]);
            }

            var afterB = b[i] + 1;
            if (prime.ContainsKey(afterB))
            {
                prime[afterB] -= c[i];
            }
            else
            {
                prime.Add(afterB, c[i] * (-1));
            }
        }

        //WŒv
        var sum = 0L;

        var startDay = prime.Keys.FirstOrDefault();
        var prevCost = prime.Values.FirstOrDefault();
        foreach (var keyValue in prime.Skip(1))
        {
            var cost = Math.Min(prevCost, C);
            sum += (keyValue.Key - startDay) * cost;

            startDay = keyValue.Key;
            prevCost += keyValue.Value;
        }

        var ans = sum;
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
