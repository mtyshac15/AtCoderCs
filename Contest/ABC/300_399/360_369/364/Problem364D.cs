using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC364;

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
        var Q = _reader.NextInt();
        var a = _reader.NextIntArray();

        var b = new List<int>();
        var k = new List<int>();
        for (int i = 0; i < Q; i++)
        {
            b.Add(_reader.NextInt());
            k.Add(_reader.NextInt());
        }

        Array.Sort(a);

        Func<int, int, int> f = (int bj, int x) =>
        {
            //bj-x から bj+xに範囲にあるaiの個数を求める

            var min = 0;
            {
                var ng = -1;
                var ok = a.Length;
                while (Math.Abs(ok - ng) > 1)
                {
                    var middle = ng + (ok - ng) / 2;
                    if (a[middle] >= bj - x)
                    {
                        ok = middle;
                    }
                    else
                    {
                        ng = middle;
                    }
                }

                min = ok;
            }

            var max = 0;
            {
                var ng = a.Length;
                var ok = -1;
                while (Math.Abs(ok - ng) > 1)
                {
                    var middle = ok + (ng - ok) / 2;
                    if (a[middle] <= bj + x)
                    {
                        ok = middle;
                    }
                    else
                    {
                        ng = middle;
                    }
                }

                max = ok;
            }

            return max - min + 1;
        };

        var ansBuilder = new StringBuilder();

        for (int j = 0; j < Q; j++)
        {
            var left = Math.Abs(b[j] - a[0]);
            var right = Math.Abs(b[j] - a[a.Length - 1]);
            var max = Math.Max(left, right);

            var ng = -1;
            var ok = max + 1;

            while (Math.Abs(ok - ng) > 1)
            {
                var middle = ng + (ok - ng) / 2;
                var count = f(b[j], middle);
                if (count >= k[j])
                {
                    ok = middle;
                }
                else
                {
                    ng = middle;
                }
            }

            ansBuilder.AppendLine($"{ok}");
        }

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
