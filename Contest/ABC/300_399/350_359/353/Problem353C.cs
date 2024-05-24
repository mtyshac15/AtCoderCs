using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC353;

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
        var cons = 100000000;

        var N = _reader.NextInt();

        var A = new SortedList<int, int>();
        for (int i = 0; i < N; i++)
        {
            var a = _reader.NextInt();
            A.Add(a, a);
        }

        //累積和
        var s = new long[N + 1];
        for (var i = 0; i < N; i++)
        {
            s[i + 1] = s[i] + A.Values[i];
        }

        //x+y >= 10^18 を満たすペアの個数を求める
        var count = 0L;
        for (int i = 0; i < N - 1; i++)
        {
            var x = A.Values[i];

            // x+y >=10^18を満たす最小のyを求める
            var ng = i;
            var ok = N;
            while (Math.Abs(ok - ng) > 1)
            {
                var middle = ng + (ok - ng) / 2;
                if (x + A.Values[middle] >= cons)
                {
                    ok = middle;
                }
                else
                {
                    ng = middle;
                }
            }

            count += N - ok;
        }

        var ans = s[N] * (N - 1) - cons * count;
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
