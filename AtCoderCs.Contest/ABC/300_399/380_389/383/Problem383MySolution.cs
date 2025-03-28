using AtCoderCs.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC383;

public class MySolution
{
    private Reader _reader;
    private Writer _writer;

    public MySolution()
    {
        _reader = new Reader(Console.In);
        _writer = new Writer(Console.Out);
    }

    public void OldA()
    {
        var N = _reader.Int();

        var T = new List<int>();
        var V = new List<int>();
        for (int i = 0; i < N; i++)
        {
            T.Add(_reader.Int());
            V.Add(_reader.Int());
        }

        var amount = 0;

        var time = 0;
        var index = 0;
        while (true)
        {
            if (time == T[index])
            {
                amount += V[index];
                index++;

                if (index == N)
                {
                    break;
                }
            }

            amount--;
            amount = Math.Max(amount, 0);
            time++;
        }

        var ans = amount;
        _writer.WriteLine(ans);
    }

    public void OldB()
    {
        var H = _reader.Int();
        var W = _reader.Int();
        var D = _reader.Int();

        var S = new List<string>();
        for (int h = 0; h < H; h++)
        {
            S.Add(_reader.Str());
        }

        var maxCount = 0;

        for (int h1 = 0; h1 < H; h1++)
        {
            for (int w1 = 0; w1 < W; w1++)
            {
                for (int h2 = 0; h2 < H; h2++)
                {
                    for (int w2 = 0; w2 < W; w2++)
                    {
                        // 加湿器を置く
                        if (S[h1][w1] == '.' && S[h2][w2] == '.')
                        {
                            var floor = new bool[H, W];

                            var humidifierH = new int[] { h1, h2 };
                            var humidifierW = new int[] { w1, w2 };

                            // 加湿器を始点に、加湿できるか探索
                            for (int i = 0; i < 2; i++)
                            {
                                for (int dh = -D; dh <= D; dh++)
                                {
                                    for (int dw = -(D - Math.Abs(dh)); dw <= D - Math.Abs(dh); dw++)
                                    {
                                        var h = humidifierH[i] + dh;
                                        var w = humidifierW[i] + dw;

                                        if (h >= 0 && h < H
                                            && w >= 0 && w < W
                                            && S[h][w] == '.')
                                        {
                                            floor[h, w] = true;
                                        }
                                    }
                                }
                            }

                            // マスの算出
                            var count = 0;
                            for (int h = 0; h < H; h++)
                            {
                                for (int w = 0; w < W; w++)
                                {
                                    if (floor[h, w])
                                    {
                                        count++;
                                    }
                                }
                            }

                            maxCount = Math.Max(maxCount, count);
                        }
                    }
                }
            }
        }

        var ans = maxCount;
        _writer.WriteLine(ans);
    }

}
