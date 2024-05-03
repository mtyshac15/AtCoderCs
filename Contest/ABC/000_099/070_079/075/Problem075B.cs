using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC075;

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

    /// <summary>
    /// 
    /// </summary>
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

        //隣接8方向
        var dh = new int[] { 1, 1, 0, -1, -1, -1, 0, 1 };
        var dw = new int[] { 0, 1, 1, 1, 0, -1, -1, -1 };

        var ansBuilder = new StringBuilder();
        for (int h = 0; h < H; h++)
        {
            for (int w = 0; w < W; w++)
            {
                if (S[h][w] == '.')
                {
                    var count = 0;

                    //8方向
                    for (int i = 0; i < 8; i++)
                    {
                        var nextH = h + dh[i];
                        var nextW = w + dw[i];
                        if (ProblemB.IsInner(nextH, nextW, H, W))
                        {
                            if (S[nextH][nextW] == '#')
                            {
                                count++;
                            }
                        }
                    }

                    ansBuilder.Append(count);
                }
                else
                {
                    ansBuilder.Append('#');
                }
            }

            ansBuilder.AppendLine();
        }

        var ans = ansBuilder.ToString();
        _writer.WriteLine(ans);
    }

    private static bool IsInner(int x, int y, int maxX, int maxY)
    {
        return x >= 0 && x < maxX && y >= 0 && y < maxY;
    }
}
