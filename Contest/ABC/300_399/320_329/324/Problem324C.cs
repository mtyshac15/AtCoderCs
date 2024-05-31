using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC324;

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
        var Td = _reader.Next();

        var S = new string[N];
        for (int i = 0; i < N; i++)
        {
            S[i] = _reader.Next();
        }

        Func<string, string, int> checkStr = (string S, string T) =>
        {
            var minLength = Math.Min(S.Length, T.Length);
            var startIndex = 0;

            for (int i = 0; i < minLength; i++)
            {
                if (S[startIndex] == T[startIndex])
                {
                    startIndex++;
                }
                else
                {
                    break;
                }
            }

            var endIndex = 0;
            for (int i = 0; i < minLength - startIndex; i++)
            {
                if (S[S.Length - 1 - endIndex] == T[T.Length - 1 - endIndex])
                {
                    endIndex++;
                }
                else
                {
                    break;
                }
            }

            return startIndex + endIndex;
        };

        var ansList = new List<int>();
        for (int i = 0; i < N; i++)
        {
            var ansIndex = i + 1;

            var Si = S[i];
            if (Si == Td)
            {
                ansList.Add(ansIndex);
            }
            else if (Si.Length == Td.Length)
            {
                //Tの1文字を変更
                var length = checkStr(Si, Td);
                if (length == Si.Length - 1)
                {
                    ansList.Add(ansIndex);
                }
            }
            else if (Si.Length - 1 == Td.Length)
            {
                //Tから1文字削除
                var length = checkStr(Si, Td);
                if (length == Td.Length)
                {
                    ansList.Add(ansIndex);
                }
            }
            else if (Si.Length + 1 == Td.Length)
            {
                //Tに1文字追加
                var length = checkStr(Si, Td);
                if (length == Si.Length)
                {
                    ansList.Add(ansIndex);
                }
            }
        }

        var K = ansList.Count;
        _writer.WriteLine(K);

        var ans = string.Join(" ", ansList);
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
