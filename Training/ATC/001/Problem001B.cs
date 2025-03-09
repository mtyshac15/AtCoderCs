using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Training.ATC001;

public class ProblemB
{
    private Reader _reader;
    private Writer _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemB();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemB()
        : this(Console.In, Console.Out)
    {
    }

    public ProblemB(TextReader textReader, TextWriter textWriter)
    {
        _reader = new Reader(textReader);
        _writer = new Writer(textWriter);
    }

    public void Solve()
    {
        var N = _reader.NextInt();
        var Q = _reader.NextInt();

        var P = new List<int>();
        var A = new List<int>();
        var B = new List<int>();
        for (int i = 0; i < Q; i++)
        {
            P.Add(_reader.NextInt());
            A.Add(_reader.NextInt());
            B.Add(_reader.NextInt());
        }

        var unionFind = new UnionFind(N);

        var ansBuilder = new StringBuilder();
        for (int i = 0; i < Q; i++)
        {
            if (P[i] == 0)
            {
                unionFind.Unite(A[i], B[i]);
            }
            else if (P[i] == 1)
            {
                var ansStr = Writer.ToYesOrNo(unionFind.IsSame(A[i], B[i]));
                ansBuilder.AppendLine(ansStr);
            }
        }

        var ans = ansBuilder.ToString();
        _writer.WriteLine(ans);
    }

    #region
    struct UnionFind
    {
        IList<int> _par;
        IList<int> _size;

        public UnionFind(int n)
        {
            _par = Enumerable.Repeat(-1, n).ToList();
            _size = Enumerable.Repeat(1, n).ToList();
        }

        /// <summary>
        /// 根を求める
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int Root(int x)
        {
            if (_par[x] == -1)
            {
                return x;
            }
            else
            {
                _par[x] = this.Root(_par[x]);
                return _par[x];
            }
        }

        /// <summary>
        /// xとyが同じグループの所属するか
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsSame(int x, int y)
        {
            return this.Root(x) == this.Root(y);
        }

        public bool Unite(int x, int y)
        {
            //x,yの親を取得
            var rootX = this.Root(x);
            var rootY = this.Root(y);

            if (rootX == rootY)
            {
                return false;
            }

            if (_size[rootX] < _size[rootY])
            {
                var temp = rootX;
                rootX = rootY;
                rootY = temp;
            }

            _par[rootY] = rootX;
            _size[rootX] += _size[rootY];
            return true;
        }

        public int Size(int x)
        {
            return _size[this.Root(x)];
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
