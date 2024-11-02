using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC145;

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

        var x = new List<int>();
        var y = new List<int>();

        for (int i = 0; i < N; i++)
        {
            x.Add(_reader.NextInt());
            y.Add(_reader.NextInt());
        }

        var path = new List<double>();

        var nodeArray = Enumerable.Range(0, N).ToArray();
        do
        {
            var length = 0d;
            for (int i = 0; i < N - 1; i++)
            {
                var node = nodeArray[i];
                var nextNode = nodeArray[i + 1];

                var dx = x[nextNode] - x[node];
                var dy = y[nextNode] - y[node];

                length += Math.Sqrt(dx * dx + dy * dy);
            }

            path.Add(length);
        }
        while (MathLibrary.NextPermutation(nodeArray));

        var ans = path.Average();
        _writer.WriteLine(ans);
    }

    #region "IO"
    public class Reader
    {
        private TextReader _reader;
        private int _index;
        private string[] _line;

        char[] _cs = new char[] { ' ' };

        public Reader()
            : this(Console.In)
        {
        }

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

        public Writer()
           : this(Console.Out)
        {
        }

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

    #region
    static class MathLibrary
    {
        public static bool NextPermutation<T>(T[] array)
            where T : IComparable<T>
        {
            var isOk = false;

            //array[i]<array[i+1]‚ð–ž‚½‚·Å‘å‚Ìi‚ð‹‚ß‚é
            var i = array.Length - 2;
            for (; i >= 0; i--)
            {
                if (array[i].CompareTo(array[i + 1]) < 0)
                {
                    isOk = true;
                    break;
                }
            }

            //‘S‚Ä‚Ì—v‘f‚ª~‡‚Ìê‡I—¹
            if (!isOk)
            {
                return false;
            }

            //array[i]<array[j]‚ð–ž‚½‚·Å‘å‚Ìj‚ð‹‚ß‚é
            int j = array.Length - 1;
            for (; ; j--)
            {
                if (array[i].CompareTo(array[j]) < 0)
                {
                    break;
                }
            }

            //i‚Ì—v‘f‚Æj‚Ì—v‘f‚ðŒðŠ·
            var tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;

            //iˆÈ~‚Ì—v‘f‚ð”½“]‚³‚¹‚é
            Array.Reverse(array, i + 1, array.Length - (i + 1));

            return true;
        }
    }
    #endregion
}
