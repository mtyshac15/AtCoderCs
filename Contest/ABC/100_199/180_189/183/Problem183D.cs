using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC183;

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
        var W = _reader.NextInt();

        var S = new List<int>();
        var T = new List<int>();
        var P = new List<int>();
        for (int i = 0; i < N; i++)
        {
            S.Add(_reader.NextInt());
            T.Add(_reader.NextInt());
            P.Add(_reader.NextInt());
        }

        //‘Œ¸‚ð‹L˜^
        var heater = new SortedDictionary<int, long>();
        for (int i = 0; i < N; i++)
        {
            if (heater.ContainsKey(S[i]))
            {
                heater[S[i]] += P[i];
            }
            else
            {
                heater.Add(S[i], P[i]);
            }

            if (heater.ContainsKey(T[i]))
            {
                heater[T[i]] -= P[i];
            }
            else
            {
                heater.Add(T[i], P[i] * (-1));
            }
        }

        //WŒv
        var water = new List<long>() { heater.Values.FirstOrDefault() };
        foreach (var keyValue in heater.Skip(1))
        {
            water.Add(water[water.Count - 1] + keyValue.Value);
        }

        var ans = water.All(x => x <= W);
        _writer.WriteYesOrNo(ans);
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
