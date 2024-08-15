using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC320;

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
        var M = _reader.NextInt();

        var S = new List<string>();
        for (int i = 0; i < 3; i++)
        {
            S.Add(_reader.Next());
        }

        var reels = new List<IDictionary<char, SortedSet<int>>>();

        for (int i = 0; i < 3; i++)
        {
            var reel = new Dictionary<char, SortedSet<int>>();

            var indexS = S[i].Select((x, i) => (x, i))
                             .ToLookup(x => x.x, x => x.i);

            foreach (var item in indexS)
            {
                reel.Add(item.Key, new SortedSet<int>(item));
            }

            reels.Add(reel);
        }

        var hashSet1 = new HashSet<char>(S[0]);
        var hashSet2 = new HashSet<char>(S[1]);
        var hashSet3 = new HashSet<char>(S[2]);

        var canMatch = true;
        foreach (var num in reels[0])
        {
            if (!reels[1].ContainsKey(num.Key))
            {
                canMatch = false;
                break;
            }

            if (!reels[2].ContainsKey(num.Key))
            {
                canMatch = false;
                break;
            }
        }

        if (!canMatch)
        {
            _writer.WriteLine($"{-1}");
            return;
        }

        var minTime = int.MaxValue;
        for (int i = 0; i < 3; i++)
        {
            var reel1 = reels[(i + 1) % 3];
            var reel2 = reels[(i + 2) % 3];

            var time = 0;
            foreach (var num in S[i])
            {
                var times1 = reel1[num];
                var times2 = reel2[num];
            }
        }

        var ans = minTime;
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
