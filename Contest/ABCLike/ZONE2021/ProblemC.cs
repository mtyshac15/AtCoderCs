using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABCLike.ZONE2021;

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

        var dic = new Dictionary<int, int[]>();
        for (int i = 0; i < N; i++)
        {
            dic[i] = _reader.NextIntArray();
        }

        var ng = 1_000_000_000 + 1;
        var ok = 0;

        while (Math.Abs(ok - ng) > 1)
        {
            var middle = ok + (ng - ok) / 2;

            var set = new HashSet<int>();
            foreach (var person in dic)
            {
                var bit = 0;
                foreach (var ability in person.Value)
                {
                    bit <<= 1;
                    bit |= ability >= middle ? 1 : 0;
                }

                set.Add(bit);
            }

            var isOk = false;
            foreach (var x in set)
            {
                foreach (var y in set)
                {
                    foreach (var z in set)
                    {
                        if ((x | y | z) == 31)
                        {
                            isOk = true;
                        }
                    }

                    if (isOk)
                    {
                        break;
                    }
                }

                if (isOk)
                {
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

        var ans = ok;
        _writer.WriteLine(ans);
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

        public long[] NextLongArray()
        {
            return this.NextArray().Select(long.Parse).ToArray();
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
