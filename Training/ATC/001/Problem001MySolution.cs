using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Training.ATC001;

public class MySolution
{
    private Reader _reader;
    private Writer _writer;

    public MySolution()
    {
        _reader = new Reader(Console.In);
        _writer = new Writer(Console.Out);
    }

    public void SolveA()
    {
        var H = _reader.Int();
        var W = _reader.Int();

        var c = new List<string>();
        for (int i = 0; i < H; i++)
        {
            c.Add(_reader.Str());
        }

        var sh = 0;
        var sw = 0;
        var gh = 0;
        var gw = 0;

        for (int h = 0; h < H; h++)
        {
            for (int w = 0; w < W; w++)
            {
                if (c[h][w] == 's')
                {
                    sh = h;
                    sw = w;
                }
                else if (c[h][w] == 'g')
                {
                    gh = h;
                    gw = w;
                }
            }
        }

        var seen = new bool[H, W];

        this.Search(c, sh, sw, seen);

        var ans = seen[gh, gw];
        _writer.WriteYesOrNo(ans);
    }

    private void Search(IList<string> grid, int h, int w, bool[,] seen)
    {
        if (h < 0 || h >= grid.Count
            || w < 0 || w >= grid[h].Length)
        {
            return;
        }

        if (grid[h][w] == '#')
        {
            //壁の場合
            return;
        }

        if (seen[h, w])
        {
            //探索済み
            return;
        }

        seen[h, w] = true;

        if (grid[h][w] == 'g')
        {
            return;
        }

        var dh = new int[] { 0, 1, 0, -1 };
        var dw = new int[] { 1, 0, -1, 0 };

        for (int i = 0; i < 4; i++)
        {
            var nextH = h + dh[i];
            var nextW = w + dw[i];
            this.Search(grid, nextH, nextW, seen);
        }
    }
}
