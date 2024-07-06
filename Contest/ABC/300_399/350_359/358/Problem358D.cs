using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC358;

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
        var M = _reader.NextInt();
        var A = _reader.NextIntArray();
        var B = _reader.NextIntArray();

        Array.Sort(A);
        Array.Sort(B);

        var dictionary = new SortedDictionary<int, int>();
        for (int i = 0; i < N; i++)
        {
            if (dictionary.ContainsKey(A[i]))
            {
                dictionary[A[i]]++;
            }
            else
            {
                dictionary.Add(A[i], 1);
            }
        }

        var total = 0L;
        for (int i = 0; i < M; i++)
        {
            var ng = -1;
            var ok = A.Length;

            while (Math.Abs(ok - ng) > 1)
            {
                var mid = (ok + ng) / 2;
                if (A[mid] >= B[i]
                    && dictionary[A[mid]] > 0)
                {
                    ok = mid;
                }
                else
                {
                    ng = mid;
                }
            }

            if (ok == A.Length)
            {
                //配れるお菓子がない場合
                total = -1;
                break;
            }
            else
            {
                var price = A[ok];
                if (dictionary[price] > 0)
                {
                    total += price;
                    dictionary[price]--;
                }
                else
                {
                    total = -1;
                    break;
                }
            }
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
