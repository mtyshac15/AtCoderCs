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

        for (int startH = 0; startH < H; startH++)
        {
            for (int startW = 0; startW < W; startW++)
            {
                var queue = new Queue<(int H, int W)>();

                if (S[startH][startW] != '#')
                {
                    var seen = new bool[H, W];

                    queue.Enqueue((startH, startW));
                    seen[startH, startW] = true;

                    var count = 1;
                    while (queue.Any())
                    {
                        var current = queue.Dequeue();

                        //隣接するマスに磁石がないか調べる
                        var canMove = true;
                        for (int i = 0; i < 4; i++)
                        {
                            var nextH = current.H + dh[i];
                            var nextW = current.W + dw[i];

                            if (nextH >= 0 && nextH < H
                               && nextW >= 0 && nextW < W)
                            {
                                if (S[nextH][nextW] == '#')
                                {
                                    if (count != 1)
                                    {
                                        count++;
                                    }

                                    canMove = false;
                                    break;
                                }
                            }
                        }

                        if (!canMove)
                        {
                            break;
                        }

                        //4方向に磁石がない場合は移動可
                        for (int i = 0; i < 4; i++)
                        {
                            var nextH = current.H + dh[i];
                            var nextW = current.W + dw[i];

                            if (nextH >= 0 && nextH < H
                                && nextW >= 0 && nextW < W)
                            {
                                if (S[nextH][nextW] == '.' && !seen[nextH, nextW])
                                {
                                    count++;
                                    queue.Enqueue((nextH, nextW));
                                    seen[nextH, nextW] = true;
                                }
                            }
                        }
                    }

                    ans = Math.Max(count, ans);
                }
            }
        }

        _writer.WriteLine(ans);
    }
}
