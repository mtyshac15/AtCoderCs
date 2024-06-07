using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC323;

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
        var M = _reader.NextInt();

        var A = _reader.NextIntArray();

        var S = new List<string>() { string.Empty };
        for (int i = 0; i < N; i++)
        {
            S.Add(_reader.Next());
        }

        //現在の点数を集計
        var score = Enumerable.Range(0, N + 1).ToArray();
        for (int i = 1; i <= N; i++)
        {
            var total = 0;
            for (int j = 0; j < M; j++)
            {
                if (S[i][j] == 'o')
                {
                    total += A[j];
                }
            }

            score[i] += total;
        }

        var maxScore = score.Max();

        var sortedA = A.Select((X, Index) => (X, Index)).OrderByDescending(x => x.X).ToArray();

        var ansBuilder = new StringBuilder();
        for (int i = 1; i <= N; i++)
        {
            var currentScore = score[i];
            if (currentScore < maxScore)
            {
                var count = 0;

                foreach (var item in sortedA.Where(x => S[i][x.Index] == 'x'))
                {
                    currentScore += item.X;
                    count++;

                    if (currentScore > maxScore)
                    {
                        break;
                    }
                }

                ansBuilder.AppendLine($"{count}");
            }
            else
            {
                ansBuilder.AppendLine($"{0}");
            }
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
