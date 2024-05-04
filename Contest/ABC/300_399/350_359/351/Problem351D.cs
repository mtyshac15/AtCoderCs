using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC351;

public class ProblemD
{
    private TextReader _reader;
    private TextWriter _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemD();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemD()
    {
        _reader = Console.In;
        _writer = Console.Out;
    }

    public ProblemD(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void Solve()
    {
        var HW = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var H = HW[0];
        var W = HW[1];

        var S = new string[H];

        for (int i = 0; i < H; i++)
        {
            S[i] = _reader.ReadLine().Trim();
        }

        var dh = new int[] { 0, 1, 0, -1 };
        var dw = new int[] { 1, 0, -1, 0 };

        var ans = 0;

        var seen = new int[H, W];

        var startNum = 1;
        for (int startH = 0; startH < H; startH++)
        {
            for (int startW = 0; startW < W; startW++)
            {
                if (S[startH][startW] == '#'
                    || seen[startH, startW] > 0)
                {
                    //すでに見たことあるマスからはスタートしない
                    continue;
                }

                var count = 0;

                if (!this.CanMove(S, startH, startW))
                {
                    //初期位置から移動できない場合
                    count++;
                }
                else
                {
                    var queue = new Queue<(int H, int W)>();

                    count++;
                    queue.Enqueue((startH, startW));
                    seen[startH, startW] = startNum;

                    while (queue.Any())
                    {
                        var current = queue.Dequeue();

                        //隣接するマスに磁石がないか調べる
                        if (this.CanMove(S, current.H, current.W))
                        {
                            //4方向に磁石がない場合は移動可
                            for (int i = 0; i < 4; i++)
                            {
                                var nextH = current.H + dh[i];
                                var nextW = current.W + dw[i];

                                if (this.IsInside(S, nextH, nextW))
                                {
                                    if (S[nextH][nextW] == '.'
                                        && seen[nextH, nextW] != startNum)
                                    {
                                        count++;
                                        queue.Enqueue((nextH, nextW));
                                        seen[nextH, nextW] = startNum;
                                    }
                                }
                            }
                        }
                    }

                    startNum++;
                }

                ans = Math.Max(count, ans);
            }
        }

        _writer.WriteLine(ans);
    }

    private bool IsInside(string[] grid, int h, int w)
    {
        return h >= 0 && h < grid.Length && w >= 0 && w < grid[0].Length;
    }

    private bool CanMove(string[] grid, int h, int w)
    {
        var dh = new int[] { 0, 1, 0, -1 };
        var dw = new int[] { 1, 0, -1, 0 };

        //隣接4方向のいずれかに磁石が存在した場合は、移動不可
        for (int i = 0; i < 4; i++)
        {
            var nextH = h + dh[i];
            var nextW = w + dw[i];

            if (this.IsInside(grid, nextH, nextW) && grid[nextH][nextW] == '#')
            {
                return false;
            }
        }

        return true;
    }
}
