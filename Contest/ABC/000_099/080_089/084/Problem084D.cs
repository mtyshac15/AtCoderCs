using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC084;

public class ProblemD
{
    private Reader _reader;
    private Writer _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemD(Console.In, Console.Out);
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemD(TextReader textReader, TextWriter textWriter)
    {
        _reader = new Reader(textReader);
        _writer = new Writer(textWriter);
    }

    public void Solve()
    {
        var Q = _reader.NextInt();
        var l = new List<int>();
        var r = new List<int>();
        for (int i = 0; i < Q; i++)
        {
            l.Add(_reader.NextInt());
            r.Add(_reader.NextInt());
        }

        var N = 100_000;

        var primes = MathLibrary.Primes(N);
        var near2017 = primes.Where(n => MathLibrary.IsPrime((n + 1) / 2)).ToArray();

        var ansList = new List<long>();
        for (int i = 0; i < Q; i++)
        {
            var minIndex = MathLibrary.LowerBound(near2017, l[i]);
            var maxIndex = MathLibrary.UpperBound(near2017, r[i]) - 1;

            var count = maxIndex - minIndex + 1;
            ansList.Add(count);
        }

        var ans = string.Join(Environment.NewLine, ansList);
        _writer.WriteLine(ans);
    }

    #region
    static class MathLibrary
    {
        /// <summary>
        /// 素数判定
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsPrime(long n)
        {
            if (n <= 1
                || n > 2 && n % 2 == 0)
            {
                return false;
            }

            for (long i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static int[] Primes(int n)
        {
            var primes = new bool[n + 1];
            for (int i = 0; i < n; i++)
            {
                primes[i] = true;
            }

            primes[0] = false;
            primes[1] = false;

            for (int i = 2; i * i <= n; i++)
            {
                if (IsPrime(i))
                {
                    for (int j = i * i; j <= n; j += i)
                    {
                        primes[j] = false;
                    }
                }
            }

            // リストに変換
            return primes.Select((e, i) => e ? i : -1).Where(e => e > 0).ToArray();
        }

        public static int LowerBound(int[] array, int key)
        {
            var index = Array.BinarySearch(array, key);
            if (index < 0)
            {
                index = ~index;
            }
            return index;
        }

        public static int UpperBound(int[] array, int key)
        {
            var index = Array.BinarySearch(array, key);
            if (index < 0)
            {
                index = ~index;
            }
            else
            {
                index++;
            }

            return index;
        }
    }

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
