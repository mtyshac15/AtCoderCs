using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC348;

public class ProblemD
{
    private Reader _reader;
    private Writer _writer;

    private bool[,] _field;
    private int[,] _RCE;

    private int[,] _direction = new int[,]
    {
        { 0, -1 },
        { 1, 0 },
        { 0, 1 },
        { -1, 0 }
    };

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

    /// <summary>
    /// Medicines on Grid
    /// </summary>
    public void Solve()
    {
        var H = _reader.NextInt();
        var W = _reader.NextInt();

        var A = new List<string>();
        for (int i = 0; i < H; i++)
        {
            A.Add(_reader.Next());
        }

        var N = _reader.NextInt();

        _RCE = new int[H, W];
        for (int i = 0; i < N; i++)
        {
            var R = _reader.NextInt();
            var C = _reader.NextInt();
            var E = _reader.NextInt();
            _RCE[R - 1, C - 1] = E;
        }

        this._field = new bool[H, W];

        var start = new int[2];
        var goal = new int[2];

        //開始、ゴール地点を探索
        for (int h = 0; h < H; h++)
        {
            for (int w = 0; w < W; w++)
            {
                if (A[h][w] == 'S')
                {
                    start[0] = h;
                    start[1] = w;
                }
                else if (A[h][w] == 'T')
                {
                    goal[0] = h;
                    goal[1] = w;
                }
            }
        }

        //深さ優先探索
        this.Serch(H, W, A, start[0], start[1], 0);

        var ans = this._field[goal[0], goal[1]];
        _writer.WriteYesOrNo(ans);
    }

    private void Serch(int H, int W, IReadOnlyList<string> c, int h, int w, int energy)
    {
        //探索済み
        this._field[h, w] = true;

        if (c[h][w] == 'T')
        {
            return;
        }

        //壁の場合は、探索終了
        if (c[h][w] == '#')
        {
            return;
        }

        //薬を使う場合、現在のエネルギーの方が少ない場合に薬を使用
        if (this._RCE[h, w] > energy)
        {
            energy = this._RCE[h, w];
        }

        //各方向を探索
        for (int i = 0; i < 4; i++)
        {
            //エネルギーがない場合は移動不可
            if (energy == 0)
            {
                break;
            }

            int nextH = h + this._direction[i, 0];
            int nextW = w + this._direction[i, 1];

            if (nextH >= 0 && nextH < H
                && nextW >= 0 && nextW < W)
            {
                if (!this._field[nextH, nextW])
                {
                    //未探索の場合は、探索を行う
                    this.Serch(H, W, c, nextH, nextW, energy - 1);
                }
            }
        }
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
