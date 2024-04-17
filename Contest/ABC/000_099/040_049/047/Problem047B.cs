using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC047;

public class ProblemB
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemB();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemB()
    {
    }

    public ProblemB(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void Solve()
    {
        var WHN = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var W = WHN[0];
        var H = WHN[1];
        var N = WHN[2];

        var x = new int[N];
        var y = new int[N];
        var a = new int[N];

        for (int i = 0; i < N; i++)
        {
            var input = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            x[i] = input[0];
            y[i] = input[1];
            a[i] = input[2];
        }

        var grid = new int[W, H];

        for (int i = 0; i < N; i++)
        {
            if (a[i] == 1)
            {
                this.Draw(grid, 0, x[i] - 1, 0, H - 1);
            }
            else if (a[i] == 2)
            {
                this.Draw(grid, x[i], W - 1, 0, H - 1);
            }
            else if (a[i] == 3)
            {
                this.Draw(grid, 0, W - 1, 0, y[i] - 1);
            }
            else if (a[i] == 4)
            {
                this.Draw(grid, 0, W - 1, y[i], H - 1);
            }
        }

        //集計
        var black = 0;
        for (int w = 0; w < W; w++)
        {
            for (int h = 0; h < H; h++)
            {
                black += grid[w, h];
            }
        }

        var ans = W * H - black;
        _writer.WriteLine(ans);
    }

    private void Draw(int[,] grid, int startX, int endX, int startY, int endY)
    {
        //両端含む
        for (int x = startX; x <= endX; x++)
        {
            for (int y = startY; y <= endY; y++)
            {
                grid[x, y] = 1;
            }
        }
    }
}
