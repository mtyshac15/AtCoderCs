using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC334;

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
        var K = _reader.NextInt();
        var A = _reader.NextArray().Select(long.Parse).ToArray();

        //階差数列
        var B = A.Skip(1).Zip(A, (b1, b2) => b1 - b2)
                         .ToArray();

        //階差数列の添え字が偶数の累積和
        var sumBEven = new List<long>() { 0 };

        //階差数列の添え字が奇数の累積和
        var sumBOdd = new List<long>() { 0 };

        for (var i = 0; i < K - 1; i++)
        {
            if (i % 2 == 0)
            {
                var last = sumBEven[sumBEven.Count - 1];
                sumBEven.Add(last + B[i]);
            }
            else
            {
                var last = sumBOdd[sumBOdd.Count - 1];
                sumBOdd.Add(last + B[i]);
            }
        }

        var ans = 0L;
        if (K % 2 == 0)
        {
            //階差数列の添え字が偶数の和
            ans = sumBEven[sumBEven.Count - 1];
        }
        else
        {
            ans = long.MaxValue;

            //階差数列の添え字が偶数の要素を除外
            for (int i = 0; i < K; i += 2)
            {
                //除外した数より前の数値は添え字が偶数
                var sum = sumBEven[i / 2];

                //除外した数より後の数値は添え字が奇数
                sum += sumBOdd[sumBOdd.Count - 1] - sumBOdd[(i + 1) / 2];

                ans = Math.Min(sum, ans);
            }
        }

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
