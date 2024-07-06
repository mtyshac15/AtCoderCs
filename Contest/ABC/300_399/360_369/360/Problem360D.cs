using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC360;

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
        var T = _reader.NextInt();
        var S = _reader.Next();
        var X = _reader.NextIntArray();

        var plus = new List<long>();
        var minus = new List<long>();
        for (int i = 0; i < N; i++)
        {
            if (S[i] == '1')
            {
                plus.Add(X[i]);
            }
            else if (S[i] == '0')
            {
                minus.Add(X[i]);
            }
        }

        plus.Sort();
        minus.Sort();

        var total = 0L;
        foreach (var plusAnt in plus)
        {
            var startIndex = 0;
            {
                //負の方向に進む蟻のうち、対象の蟻の開始点以上の蟻
                var ok = minus.Count;
                var ng = -1;

                while (Math.Abs(ok - ng) > 1)
                {
                    var middle = ng + (ok - ng) / 2;
                    if (minus[middle] >= plusAnt)
                    {
                        ok = middle;
                    }
                    else
                    {
                        ng = middle;
                    }
                }

                startIndex = ok;
            }

            var endIndex = 0;
            {
                //負の方向に進んだ移動後の蟻のうち、対象の蟻の終着点以下の蟻

                var ok = -1;
                var ng = minus.Count;

                while (Math.Abs(ok - ng) > 1)
                {
                    var middle = ok + (ng - ok) / 2;
                    if (minus[middle] - T <= plusAnt + T)
                    {
                        ok = middle;
                    }
                    else
                    {
                        ng = middle;
                    }
                }

                endIndex = ok;
            }

            total += (long)endIndex - startIndex + 1;
        }

        var ans = total;
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
