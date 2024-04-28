using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC341;

public class ProblemC
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemC();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemC()
    {
    }

    public ProblemC(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Solve()
    {
        var HWN = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var H = HWN[0];
        var W = HWN[1];
        var N = HWN[2];

        var T = _reader.ReadLine().Trim();

        var S = new string[H];
        for (int i = 0; i < H; i++)
        {
            S[i] = _reader.ReadLine().Trim();
        }

        var ans = 0;
        for (int startH = 1; startH < H - 1; startH++)
        {
            for (int startW = 1; startW < W - 1; startW++)
            {
                if (S[startH][startW] != '#')
                {
                    var isMatch = true;

                    var h = startH;
                    var w = startW;

                    for (int i = 0; i < N; i++)
                    {
                        switch (T[i])
                        {
                            case 'L':
                                w--;
                                break;
                            case 'R':
                                w++;
                                break;
                            case 'U':
                                h--;
                                break;
                            case 'D':
                                h++;
                                break;
                        }

                        if (S[h][w] == '#')
                        {
                            isMatch = false;
                            break;
                        }
                    }

                    if (isMatch)
                    {
                        ans++;
                    }
                }
            }
        }

        _writer.WriteLine(ans);
    }
}
