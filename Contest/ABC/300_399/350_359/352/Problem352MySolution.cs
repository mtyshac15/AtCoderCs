using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC352;

public class MySolution
{
    private Reader _reader = new Reader(Console.In);
    private Writer _writer = new Writer(Console.Out);

    public void OldC()
    {
        var N = _reader.NextInt();

        var A = new List<int>();
        var B = new List<int>();

        for (int i = 0; i < N; i++)
        {
            A.Add(_reader.NextInt());
            B.Add(_reader.NextInt());
        }

        var array = A.Select((a, i) => (a, i))
                    .Zip(B, (a, b) => new
                    {
                        Index = a.i,
                        A = a.a,
                        B = b,
                        Head = b - a.a
                    }).ToArray();

        var max = array.MaxBy(x => x.Head);

        var ans = (long)max.B;
        for (int i = 0; i < N; i++)
        {
            if (i != max.Index)
            {
                ans += array[i].A;
            }
        }

        _writer.WriteLine(ans);
    }

    public void OldD()
    {
        var N = _reader.NextInt();
        var K = _reader.NextInt();

        var P = _reader.NextIntArray();
        var sortedP = P.Select((p, i) => (p, i)).OrderBy(x => x.p).ToArray();

        var ascSet = new SortedSet<int>();
        var descSet = new SortedSet<int>();

        var ans = int.MaxValue;
        var prevIndex = 0;

        for (int i = 0; i < N; i++)
        {
            var current = sortedP[i];
            ascSet.Add(current.i);
            descSet.Add(current.i * (-1));

            if (ascSet.Count == K + 1)
            {
                var prev = sortedP[prevIndex];
                ascSet.Remove(prev.i);
                descSet.Remove(prev.i * (-1));
                prevIndex++;
            }

            if (ascSet.Count == K)
            {
                var min = ascSet.FirstOrDefault();
                var max = descSet.FirstOrDefault() * (-1);
                ans = Math.Min(max - min, ans);
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
