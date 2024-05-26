using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC077;

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
        var A = _reader.NextIntArray();
        var B = _reader.NextIntArray();
        var C = _reader.NextIntArray();

        Array.Sort(A);
        Array.Sort(C);

        var count = 0L;
        for (int bIndex = 0; bIndex < B.Length; bIndex++)
        {
            //中部のパーツより大きい下部のパーツのイテレータ
            var maxC = 0L;
            {
                var ok = C.Length;
                var ng = -1;

                while (Math.Abs(ok - ng) > 1)
                {
                    var min = Math.Min(ok, ng);
                    var max = Math.Max(ok, ng);

                    var middle = min + (max - min) / 2;

                    if (C[middle] > B[bIndex])
                    {
                        ok = middle;
                    }
                    else
                    {
                        ng = middle;
                    }
                }

                maxC = ok;
            }

            //中部のパーツより小さい上部のパーツのイテレータ
            var minA = 0L;
            {
                var ok = -1;
                var ng = A.Length;

                while (Math.Abs(ok - ng) > 1)
                {
                    var min = Math.Min(ok, ng);
                    var max = Math.Max(ok, ng);

                    var middle = min + (max - min) / 2;

                    if (A[middle] < B[bIndex])
                    {
                        ok = middle;
                    }
                    else
                    {
                        ng = middle;
                    }
                }

                minA = ok;
            }

            count += (C.Length - maxC) * (minA + 1);
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
