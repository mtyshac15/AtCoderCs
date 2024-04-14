using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC348;

public class ProblemD
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    private bool[,] field;
    private int[,] RCE;

    private int[,] direction = new int[,]
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
    {
    }

    public ProblemD(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// Medicines on Grid
    /// </summary>
    public void Solve()
    {
        var HW = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var H = HW[0];
        var W = HW[1];

        var A = new string[H];
        for (int i = 0; i < H; i++)
        {
            A[i] = _reader.ReadLine().Trim();
        }

        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        RCE = new int[H, W];
        for (int i = 0; i < N; i++)
        {
            var input = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            var R = input[0];
            var C = input[1];
            var E = input[2];
            RCE[R - 1, C - 1] = E;
        }

        this.field = new bool[H, W];

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

        var ans = this.field[goal[0], goal[1]];
        _writer.WriteLine(IOLibrary.ToYesOrNo(ans));
    }

    private void Serch(int H, int W, string[] c, int h, int w, int energy)
    {
        //探索済み
        this.field[h, w] = true;

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
        if (this.RCE[h, w] > energy)
        {
            energy = this.RCE[h, w];
        }

        //各方向を探索
        for (int i = 0; i < 4; i++)
        {
            //エネルギーがない場合は移動不可
            if (energy == 0)
            {
                break;
            }

            int nextH = h + this.direction[i, 0];
            int nextW = w + this.direction[i, 1];

            if (nextH >= 0 && nextH < H
                && nextW >= 0 && nextW < W)
            {
                if (!this.field[nextH, nextW])
                {
                    //未探索の場合は、探索を行う
                    this.Serch(H, W, c, nextH, nextW, energy - 1);
                }
            }
        }
    }

    public static class IOLibrary
    {
        public static string ToYesOrNo(bool value)
        {
            return value ? $"Yes" : $"No";
        }
    }
}
