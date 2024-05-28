using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Training.A07;

public class Problem
{
    private Reader _reader;
    private Writer _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new Problem();
        problem.Solve();
        Console.Out.Flush();
    }

    public Problem()
           : this(Console.In, Console.Out)
    {
    }

    public Problem(TextReader textReader, TextWriter textWriter)
    {
        _reader = new Reader(textReader);
        _writer = new Writer(textWriter);
    }

    public void Solve()
    {
        var D = _reader.NextInt();
        var N = _reader.NextInt();

        var L = new List<int>();
        var R = new List<int>();
        for (int i = 0; i < N; i++)
        {
            L.Add(_reader.NextInt());
            R.Add(_reader.NextInt());
        }

        //増減を記録
        var diffCount = new long[D + 2];
        for (int i = 0; i < N; i++)
        {
            diffCount[L[i]]++;
            diffCount[R[i] + 1]--;
        }

        //集計
        var ansList = new List<long>() { diffCount[0] + diffCount[1] };
        for (int i = 0; i < D - 1; i++)
        {
            ansList.Add(ansList[i] + diffCount[i + 2]);
        }

        var ans = string.Join(Environment.NewLine, ansList);
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
